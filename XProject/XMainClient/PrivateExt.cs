using System;
using System.Collections.Generic;
using System.Reflection;

namespace XMainClient
{
	// Token: 0x02000B32 RID: 2866
	public static class PrivateExt
	{
		// Token: 0x0600A7BB RID: 42939 RVA: 0x001DC2B0 File Offset: 0x001DA4B0
		public static T CallPrivateMethodGeneric<T>(this object obj, string name, params object[] param)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
			Type type = obj.GetType();
			Type[] array = new Type[param.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = param[i].GetType();
			}
			List<Type[]> list = PublicExt.CastNumberParameters(param, array);
			MethodInfo methodInfo = null;
			try
			{
				methodInfo = type.GetMethod(name, bindingAttr);
			}
			catch
			{
				for (int j = 0; j < list.Count; j++)
				{
					methodInfo = type.GetMethod(name, list[j]);
					bool flag = methodInfo != null;
					if (flag)
					{
						break;
					}
				}
			}
			bool flag2 = methodInfo == null;
			T result;
			if (flag2)
			{
				result = default(T);
			}
			else
			{
				ParameterInfo[] parameters = methodInfo.GetParameters();
				object[] array2 = new object[parameters.Length];
				for (int k = 0; k < parameters.Length; k++)
				{
					bool flag3 = parameters[k].ParameterType != typeof(object);
					if (flag3)
					{
						array2[k] = Convert.ChangeType(param[k], parameters[k].ParameterType);
					}
					else
					{
						array2[k] = param[k];
					}
				}
				result = (T)((object)methodInfo.Invoke(obj, array2));
			}
			return result;
		}

