using System;
using System.Reflection;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x0200087E RID: 2174
	internal sealed class TypeSerializer : IProtoTypeSerializer, IProtoSerializer
	{
		// Token: 0x06008458 RID: 33880 RVA: 0x00102390 File Offset: 0x00100590
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

		// Token: 0x170029D5 RID: 10709
		// (get) Token: 0x06008459 RID: 33881 RVA: 0x00102414 File Offset: 0x00100614
		public Type ExpectedType
		{
			get
			{
				return this.forType;
			}
		}

		// Token: 0x0600845A RID: 33882 RVA: 0x0010242C File Offset: 0x0010062C
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

		// Token: 0x170029D6 RID: 10710
		// (get) Token: 0x0600845B RID: 33883 RVA: 0x00102648 File Offset: 0x00100848
		private bool CanHaveInheritance
		{
			get
			{
				return (this.forType.IsClass || this.forType.IsInterface) && !this.forType.IsSealed;
			}
		}

		// Token: 0x0600845C RID: 33884 RVA: 0x00102688 File Offset: 0x00100888
		bool IProtoTypeSerializer.CanCreateInstance()
		{
			return true;
		}

		// Token: 0x0600845D RID: 33885 RVA: 0x0010269C File Offset: 0x0010089C
		object IProtoTypeSerializer.CreateInstance(ProtoReader source)
		{
			return this.CreateInstance(source, false);
		}

		// Token: 0x0600845E RID: 33886 RVA: 0x001026B8 File Offset: 0x001008B8
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

		// Token: 0x0600845F RID: 33887 RVA: 0x00102708 File Offset: 0x00100908
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

		// Token: 0x06008460 RID: 33888 RVA: 0x001027BC File Offset: 0x001009BC
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

		// Token: 0x06008461 RID: 33889 RVA: 0x00102878 File Offset: 0x00100A78
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

		// Token: 0x06008462 RID: 33890 RVA: 0x00102A4C File Offset: 0x00100C4C
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

		// Token: 0x06008463 RID: 33891 RVA: 0x00102B20 File Offset: 0x00100D20
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

		// Token: 0x170029D7 RID: 10711
		// (get) Token: 0x06008464 RID: 33892 RVA: 0x00102C1C File Offset: 0x00100E1C
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170029D8 RID: 10712
		// (get) Token: 0x06008465 RID: 33893 RVA: 0x00102C30 File Offset: 0x00100E30
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x04002921 RID: 10529
		private readonly Type forType;

		// Token: 0x04002922 RID: 10530
		private readonly Type constructType;

		// Token: 0x04002923 RID: 10531
		private readonly IProtoSerializer[] serializers;

		// Token: 0x04002924 RID: 10532
		private readonly int[] fieldNumbers;

		// Token: 0x04002925 RID: 10533
		private readonly bool isRootType;

		// Token: 0x04002926 RID: 10534
		private readonly bool useConstructor;

		// Token: 0x04002927 RID: 10535
		private readonly bool isExtensible;

		// Token: 0x04002928 RID: 10536
		private readonly bool hasConstructor;

		// Token: 0x04002929 RID: 10537
		private readonly CallbackSet callbacks;

		// Token: 0x0400292A RID: 10538
		private readonly MethodInfo[] baseCtorCallbacks;

		// Token: 0x0400292B RID: 10539
		private readonly MethodInfo factory;

		// Token: 0x0400292C RID: 10540
		private static readonly Type iextensible = typeof(IExtensible);
	}
}
