using System;
using System.Reflection;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{

	internal sealed class TupleSerializer : IProtoTypeSerializer, IProtoSerializer
	{

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

		public bool HasCallbacks(TypeModel.CallbackType callbackType)
		{
			return false;
		}

		public Type ExpectedType
		{
			get
			{
				return this.ctor.DeclaringType;
			}
		}

		void IProtoTypeSerializer.Callback(object value, TypeModel.CallbackType callbackType, SerializationContext context)
		{
		}

		object IProtoTypeSerializer.CreateInstance(ProtoReader source)
		{
			throw new NotSupportedException();
		}

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

		public bool RequiresOldValue
		{
			get
			{
				return true;
			}
		}

		public bool ReturnsValue
		{
			get
			{
				return false;
			}
		}

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

		bool IProtoTypeSerializer.CanCreateInstance()
		{
			return false;
		}

		private readonly MemberInfo[] members;

		private readonly ConstructorInfo ctor;

		private IProtoSerializer[] tails;
	}
}