		// Token: 0x0600A7BC RID: 42940 RVA: 0x001DC404 File Offset: 0x001DA604
		public static object CallPrivateMethod(this object obj, string name, params object[] param)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
			Type type = obj.GetType();
			Type[] array = new Type[param.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = param[i].GetType();
			}
			List<Type[]> list = PublicExt.CastNumberParameters(param, array);
			MethodInfo methodInfo = null;
			try
			{
				methodInfo = type.GetMethod(name, bindingAttr);
			}
			catch
			{
				for (int j = 0; j < list.Count; j++)
				{
					methodInfo = type.GetMethod(name, bindingAttr, null, list[j], null);
					bool flag = methodInfo != null;
					if (flag)
					{
						break;
					}
				}
			}
			bool flag2 = methodInfo == null;
			object result;
			if (flag2)
			{
				result = null;
			}
			else
			{
				ParameterInfo[] parameters = methodInfo.GetParameters();
				object[] array2 = new object[parameters.Length];
				for (int k = 0; k < parameters.Length; k++)
				{
					bool flag3 = k < param.Length;
					if (flag3)
					{
						bool flag4 = param[k].GetType().IsSubclassOf(parameters[k].ParameterType);
						if (flag4)
						{
							array2[k] = param[k];
						}
						else
						{
							bool flag5 = parameters[k].ParameterType != typeof(object);
							if (flag5)
							{
								array2[k] = Convert.ChangeType(param[k], parameters[k].ParameterType);
							}
							else
							{
								array2[k] = param[k];
							}
						}
					}
					else
					{
						array2[k] = parameters[k].DefaultValue;
					}
				}
				result = methodInfo.Invoke(obj, array2);
			}
			return result;
		}

		// Token: 0x0600A7BD RID: 42941 RVA: 0x001DC59C File Offset: 0x001DA79C
		public static object CallStaticPrivateMethod(string typeName, string name, params object[] param)
		{
			BindingFlags bindingAttr = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
			Type type = Type.GetType(typeName);
			Type[] array = new Type[param.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = param[i].GetType();
			}
			List<Type[]> list = PublicExt.CastNumberParameters(param, array);
			MethodInfo methodInfo = null;
			try
			{
				methodInfo = type.GetMethod(name, bindingAttr);
			}
			catch
			{
				for (int j = 0; j < list.Count; j++)
				{
					methodInfo = type.GetMethod(name, list[j]);
					bool flag = methodInfo != null;
					if (flag)
					{
						break;
					}
				}
			}
			bool flag2 = methodInfo == null;
			object result;
			if (flag2)
			{
				result = null;
			}
			else
			{
				ParameterInfo[] parameters = methodInfo.GetParameters();
				object[] array2 = new object[parameters.Length];
				for (int k = 0; k < parameters.Length; k++)
				{
					bool flag3 = parameters[k].ParameterType != typeof(object);
					if (flag3)
					{
						array2[k] = Convert.ChangeType(param[k], parameters[k].ParameterType);
					}
					else
					{
						array2[k] = param[k];
					}
				}
				result = methodInfo.Invoke(null, array2);
			}
			return result;
		}

		// Token: 0x0600A7BE RID: 42942 RVA: 0x001DC6DC File Offset: 0x001DA8DC
		public static T GetPrivateFieldGeneric<T>(this object obj, string name)
		{
			BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
			Type type = obj.GetType();
			FieldInfo fieldInfo = PublicExt.GetFieldInfo(type, name, flags);
			bool flag = fieldInfo != null;
			T result;
			if (flag)
			{
				result = (T)((object)fieldInfo.GetValue(obj));
			}
			else
			{
				result = default(T);
			}
			return result;
		}

		// Token: 0x0600A7BF RID: 42943 RVA: 0x001DC728 File Offset: 0x001DA928
		public static object GetPrivateField(this object obj, string name)
		{
			BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
			Type type = obj.GetType();
			FieldInfo fieldInfo = PublicExt.GetFieldInfo(type, name, flags);
			bool flag = fieldInfo != null;
			object result;
			if (flag)
			{
				result = fieldInfo.GetValue(obj);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600A7C0 RID: 42944 RVA: 0x001DC764 File Offset: 0x001DA964
		public static object GetStaticPrivateField(string typeName, string name)
		{
			BindingFlags flags = BindingFlags.Static | BindingFlags.NonPublic;
			Type type = Type.GetType(typeName);
			FieldInfo fieldInfo = PublicExt.GetFieldInfo(type, name, flags);
			bool flag = fieldInfo != null;
			object result;
			if (flag)
			{
				result = fieldInfo.GetValue(null);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600A7C1 RID: 42945 RVA: 0x001DC7A0 File Offset: 0x001DA9A0
		public static T GetPrivatePropertyGeneric<T>(this object obj, string name)
		{
			BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
			Type type = obj.GetType();
			PropertyInfo propertyInfo = PublicExt.GetPropertyInfo(type, name, flags);
			bool flag = propertyInfo != null;
			T result;
			if (flag)
			{
				result = (T)((object)propertyInfo.GetGetMethod(true).Invoke(obj, null));
			}
			else
			{
				result = default(T);
			}
			return result;
		}

		// Token: 0x0600A7C2 RID: 42946 RVA: 0x001DC7F0 File Offset: 0x001DA9F0
		public static object GetPrivateProperty(this object obj, string name)
		{
			BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
			Type type = obj.GetType();
			PropertyInfo propertyInfo = PublicExt.GetPropertyInfo(type, name, flags);
			bool flag = propertyInfo != null;
			object result;
			if (flag)
			{
				result = propertyInfo.GetGetMethod(true).Invoke(obj, null);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600A7C3 RID: 42947 RVA: 0x001DC834 File Offset: 0x001DAA34
		public static object GetStaticPrivateProperty(string typeName, string name)
		{
			BindingFlags flags = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
			Type type = Type.GetType(typeName);
			PropertyInfo propertyInfo = PublicExt.GetPropertyInfo(type, name, flags);
			bool flag = propertyInfo != null;
			object result;
			if (flag)
			{
				result = propertyInfo.GetValue(null, null);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600A7C4 RID: 42948 RVA: 0x001DC870 File Offset: 0x001DAA70
		public static void SetPrivateField(this object obj, string name, object value)
		{
			BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
			Type type = obj.GetType();
			FieldInfo fieldInfo = PublicExt.GetFieldInfo(type, name, flags);
			bool flag = fieldInfo != null;
			if (flag)
			{
				bool flag2 = fieldInfo.FieldType == typeof(int);
				if (flag2)
				{
					int num = Convert.ToInt32(value);
					fieldInfo.SetValue(obj, num);
				}
				else
				{
					bool flag3 = fieldInfo.FieldType == typeof(float);
					if (flag3)
					{
						float num2 = Convert.ToSingle(value);
						fieldInfo.SetValue(obj, num2);
					}
					else
					{
						bool flag4 = fieldInfo.FieldType == typeof(long);
						if (flag4)
						{
							long num3 = Convert.ToInt64(value);
							fieldInfo.SetValue(obj, num3);
						}
						else
						{
							bool flag5 = fieldInfo.FieldType == typeof(uint);
							if (flag5)
							{
								uint num4 = Convert.ToUInt32(value);
								fieldInfo.SetValue(obj, num4);
							}
							else
							{
								fieldInfo.SetValue(obj, value);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600A7C5 RID: 42949 RVA: 0x001DC974 File Offset: 0x001DAB74
		public static void SetStaticPrivateField(string typeName, string name, object value)
		{
			BindingFlags flags = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
			Type type = Type.GetType(typeName);
			FieldInfo fieldInfo = PublicExt.GetFieldInfo(type, name, flags);
			bool flag = fieldInfo != null;
			if (flag)
			{
				bool flag2 = fieldInfo.FieldType == typeof(int);
				if (flag2)
				{
					int num = Convert.ToInt32(value);
					fieldInfo.SetValue(null, num);
				}
				else
				{
					bool flag3 = fieldInfo.FieldType == typeof(float);
					if (flag3)
					{
						float num2 = Convert.ToSingle(value);
						fieldInfo.SetValue(null, num2);
					}
					else
					{
						bool flag4 = fieldInfo.FieldType == typeof(long);
						if (flag4)
						{
							long num3 = Convert.ToInt64(value);
							fieldInfo.SetValue(null, num3);
						}
						else
						{
							bool flag5 = fieldInfo.FieldType == typeof(uint);
							if (flag5)
							{
								uint num4 = Convert.ToUInt32(value);
								fieldInfo.SetValue(null, num4);
							}
							else
							{
								fieldInfo.SetValue(null, value);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600A7C6 RID: 42950 RVA: 0x001DCA78 File Offset: 0x001DAC78
		public static void SetPrivateProperty(this object obj, string name, object value)
		{
			BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
			Type type = obj.GetType();
			PropertyInfo propertyInfo = PublicExt.GetPropertyInfo(type, name, flags);
			bool flag = propertyInfo != null;
			if (flag)
			{
				bool flag2 = propertyInfo.PropertyType == typeof(int);
				if (flag2)
				{
					int num = Convert.ToInt32(value);
					propertyInfo.SetValue(obj, num, null);
				}
				else
				{
					bool flag3 = propertyInfo.PropertyType == typeof(float);
					if (flag3)
					{
						float num2 = Convert.ToSingle(value);
						propertyInfo.SetValue(obj, num2, null);
					}
					else
					{
						bool flag4 = propertyInfo.PropertyType == typeof(long);
						if (flag4)
						{
							long num3 = Convert.ToInt64(value);
							propertyInfo.SetValue(obj, num3, null);
						}
						else
						{
							bool flag5 = propertyInfo.PropertyType == typeof(uint);
							if (flag5)
							{
								uint num4 = Convert.ToUInt32(value);
								propertyInfo.SetValue(obj, num4, null);
							}
							else
							{
								propertyInfo.SetValue(obj, value, null);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600A7C7 RID: 42951 RVA: 0x001DCB80 File Offset: 0x001DAD80
		public static void SetStaticPrivateProperty(string typeName, string name, object value)
		{
			BindingFlags flags = BindingFlags.Static | BindingFlags.NonPublic;
			Type type = Type.GetType(typeName);
			PropertyInfo propertyInfo = PublicExt.GetPropertyInfo(type, name, flags);
			bool flag = propertyInfo != null;
			if (flag)
			{
				bool flag2 = propertyInfo.PropertyType == typeof(int);
				if (flag2)
				{
					int num = Convert.ToInt32(value);
					propertyInfo.SetValue(null, num, null);
				}
				else
				{
					bool flag3 = propertyInfo.PropertyType == typeof(float);
					if (flag3)
					{
						float num2 = Convert.ToSingle(value);
						propertyInfo.SetValue(null, num2, null);
					}
					else
					{
						bool flag4 = propertyInfo.PropertyType == typeof(long);
						if (flag4)
						{
							long num3 = Convert.ToInt64(value);
							propertyInfo.SetValue(null, num3, null);
						}
						else
						{
							bool flag5 = propertyInfo.PropertyType == typeof(uint);
							if (flag5)
							{
								uint num4 = Convert.ToUInt32(value);
								propertyInfo.SetValue(null, num4, null);
							}
							else
							{
								propertyInfo.SetValue(null, value, null);
							}
						}
					}
				}
			}
		}
	}
}
