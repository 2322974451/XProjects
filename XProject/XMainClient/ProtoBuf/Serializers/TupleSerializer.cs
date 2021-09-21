using System;
using System.Reflection;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x0200087D RID: 2173
	internal sealed class TupleSerializer : IProtoTypeSerializer, IProtoSerializer
	{
		// Token: 0x0600844C RID: 33868 RVA: 0x00101FB0 File Offset: 0x001001B0
		public TupleSerializer(RuntimeTypeModel model, ConstructorInfo ctor, MemberInfo[] members)
		{
			bool flag = ctor == null;
			if (flag)
			{
				throw new ArgumentNullException("ctor");
			}
			bool flag2 = members == null;
			if (flag2)
			{
				throw new ArgumentNullException("members");
			}
			this.ctor = ctor;
			this.members = members;
			this.tails = new IProtoSerializer[members.Length];
			ParameterInfo[] parameters = ctor.GetParameters();
			for (int i = 0; i < members.Length; i++)
			{
				Type parameterType = parameters[i].ParameterType;
				Type type = null;
				Type concreteType = null;
				MetaType.ResolveListTypes(model, parameterType, ref type, ref concreteType);
				Type type2 = (type == null) ? parameterType : type;
				bool asReference = false;
				int num = model.FindOrAddAuto(type2, false, true, false);
				bool flag3 = num >= 0;
				if (flag3)
				{
					asReference = model[type2].AsReferenceDefault;
				}
				WireType wireType;
				IProtoSerializer protoSerializer = ValueMember.TryGetCoreSerializer(model, DataFormat.Default, type2, out wireType, asReference, false, false, true);
				bool flag4 = protoSerializer == null;
				if (flag4)
				{
					throw new InvalidOperationException("No serializer defined for type: " + type2.FullName);
				}
				protoSerializer = new TagDecorator(i + 1, wireType, false, protoSerializer);
				bool flag5 = type == null;
				IProtoSerializer protoSerializer2;
				if (flag5)
				{
					protoSerializer2 = protoSerializer;
				}
				else
				{
					bool isArray = parameterType.IsArray;
					if (isArray)
					{
						protoSerializer2 = new ArrayDecorator(model, protoSerializer, i + 1, false, wireType, parameterType, false, false);
					}
					else
					{
						protoSerializer2 = ListDecorator.Create(model, parameterType, concreteType, protoSerializer, i + 1, false, wireType, true, false, false);
					}
				}
				this.tails[i] = protoSerializer2;
			}
		}

		// Token: 0x0600844D RID: 33869 RVA: 0x00102124 File Offset: 0x00100324
		public bool HasCallbacks(TypeModel.CallbackType callbackType)
		{
			return false;
		}

		// Token: 0x170029D2 RID: 10706
		// (get) Token: 0x0600844E RID: 33870 RVA: 0x00102138 File Offset: 0x00100338
		public Type ExpectedType
		{
			get
			{
				return this.ctor.DeclaringType;
			}
		}

		// Token: 0x0600844F RID: 33871 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		void IProtoTypeSerializer.Callback(object value, TypeModel.CallbackType callbackType, SerializationContext context)
		{
		}

		// Token: 0x06008450 RID: 33872 RVA: 0x00101967 File Offset: 0x000FFB67
		object IProtoTypeSerializer.CreateInstance(ProtoReader source)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06008451 RID: 33873 RVA: 0x00102158 File Offset: 0x00100358
		private object GetValue(object obj, int index)
		{
			PropertyInfo propertyInfo;
			bool flag = (propertyInfo = (this.members[index] as PropertyInfo)) != null;
			object result;
			if (flag)
			{
				bool flag2 = obj == null;
				if (flag2)
				{
					result = (Helpers.IsValueType(propertyInfo.PropertyType) ? Activator.CreateInstance(propertyInfo.PropertyType) : null);
				}
				else
				{
					result = propertyInfo.GetValue(obj, null);
				}
			}
			else
			{
				FieldInfo fieldInfo;
				bool flag3 = (fieldInfo = (this.members[index] as FieldInfo)) != null;
				if (!flag3)
				{
					throw new InvalidOperationException();
				}
				bool flag4 = obj == null;
				if (flag4)
				{
					result = (Helpers.IsValueType(fieldInfo.FieldType) ? Activator.CreateInstance(fieldInfo.FieldType) : null);
				}
				else
				{
					result = fieldInfo.GetValue(obj);
				}
			}
			return result;
		}

		// Token: 0x06008452 RID: 33874 RVA: 0x00102208 File Offset: 0x00100408
		public object Read(object value, ProtoReader source)
		{
			object[] array = new object[this.members.Length];
			bool flag = false;
			bool flag2 = value == null;
			if (flag2)
			{
				flag = true;
			}
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = this.GetValue(value, i);
			}
			int num;
			while ((num = source.ReadFieldHeader()) > 0)
			{
				flag = true;
				bool flag3 = num <= this.tails.Length;
				if (flag3)
				{
					IProtoSerializer protoSerializer = this.tails[num - 1];
					array[num - 1] = this.tails[num - 1].Read(protoSerializer.RequiresOldValue ? array[num - 1] : null, source);
				}
				else
				{
					source.SkipField();
				}
			}
			return flag ? this.ctor.Invoke(array) : value;
		}

		// Token: 0x06008453 RID: 33875 RVA: 0x001022DC File Offset: 0x001004DC
		public void Write(object value, ProtoWriter dest)
		{
			for (int i = 0; i < this.tails.Length; i++)
			{
				object value2 = this.GetValue(value, i);
				bool flag = value2 != null;
				if (flag)
				{
					this.tails[i].Write(value2, dest);
				}
			}
		}

		// Token: 0x170029D3 RID: 10707
		// (get) Token: 0x06008454 RID: 33876 RVA: 0x00102324 File Offset: 0x00100524
		public bool RequiresOldValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170029D4 RID: 10708
		// (get) Token: 0x06008455 RID: 33877 RVA: 0x00102338 File Offset: 0x00100538
		public bool ReturnsValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06008456 RID: 33878 RVA: 0x0010234C File Offset: 0x0010054C
		private Type GetMemberType(int index)
		{
			Type memberType = Helpers.GetMemberType(this.members[index]);
			bool flag = memberType == null;
			if (flag)
			{
				throw new InvalidOperationException();
			}
			return memberType;
		}

		// Token: 0x06008457 RID: 33879 RVA: 0x0010237C File Offset: 0x0010057C
		bool IProtoTypeSerializer.CanCreateInstance()
		{
			return false;
		}

		// Token: 0x0400291E RID: 10526
		private readonly MemberInfo[] members;

		// Token: 0x0400291F RID: 10527
		private readonly ConstructorInfo ctor;

		// Token: 0x04002920 RID: 10528
		private IProtoSerializer[] tails;
	}
}
