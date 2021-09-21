using System;
using System.Reflection;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000879 RID: 2169
	internal sealed class SurrogateSerializer : IProtoTypeSerializer, IProtoSerializer
	{
		// Token: 0x06008427 RID: 33831 RVA: 0x00101940 File Offset: 0x000FFB40
		bool IProtoTypeSerializer.HasCallbacks(TypeModel.CallbackType callbackType)
		{
			return false;
		}

		// Token: 0x06008428 RID: 33832 RVA: 0x00101954 File Offset: 0x000FFB54
		bool IProtoTypeSerializer.CanCreateInstance()
		{
			return false;
		}

		// Token: 0x06008429 RID: 33833 RVA: 0x00101967 File Offset: 0x000FFB67
		object IProtoTypeSerializer.CreateInstance(ProtoReader source)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600842A RID: 33834 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		void IProtoTypeSerializer.Callback(object value, TypeModel.CallbackType callbackType, SerializationContext context)
		{
		}

		// Token: 0x170029C5 RID: 10693
		// (get) Token: 0x0600842B RID: 33835 RVA: 0x00101970 File Offset: 0x000FFB70
		public bool ReturnsValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170029C6 RID: 10694
		// (get) Token: 0x0600842C RID: 33836 RVA: 0x00101984 File Offset: 0x000FFB84
		public bool RequiresOldValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170029C7 RID: 10695
		// (get) Token: 0x0600842D RID: 33837 RVA: 0x00101998 File Offset: 0x000FFB98
		public Type ExpectedType
		{
			get
			{
				return this.forType;
			}
		}

		// Token: 0x0600842E RID: 33838 RVA: 0x001019B0 File Offset: 0x000FFBB0
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

		// Token: 0x0600842F RID: 33839 RVA: 0x00101A6C File Offset: 0x000FFC6C
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

		// Token: 0x06008430 RID: 33840 RVA: 0x00101BC4 File Offset: 0x000FFDC4
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

		// Token: 0x06008431 RID: 33841 RVA: 0x00101C52 File Offset: 0x000FFE52
		public void Write(object value, ProtoWriter writer)
		{
			ProtoDecoratorBase.s_argsWrite[0] = value;
			this.rootTail.Write(this.toTail.Invoke(null, ProtoDecoratorBase.s_argsWrite), writer);
		}

		// Token: 0x06008432 RID: 33842 RVA: 0x00101C7C File Offset: 0x000FFE7C
		public object Read(object value, ProtoReader source)
		{
			ProtoDecoratorBase.s_argsRead[0] = value;
			value = this.toTail.Invoke(null, ProtoDecoratorBase.s_argsRead);
			ProtoDecoratorBase.s_argsRead[0] = this.rootTail.Read(value, source);
			return this.fromTail.Invoke(null, ProtoDecoratorBase.s_argsRead);
		}

		// Token: 0x04002914 RID: 10516
		private readonly Type forType;

		// Token: 0x04002915 RID: 10517
		private readonly Type declaredType;

		// Token: 0x04002916 RID: 10518
		private readonly MethodInfo toTail;

		// Token: 0x04002917 RID: 10519
		private readonly MethodInfo fromTail;

		// Token: 0x04002918 RID: 10520
		private IProtoTypeSerializer rootTail;
	}
}
