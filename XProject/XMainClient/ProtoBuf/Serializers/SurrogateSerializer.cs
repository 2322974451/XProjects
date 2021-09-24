using System;
using System.Reflection;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{

	internal sealed class SurrogateSerializer : IProtoTypeSerializer, IProtoSerializer
	{

		bool IProtoTypeSerializer.HasCallbacks(TypeModel.CallbackType callbackType)
		{
			return false;
		}

		bool IProtoTypeSerializer.CanCreateInstance()
		{
			return false;
		}

		object IProtoTypeSerializer.CreateInstance(ProtoReader source)
		{
			throw new NotSupportedException();
		}

		void IProtoTypeSerializer.Callback(object value, TypeModel.CallbackType callbackType, SerializationContext context)
		{
		}

		public bool ReturnsValue
		{
			get
			{
				return false;
			}
		}

		public bool RequiresOldValue
		{
			get
			{
				return true;
			}
		}

		public Type ExpectedType
		{
			get
			{
				return this.forType;
			}
		}

		public SurrogateSerializer(TypeModel model, Type forType, Type declaredType, IProtoTypeSerializer rootTail)
		{
			Helpers.DebugAssert(forType != null, "forType");
			Helpers.DebugAssert(declaredType != null, "declaredType");
			Helpers.DebugAssert(rootTail != null, "rootTail");
			Helpers.DebugAssert(rootTail.RequiresOldValue, "RequiresOldValue");
			Helpers.DebugAssert(!rootTail.ReturnsValue, "ReturnsValue");
			Helpers.DebugAssert(declaredType == rootTail.ExpectedType || Helpers.IsSubclassOf(declaredType, rootTail.ExpectedType));
			this.forType = forType;
			this.declaredType = declaredType;
			this.rootTail = rootTail;
			this.toTail = this.GetConversion(model, true);
			this.fromTail = this.GetConversion(model, false);
		}

		private static bool HasCast(TypeModel model, Type type, Type from, Type to, out MethodInfo op)
		{
			MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			Type type2 = null;
			foreach (MethodInfo methodInfo in methods)
			{
				bool flag = methodInfo.ReturnType != to;
				if (!flag)
				{
					ParameterInfo[] parameters = methodInfo.GetParameters();
					bool flag2 = parameters.Length == 1 && parameters[0].ParameterType == from;
					if (flag2)
					{
						bool flag3 = type2 == null;
						if (flag3)
						{
							type2 = model.MapType(typeof(ProtoConverterAttribute), false);
							bool flag4 = type2 == null;
							if (flag4)
							{
								break;
							}
						}
						bool flag5 = methodInfo.IsDefined(type2, true);
						if (flag5)
						{
							op = methodInfo;
							return true;
						}
					}
				}
			}
			foreach (MethodInfo methodInfo2 in methods)
			{
				bool flag6 = (methodInfo2.Name != "op_Implicit" && methodInfo2.Name != "op_Explicit") || methodInfo2.ReturnType != to;
				if (!flag6)
				{
					ParameterInfo[] parameters = methodInfo2.GetParameters();
					bool flag7 = parameters.Length == 1 && parameters[0].ParameterType == from;
					if (flag7)
					{
						op = methodInfo2;
						return true;
					}
				}
			}
			op = null;
			return false;
		}

		public MethodInfo GetConversion(TypeModel model, bool toTail)
		{
			Type to = toTail ? this.declaredType : this.forType;
			Type from = toTail ? this.forType : this.declaredType;
			MethodInfo result;
			bool flag = SurrogateSerializer.HasCast(model, this.declaredType, from, to, out result) || SurrogateSerializer.HasCast(model, this.forType, from, to, out result);
			if (flag)
			{
				return result;
			}
			throw new InvalidOperationException("No suitable conversion operator found for surrogate: " + this.forType.FullName + " / " + this.declaredType.FullName);
		}

		public void Write(object value, ProtoWriter writer)
		{
			ProtoDecoratorBase.s_argsWrite[0] = value;
			this.rootTail.Write(this.toTail.Invoke(null, ProtoDecoratorBase.s_argsWrite), writer);
		}

		public object Read(object value, ProtoReader source)
		{
			ProtoDecoratorBase.s_argsRead[0] = value;
			value = this.toTail.Invoke(null, ProtoDecoratorBase.s_argsRead);
			ProtoDecoratorBase.s_argsRead[0] = this.rootTail.Read(value, source);
			return this.fromTail.Invoke(null, ProtoDecoratorBase.s_argsRead);
		}

		private readonly Type forType;

		private readonly Type declaredType;

		private readonly MethodInfo toTail;

		private readonly MethodInfo fromTail;

		private IProtoTypeSerializer rootTail;
	}
}
