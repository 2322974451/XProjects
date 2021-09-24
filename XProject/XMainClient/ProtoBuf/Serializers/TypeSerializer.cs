using System;
using System.Reflection;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{

	internal sealed class TypeSerializer : IProtoTypeSerializer, IProtoSerializer
	{

		public bool HasCallbacks(TypeModel.CallbackType callbackType)
		{
			bool flag = this.callbacks != null && this.callbacks[callbackType] != null;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				for (int i = 0; i < this.serializers.Length; i++)
				{
					bool flag2 = this.serializers[i].ExpectedType != this.forType && ((IProtoTypeSerializer)this.serializers[i]).HasCallbacks(callbackType);
					if (flag2)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		public Type ExpectedType
		{
			get
			{
				return this.forType;
			}
		}

		public TypeSerializer(TypeModel model, Type forType, int[] fieldNumbers, IProtoSerializer[] serializers, MethodInfo[] baseCtorCallbacks, bool isRootType, bool useConstructor, CallbackSet callbacks, Type constructType, MethodInfo factory)
		{
			Helpers.DebugAssert(forType != null);
			Helpers.DebugAssert(fieldNumbers != null);
			Helpers.DebugAssert(serializers != null);
			Helpers.DebugAssert(fieldNumbers.Length == serializers.Length);
			Helpers.Sort(fieldNumbers, serializers);
			bool flag = false;
			for (int i = 1; i < fieldNumbers.Length; i++)
			{
				bool flag2 = fieldNumbers[i] == fieldNumbers[i - 1];
				if (flag2)
				{
					throw new InvalidOperationException("Duplicate field-number detected; " + fieldNumbers[i].ToString() + " on: " + forType.FullName);
				}
				bool flag3 = !flag && serializers[i].ExpectedType != forType;
				if (flag3)
				{
					flag = true;
				}
			}
			this.forType = forType;
			this.factory = factory;
			bool flag4 = constructType == null;
			if (flag4)
			{
				constructType = forType;
			}
			else
			{
				bool flag5 = !forType.IsAssignableFrom(constructType);
				if (flag5)
				{
					throw new InvalidOperationException(forType.FullName + " cannot be assigned from " + constructType.FullName);
				}
			}
			this.constructType = constructType;
			this.serializers = serializers;
			this.fieldNumbers = fieldNumbers;
			this.callbacks = callbacks;
			this.isRootType = isRootType;
			this.useConstructor = useConstructor;
			bool flag6 = baseCtorCallbacks != null && baseCtorCallbacks.Length == 0;
			if (flag6)
			{
				baseCtorCallbacks = null;
			}
			this.baseCtorCallbacks = baseCtorCallbacks;
			bool flag7 = Helpers.GetUnderlyingType(forType) != null;
			if (flag7)
			{
				throw new ArgumentException("Cannot create a TypeSerializer for nullable types", "forType");
			}
			bool flag8 = model.MapType(TypeSerializer.iextensible).IsAssignableFrom(forType);
			if (flag8)
			{
				bool flag9 = forType.IsValueType || !isRootType || flag;
				if (flag9)
				{
					throw new NotSupportedException("IExtensible is not supported in structs or classes with inheritance");
				}
				this.isExtensible = true;
			}
			this.hasConstructor = (!constructType.IsAbstract && Helpers.GetConstructor(constructType, Helpers.EmptyTypes, true) != null);
			bool flag10 = constructType != forType && useConstructor && !this.hasConstructor;
			if (flag10)
			{
				throw new ArgumentException("The supplied default implementation cannot be created: " + constructType.FullName, "constructType");
			}
		}

		private bool CanHaveInheritance
		{
			get
			{
				return (this.forType.IsClass || this.forType.IsInterface) && !this.forType.IsSealed;
			}
		}

		bool IProtoTypeSerializer.CanCreateInstance()
		{
			return true;
		}

		object IProtoTypeSerializer.CreateInstance(ProtoReader source)
		{
			return this.CreateInstance(source, false);
		}

		public void Callback(object value, TypeModel.CallbackType callbackType, SerializationContext context)
		{
			bool flag = this.callbacks != null;
			if (flag)
			{
				this.InvokeCallback(this.callbacks[callbackType], value, context);
			}
			IProtoTypeSerializer protoTypeSerializer = (IProtoTypeSerializer)this.GetMoreSpecificSerializer(value);
			bool flag2 = protoTypeSerializer != null;
			if (flag2)
			{
				protoTypeSerializer.Callback(value, callbackType, context);
			}
		}

		private IProtoSerializer GetMoreSpecificSerializer(object value)
		{
			bool flag = !this.CanHaveInheritance;
			IProtoSerializer result;
			if (flag)
			{
				result = null;
			}
			else
			{
				Type type = value.GetType();
				bool flag2 = type == this.forType;
				if (flag2)
				{
					result = null;
				}
				else
				{
					for (int i = 0; i < this.serializers.Length; i++)
					{
						IProtoSerializer protoSerializer = this.serializers[i];
						bool flag3 = protoSerializer.ExpectedType != this.forType && Helpers.IsAssignableFrom(protoSerializer.ExpectedType, type);
						if (flag3)
						{
							return protoSerializer;
						}
					}
					bool flag4 = type == this.constructType;
					if (flag4)
					{
						result = null;
					}
					else
					{
						TypeModel.ThrowUnexpectedSubtype(this.forType, type);
						result = null;
					}
				}
			}
			return result;
		}

		public void Write(object value, ProtoWriter dest)
		{
			bool flag = this.isRootType;
			if (flag)
			{
				this.Callback(value, TypeModel.CallbackType.BeforeSerialize, dest.Context);
			}
			IProtoSerializer moreSpecificSerializer = this.GetMoreSpecificSerializer(value);
			bool flag2 = moreSpecificSerializer != null;
			if (flag2)
			{
				moreSpecificSerializer.Write(value, dest);
			}
			for (int i = 0; i < this.serializers.Length; i++)
			{
				IProtoSerializer protoSerializer = this.serializers[i];
				bool flag3 = protoSerializer.ExpectedType == this.forType;
				if (flag3)
				{
					protoSerializer.Write(value, dest);
				}
			}
			bool flag4 = this.isExtensible;
			if (flag4)
			{
				ProtoWriter.AppendExtensionData((IExtensible)value, dest);
			}
			bool flag5 = this.isRootType;
			if (flag5)
			{
				this.Callback(value, TypeModel.CallbackType.AfterSerialize, dest.Context);
			}
		}

		public object Read(object value, ProtoReader source)
		{
			bool flag = this.isRootType && value != null;
			if (flag)
			{
				this.Callback(value, TypeModel.CallbackType.BeforeDeserialize, source.Context);
			}
			int num = 0;
			int num2 = 0;
			int num3;
			while ((num3 = source.ReadFieldHeader()) > 0)
			{
				bool flag2 = false;
				bool flag3 = num3 < num;
				if (flag3)
				{
					num2 = (num = 0);
				}
				for (int i = num2; i < this.fieldNumbers.Length; i++)
				{
					bool flag4 = this.fieldNumbers[i] == num3;
					if (flag4)
					{
						IProtoSerializer protoSerializer = this.serializers[i];
						Type expectedType = protoSerializer.ExpectedType;
						bool flag5 = value == null;
						if (flag5)
						{
							bool flag6 = expectedType == this.forType;
							if (flag6)
							{
								value = this.CreateInstance(source, true);
							}
						}
						else
						{
							bool flag7 = expectedType != this.forType && ((IProtoTypeSerializer)protoSerializer).CanCreateInstance() && expectedType.IsSubclassOf(value.GetType());
							if (flag7)
							{
								value = ProtoReader.Merge(source, value, ((IProtoTypeSerializer)protoSerializer).CreateInstance(source));
							}
						}
						bool returnsValue = protoSerializer.ReturnsValue;
						if (returnsValue)
						{
							value = protoSerializer.Read(value, source);
						}
						else
						{
							protoSerializer.Read(value, source);
						}
						num2 = i;
						num = num3;
						flag2 = true;
						break;
					}
				}
				bool flag8 = !flag2;
				if (flag8)
				{
					bool flag9 = value == null;
					if (flag9)
					{
						value = this.CreateInstance(source, true);
					}
					bool flag10 = this.isExtensible;
					if (flag10)
					{
						source.AppendExtensionData((IExtensible)value);
					}
					else
					{
						source.SkipField();
					}
				}
			}
			bool flag11 = value == null;
			if (flag11)
			{
				value = this.CreateInstance(source, true);
			}
			bool flag12 = this.isRootType;
			if (flag12)
			{
				this.Callback(value, TypeModel.CallbackType.AfterDeserialize, source.Context);
			}
			return value;
		}

		private object InvokeCallback(MethodInfo method, object obj, SerializationContext context)
		{
			object result = null;
			bool flag = method != null;
			if (flag)
			{
				ParameterInfo[] parameters = method.GetParameters();
				int num = parameters.Length;
				object[] array;
				bool flag2;
				if (num != 0)
				{
					array = new object[parameters.Length];
					flag2 = true;
					for (int i = 0; i < array.Length; i++)
					{
						Type parameterType = parameters[i].ParameterType;
						bool flag3 = parameterType == typeof(SerializationContext);
						object obj2;
						if (flag3)
						{
							obj2 = context;
						}
						else
						{
							bool flag4 = parameterType == typeof(Type);
							if (flag4)
							{
								obj2 = this.constructType;
							}
							else
							{
								obj2 = null;
								flag2 = false;
							}
						}
						array[i] = obj2;
					}
				}
				else
				{
					array = null;
					flag2 = true;
				}
				bool flag5 = flag2;
				if (!flag5)
				{
					throw CallbackSet.CreateInvalidCallbackSignature(method);
				}
				result = method.Invoke(obj, array);
			}
			return result;
		}

		private object CreateInstance(ProtoReader source, bool includeLocalCallback)
		{
			bool flag = this.factory != null;
			object obj;
			if (flag)
			{
				obj = this.InvokeCallback(this.factory, null, source.Context);
			}
			else
			{
				bool flag2 = this.useConstructor;
				if (flag2)
				{
					bool flag3 = !this.hasConstructor;
					if (flag3)
					{
						TypeModel.ThrowCannotCreateInstance(this.constructType);
					}
					obj = Activator.CreateInstance(this.constructType, true);
				}
				else
				{
					obj = BclHelpers.GetUninitializedObject(this.constructType);
				}
			}
			ProtoReader.NoteObject(obj, source);
			bool flag4 = this.baseCtorCallbacks != null;
			if (flag4)
			{
				for (int i = 0; i < this.baseCtorCallbacks.Length; i++)
				{
					this.InvokeCallback(this.baseCtorCallbacks[i], obj, source.Context);
				}
			}
			bool flag5 = includeLocalCallback && this.callbacks != null;
			if (flag5)
			{
				this.InvokeCallback(this.callbacks.BeforeDeserialize, obj, source.Context);
			}
			return obj;
		}

		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return true;
			}
		}

		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return false;
			}
		}

		private readonly Type forType;

		private readonly Type constructType;

		private readonly IProtoSerializer[] serializers;

		private readonly int[] fieldNumbers;

		private readonly bool isRootType;

		private readonly bool useConstructor;

		private readonly bool isExtensible;

		private readonly bool hasConstructor;

		private readonly CallbackSet callbacks;

		private readonly MethodInfo[] baseCtorCallbacks;

		private readonly MethodInfo factory;

		private static readonly Type iextensible = typeof(IExtensible);
	}
}
