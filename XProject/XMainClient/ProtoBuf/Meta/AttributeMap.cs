using System;
using System.Reflection;

namespace ProtoBuf.Meta
{
	// Token: 0x02000883 RID: 2179
	internal abstract class AttributeMap
	{
		// Token: 0x06008483 RID: 33923 RVA: 0x00102EA8 File Offset: 0x001010A8
		[Obsolete("Please use AttributeType instead")]
		public new Type GetType()
		{
			return this.AttributeType;
		}

		// Token: 0x06008484 RID: 33924
		public abstract bool TryGet(string key, bool publicOnly, out object value);

		// Token: 0x06008485 RID: 33925 RVA: 0x00102EC0 File Offset: 0x001010C0
		public bool TryGet(string key, out object value)
		{
			return this.TryGet(key, true, out value);
		}

		// Token: 0x170029E5 RID: 10725
		// (get) Token: 0x06008486 RID: 33926
		public abstract Type AttributeType { get; }

		// Token: 0x06008487 RID: 33927 RVA: 0x00102EDC File Offset: 0x001010DC
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

		// Token: 0x06008488 RID: 33928 RVA: 0x00102F28 File Offset: 0x00101128
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

		// Token: 0x06008489 RID: 33929 RVA: 0x00102F74 File Offset: 0x00101174
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

		// Token: 0x170029E6 RID: 10726
		// (get) Token: 0x0600848A RID: 33930
		public abstract object Target { get; }

		// Token: 0x02001942 RID: 6466
		private sealed class ReflectionAttributeMap : AttributeMap
		{
			// Token: 0x17003B32 RID: 15154
			// (get) Token: 0x06010FB0 RID: 69552 RVA: 0x00452358 File Offset: 0x00450558
			public override object Target
			{
				get
				{
					return this.attribute;
				}
			}

			// Token: 0x17003B33 RID: 15155
			// (get) Token: 0x06010FB1 RID: 69553 RVA: 0x00452370 File Offset: 0x00450570
			public override Type AttributeType
			{
				get
				{
					return this.attribute.GetType();
				}
			}

			// Token: 0x06010FB2 RID: 69554 RVA: 0x00452390 File Offset: 0x00450590
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

			// Token: 0x06010FB3 RID: 69555 RVA: 0x0045244B File Offset: 0x0045064B
			public ReflectionAttributeMap(Attribute attribute)
			{
				this.attribute = attribute;
			}

			// Token: 0x04007D65 RID: 32101
			private readonly Attribute attribute;
		}
	}
}
