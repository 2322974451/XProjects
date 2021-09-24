using System;
using System.Reflection;

namespace ProtoBuf.Meta
{

	internal abstract class AttributeMap
	{

		[Obsolete("Please use AttributeType instead")]
		public new Type GetType()
		{
			return this.AttributeType;
		}

		public abstract bool TryGet(string key, bool publicOnly, out object value);

		public bool TryGet(string key, out object value)
		{
			return this.TryGet(key, true, out value);
		}

		public abstract Type AttributeType { get; }

		public static AttributeMap[] Create(TypeModel model, Type type, bool inherit)
		{
			object[] customAttributes = type.GetCustomAttributes(inherit);
			AttributeMap[] array = new AttributeMap[customAttributes.Length];
			for (int i = 0; i < customAttributes.Length; i++)
			{
				array[i] = new AttributeMap.ReflectionAttributeMap((Attribute)customAttributes[i]);
			}
			return array;
		}

		public static AttributeMap[] Create(TypeModel model, MemberInfo member, bool inherit)
		{
			object[] customAttributes = member.GetCustomAttributes(inherit);
			AttributeMap[] array = new AttributeMap[customAttributes.Length];
			for (int i = 0; i < customAttributes.Length; i++)
			{
				array[i] = new AttributeMap.ReflectionAttributeMap((Attribute)customAttributes[i]);
			}
			return array;
		}

		public static AttributeMap[] Create(TypeModel model, Assembly assembly)
		{
			object[] customAttributes = assembly.GetCustomAttributes(false);
			AttributeMap[] array = new AttributeMap[customAttributes.Length];
			for (int i = 0; i < customAttributes.Length; i++)
			{
				array[i] = new AttributeMap.ReflectionAttributeMap((Attribute)customAttributes[i]);
			}
			return array;
		}

		public abstract object Target { get; }

		private sealed class ReflectionAttributeMap : AttributeMap
		{

			public override object Target
			{
				get
				{
					return this.attribute;
				}
			}

			public override Type AttributeType
			{
				get
				{
					return this.attribute.GetType();
				}
			}

			public override bool TryGet(string key, bool publicOnly, out object value)
			{
				foreach (MemberInfo memberInfo in Helpers.GetInstanceFieldsAndProperties(this.attribute.GetType(), publicOnly))
				{
					bool flag = string.Equals(memberInfo.Name, key, StringComparison.OrdinalIgnoreCase);
					if (flag)
					{
						PropertyInfo propertyInfo = memberInfo as PropertyInfo;
						bool flag2 = propertyInfo != null;
						bool result;
						if (flag2)
						{
							value = propertyInfo.GetValue(this.attribute, null);
							result = true;
						}
						else
						{
							FieldInfo fieldInfo = memberInfo as FieldInfo;
							bool flag3 = fieldInfo != null;
							if (!flag3)
							{
								throw new NotSupportedException(memberInfo.GetType().Name);
							}
							value = fieldInfo.GetValue(this.attribute);
							result = true;
						}
						return result;
					}
				}
				value = null;
				return false;
			}

			public ReflectionAttributeMap(Attribute attribute)
			{
				this.attribute = attribute;
			}

			private readonly Attribute attribute;
		}
	}
}
