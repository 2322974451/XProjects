using System;
using System.Reflection;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000873 RID: 2163
	internal sealed class PropertyDecorator : ProtoDecoratorBase
	{
		// Token: 0x170029B3 RID: 10675
		// (get) Token: 0x060083F8 RID: 33784 RVA: 0x001012EC File Offset: 0x000FF4EC
		public override Type ExpectedType
		{
			get
			{
				return this.forType;
			}
		}

		// Token: 0x170029B4 RID: 10676
		// (get) Token: 0x060083F9 RID: 33785 RVA: 0x00101304 File Offset: 0x000FF504
		public override bool RequiresOldValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170029B5 RID: 10677
		// (get) Token: 0x060083FA RID: 33786 RVA: 0x00101318 File Offset: 0x000FF518
		public override bool ReturnsValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060083FB RID: 33787 RVA: 0x0010132C File Offset: 0x000FF52C
		public PropertyDecorator(TypeModel model, Type forType, PropertyInfo property, IProtoSerializer tail) : base(tail)
		{
			Helpers.DebugAssert(forType != null);
			Helpers.DebugAssert(property != null);
			this.forType = forType;
			this.property = property;
			PropertyDecorator.SanityCheck(model, property, tail, out this.readOptionsWriteValue, true, true);
			this.shadowSetter = PropertyDecorator.GetShadowSetter(model, property);
		}

		// Token: 0x060083FC RID: 33788 RVA: 0x00101384 File Offset: 0x000FF584
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

		// Token: 0x060083FD RID: 33789 RVA: 0x00101448 File Offset: 0x000FF648
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

		// Token: 0x060083FE RID: 33790 RVA: 0x001014BC File Offset: 0x000FF6BC
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

		// Token: 0x060083FF RID: 33791 RVA: 0x001014FC File Offset: 0x000FF6FC
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

		// Token: 0x06008400 RID: 33792 RVA: 0x00101598 File Offset: 0x000FF798
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

		// Token: 0x04002905 RID: 10501
		private readonly PropertyInfo property;

		// Token: 0x04002906 RID: 10502
		private readonly Type forType;

		// Token: 0x04002907 RID: 10503
		private readonly bool readOptionsWriteValue;

		// Token: 0x04002908 RID: 10504
		private readonly MethodInfo shadowSetter;
	}
}
