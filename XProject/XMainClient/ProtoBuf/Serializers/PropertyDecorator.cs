using System;
using System.Reflection;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{

	internal sealed class PropertyDecorator : ProtoDecoratorBase
	{

		public override Type ExpectedType
		{
			get
			{
				return this.forType;
			}
		}

		public override bool RequiresOldValue
		{
			get
			{
				return true;
			}
		}

		public override bool ReturnsValue
		{
			get
			{
				return false;
			}
		}

		public PropertyDecorator(TypeModel model, Type forType, PropertyInfo property, IProtoSerializer tail) : base(tail)
		{
			Helpers.DebugAssert(forType != null);
			Helpers.DebugAssert(property != null);
			this.forType = forType;
			this.property = property;
			PropertyDecorator.SanityCheck(model, property, tail, out this.readOptionsWriteValue, true, true);
			this.shadowSetter = PropertyDecorator.GetShadowSetter(model, property);
		}

		private static void SanityCheck(TypeModel model, PropertyInfo property, IProtoSerializer tail, out bool writeValue, bool nonPublic, bool allowInternal)
		{
			bool flag = property == null;
			if (flag)
			{
				throw new ArgumentNullException("property");
			}
			writeValue = (tail.ReturnsValue && (PropertyDecorator.GetShadowSetter(model, property) != null || (property.CanWrite && Helpers.GetSetMethod(property, nonPublic, allowInternal) != null)));
			bool flag2 = !property.CanRead || Helpers.GetGetMethod(property, nonPublic, allowInternal) == null;
			if (flag2)
			{
				throw new InvalidOperationException("Cannot serialize property without a get accessor");
			}
			bool flag3 = !writeValue && (!tail.RequiresOldValue || Helpers.IsValueType(tail.ExpectedType));
			if (flag3)
			{
				throw new InvalidOperationException("Cannot apply changes to property " + property.DeclaringType.FullName + "." + property.Name);
			}
		}

		private static MethodInfo GetShadowSetter(TypeModel model, PropertyInfo property)
		{
			Type reflectedType = property.ReflectedType;
			ProtoDecoratorBase.s_propertyType[0] = property.PropertyType;
			MethodInfo instanceMethod = Helpers.GetInstanceMethod(reflectedType, "Set" + property.Name, ProtoDecoratorBase.s_propertyType);
			bool flag = instanceMethod == null || !instanceMethod.IsPublic || instanceMethod.ReturnType != model.MapType(typeof(void));
			MethodInfo result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = instanceMethod;
			}
			return result;
		}

		public override void Write(object value, ProtoWriter dest)
		{
			Helpers.DebugAssert(value != null);
			value = this.property.GetValue(value, null);
			bool flag = value != null;
			if (flag)
			{
				this.Tail.Write(value, dest);
			}
		}

		public override object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value != null);
			object value2 = this.Tail.RequiresOldValue ? this.property.GetValue(value, null) : null;
			object obj = this.Tail.Read(value2, source);
			bool flag = this.readOptionsWriteValue && obj != null;
			if (flag)
			{
				bool flag2 = this.shadowSetter == null;
				if (flag2)
				{
					this.property.SetValue(value, obj, null);
				}
				else
				{
					ProtoDecoratorBase.s_argsRead[0] = obj;
					this.shadowSetter.Invoke(value, ProtoDecoratorBase.s_argsRead);
				}
			}
			return null;
		}

		internal static bool CanWrite(TypeModel model, MemberInfo member)
		{
			bool flag = member == null;
			if (flag)
			{
				throw new ArgumentNullException("member");
			}
			PropertyInfo propertyInfo = member as PropertyInfo;
			bool flag2 = propertyInfo != null;
			bool result;
			if (flag2)
			{
				result = (propertyInfo.CanWrite || PropertyDecorator.GetShadowSetter(model, propertyInfo) != null);
			}
			else
			{
				result = (member is FieldInfo);
			}
			return result;
		}

		private readonly PropertyInfo property;

		private readonly Type forType;

		private readonly bool readOptionsWriteValue;

		private readonly MethodInfo shadowSetter;
	}
}
