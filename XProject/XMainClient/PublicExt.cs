using System;
using System.Collections.Generic;
using System.Reflection;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B33 RID: 2867
	public static class PublicExt
	{
		// Token: 0x0600A7C8 RID: 42952 RVA: 0x001DCC88 File Offset: 0x001DAE88
		public static List<Type[]> CastNumberParameters(object[] param, Type[] paramTypes)
		{
			PublicExt.ChangeToUlong(param, paramTypes);
			List<Type[]> list = new List<Type[]>();
			int num = 0;
			for (int i = 0; i < paramTypes.Length; i++)
			{
				bool flag = paramTypes[i] != null && paramTypes[i] == typeof(double);
				if (flag)
				{
					num++;
					Type[] array = new Type[paramTypes.Length];
					for (int j = 0; j < array.Length; j++)
					{
						bool flag2 = i == j;
						if (flag2)
						{
							array[j] = typeof(double);
						}
						else
						{
							array[j] = paramTypes[j];
						}
					}
					list.Add(array);
					array = new Type[paramTypes.Length];
					for (int k = 0; k < array.Length; k++)
					{
						bool flag3 = i == k;
						if (flag3)
						{
							array[k] = typeof(float);
						}
						else
						{
							array[k] = paramTypes[k];
						}
					}
					list.Add(array);
					array = new Type[paramTypes.Length];
					for (int l = 0; l < array.Length; l++)
					{
						bool flag4 = i == l;
						if (flag4)
						{
							array[l] = typeof(int);
						}
						else
						{
							array[l] = paramTypes[l];
						}
					}
					list.Add(array);
					array = new Type[paramTypes.Length];
					for (int m = 0; m < array.Length; m++)
					{
						bool flag5 = i == m;
						if (flag5)
						{
							array[m] = typeof(uint);
						}
						else
						{
							array[m] = paramTypes[m];
						}
					}
					list.Add(array);
				}
			}
			bool flag6 = num == 0;
			if (flag6)
			{
				list.Add(paramTypes);
				bool flag7 = paramTypes.Length == 1 && paramTypes[0] == typeof(string);
				if (flag7)
				{
					list.Add(new Type[0]);
				}
			}
			return list;
		}

		// Token: 0x0600A7C9 RID: 42953 RVA: 0x001DCE78 File Offset: 0x001DB078
		public static void ChangeToUlong(object[] param, Type[] paramTypes)
		{
			for (int i = 0; i < paramTypes.Length; i++)
			{
				bool flag = paramTypes[i] != null && paramTypes[i] == typeof(XLuaLong);
				if (flag)
				{
					paramTypes[i] = typeof(ulong);
					param[i] = ((XLuaLong)param[i]).Get();
				}
			}
		}

		// Token: 0x0600A7CA RID: 42954 RVA: 0x001DCEDC File Offset: 0x001DB0DC
		public static T CallPublicMethodGeneric<T>(this object obj, string name, params object[] param)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy;
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
					bool flag3 = param[k].GetType().IsSubclassOf(parameters[k].ParameterType);
					if (flag3)
					{
						array2[k] = param[k];
					}
					else
					{
						bool flag4 = parameters[k].ParameterType != typeof(object);
						if (flag4)
						{
							array2[k] = Convert.ChangeType(param[k], parameters[k].ParameterType);
						}
						else
						{
							array2[k] = param[k];
						}
					}
				}
				result = (T)((object)methodInfo.Invoke(obj, array2));
			}
			return result;
		}

		// Token: 0x0600A7CB RID: 42955 RVA: 0x001DD05C File Offset: 0x001DB25C
		public static object CallPublicMethod(this object obj, string name, params object[] param)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy;
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

		// Token: 0x0600A7CC RID: 42956 RVA: 0x001DD1F0 File Offset: 0x001DB3F0
		public static object CallStaticPublicMethod(string typeName, string name, params object[] param)
		{
			BindingFlags bindingAttr = BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy;
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
					bool flag3 = param[k].GetType().IsSubclassOf(parameters[k].ParameterType);
					if (flag3)
					{
						array2[k] = param[k];
					}
					else
					{
						bool flag4 = parameters[k].ParameterType != typeof(object);
						if (flag4)
						{
							array2[k] = Convert.ChangeType(param[k], parameters[k].ParameterType);
						}
						else
						{
							array2[k] = param[k];
						}
					}
				}
				result = methodInfo.Invoke(null, array2);
			}
			return result;
		}

		// Token: 0x0600A7CD RID: 42957 RVA: 0x001DD360 File Offset: 0x001DB560
		public static T GetPublicFieldGeneric<T>(this object obj, string name)
		{
			BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy;
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

		// Token: 0x0600A7CE RID: 42958 RVA: 0x001DD3AC File Offset: 0x001DB5AC
		public static object GetPublicField(this object obj, string name)
		{
			BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy;
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

		// Token: 0x0600A7CF RID: 42959 RVA: 0x001DD3E8 File Offset: 0x001DB5E8
		public static object GetStaticPublicField(string typeName, string name)
		{
			BindingFlags flags = BindingFlags.Static | BindingFlags.Public;
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

		// Token: 0x0600A7D0 RID: 42960 RVA: 0x001DD424 File Offset: 0x001DB624
		public static FieldInfo GetFieldInfo(Type type, string name, BindingFlags flags)
		{
			bool flag = type == null;
			FieldInfo result;
			if (flag)
			{
				result = null;
			}
			else
			{
				FieldInfo field = type.GetField(name, flags);
				bool flag2 = field == null && type.BaseType != null;
				if (flag2)
				{
					result = PublicExt.GetFieldInfo(type.BaseType, name, flags);
				}
				else
				{
					result = field;
				}
			}
			return result;
		}

		// Token: 0x0600A7D1 RID: 42961 RVA: 0x001DD470 File Offset: 0x001DB670
		public static T GetPublicPropertyGeneric<T>(this object obj, string name)
		{
			BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy;
			Type type = obj.GetType();
			PropertyInfo propertyInfo = PublicExt.GetPropertyInfo(type, name, flags);
			bool flag = propertyInfo != null;
			T result;
			if (flag)
			{
				result = (T)((object)propertyInfo.GetGetMethod(false).Invoke(obj, null));
			}
			else
			{
				result = default(T);
			}
			return result;
		}

		// Token: 0x0600A7D2 RID: 42962 RVA: 0x001DD4C0 File Offset: 0x001DB6C0
		public static object GetPublicProperty(this object obj, string name)
		{
			BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy;
			Type type = obj.GetType();
			PropertyInfo propertyInfo = PublicExt.GetPropertyInfo(type, name, flags);
			bool flag = propertyInfo != null;
			object result;
			if (flag)
			{
				result = propertyInfo.GetGetMethod(false).Invoke(obj, null);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600A7D3 RID: 42963 RVA: 0x001DD504 File Offset: 0x001DB704
		public static object GetStaticPublicProperty(string typeName, string name)
		{
			BindingFlags flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy;
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

		// Token: 0x0600A7D4 RID: 42964 RVA: 0x001DD540 File Offset: 0x001DB740
		public static PropertyInfo GetPropertyInfo(Type type, string name, BindingFlags flags)
		{
			bool flag = type == null;
			PropertyInfo result;
			if (flag)
			{
				result = null;
			}
			else
			{
				PropertyInfo property = type.GetProperty(name, flags);
				bool flag2 = property == null && type.BaseType != null;
				if (flag2)
				{
					result = PublicExt.GetPropertyInfo(type.BaseType, name, flags);
				}
				else
				{
					result = property;
				}
			}
			return result;
		}

		// Token: 0x0600A7D5 RID: 42965 RVA: 0x001DD58C File Offset: 0x001DB78C
		public static void SetPublicField(this object obj, string name, object value)
		{
			BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy;
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

		// Token: 0x0600A7D6 RID: 42966 RVA: 0x001DD690 File Offset: 0x001DB890
		public static void SetStaticPublicField(string typeName, string name, object value)
		{
			BindingFlags flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy;
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

		// Token: 0x0600A7D7 RID: 42967 RVA: 0x001DD794 File Offset: 0x001DB994
		public static void SetPublicProperty(this object obj, string name, object value)
		{
			BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy;
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

		// Token: 0x0600A7D8 RID: 42968 RVA: 0x001DD89C File Offset: 0x001DBA9C
		public static void SetStaticPublicProperty(string typeName, string name, object value)
		{
			BindingFlags flags = BindingFlags.Static | BindingFlags.Public;
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
