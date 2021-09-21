using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace ProtoBuf
{
	// Token: 0x02000844 RID: 2116
	internal sealed class Helpers
	{
		// Token: 0x06008248 RID: 33352 RVA: 0x0000311A File Offset: 0x0000131A
		private Helpers()
		{
		}

		// Token: 0x06008249 RID: 33353 RVA: 0x000F9F50 File Offset: 0x000F8150
		public static StringBuilder AppendLine(StringBuilder builder)
		{
			return builder.AppendLine();
		}

		// Token: 0x0600824A RID: 33354 RVA: 0x000F9F68 File Offset: 0x000F8168
		public static bool IsNullOrEmpty(string value)
		{
			return value == null || value.Length == 0;
		}

		// Token: 0x0600824B RID: 33355 RVA: 0x000F9F8C File Offset: 0x000F818C
		[Conditional("DEBUG")]
		public static void DebugWriteLine(string message, object obj)
		{
			string str;
			try
			{
				str = ((obj == null) ? "(null)" : obj.ToString());
			}
			catch
			{
				str = "(exception)";
			}
			Helpers.DebugWriteLine(message + ": " + str);
		}

		// Token: 0x0600824C RID: 33356 RVA: 0x000F9FDC File Offset: 0x000F81DC
		[Conditional("DEBUG")]
		public static void DebugWriteLine(string message)
		{
			Debug.WriteLine(message);
		}

		// Token: 0x0600824D RID: 33357 RVA: 0x000F9FE6 File Offset: 0x000F81E6
		[Conditional("TRACE")]
		public static void TraceWriteLine(string message)
		{
			Trace.WriteLine(message);
		}

		// Token: 0x0600824E RID: 33358 RVA: 0x000F9FF0 File Offset: 0x000F81F0
		[Conditional("DEBUG")]
		public static void DebugAssert(bool condition, string message)
		{
			bool flag = !condition;
			if (flag)
			{
				Debug.Assert(false, message);
			}
		}

		// Token: 0x0600824F RID: 33359 RVA: 0x000FA010 File Offset: 0x000F8210
		[Conditional("DEBUG")]
		public static void DebugAssert(bool condition, string message, params object[] args)
		{
			bool flag = !condition;
			if (flag)
			{
				Helpers.DebugAssert(false, string.Format(message, args));
			}
		}

		// Token: 0x06008250 RID: 33360 RVA: 0x000FA034 File Offset: 0x000F8234
		[Conditional("DEBUG")]
		public static void DebugAssert(bool condition)
		{
			bool flag = !condition && Debugger.IsAttached;
			if (flag)
			{
				Debugger.Break();
			}
			Debug.Assert(condition);
		}

		// Token: 0x06008251 RID: 33361 RVA: 0x000FA060 File Offset: 0x000F8260
		public static void Sort(int[] keys, object[] values)
		{
			bool flag;
			do
			{
				flag = false;
				for (int i = 1; i < keys.Length; i++)
				{
					bool flag2 = keys[i - 1] > keys[i];
					if (flag2)
					{
						int num = keys[i];
						keys[i] = keys[i - 1];
						keys[i - 1] = num;
						object obj = values[i];
						values[i] = values[i - 1];
						values[i - 1] = obj;
						flag = true;
					}
				}
			}
			while (flag);
		}

		// Token: 0x06008252 RID: 33362 RVA: 0x000FA0C7 File Offset: 0x000F82C7
		public static void BlockCopy(byte[] from, int fromIndex, byte[] to, int toIndex, int count)
		{
			Buffer.BlockCopy(from, fromIndex, to, toIndex, count);
		}

		// Token: 0x06008253 RID: 33363 RVA: 0x000FA0D8 File Offset: 0x000F82D8
		public static bool IsInfinity(float value)
		{
			return float.IsInfinity(value);
		}

		// Token: 0x06008254 RID: 33364 RVA: 0x000FA0F0 File Offset: 0x000F82F0
		internal static MethodInfo GetInstanceMethod(Type declaringType, string name)
		{
			return declaringType.GetMethod(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		}

		// Token: 0x06008255 RID: 33365 RVA: 0x000FA10C File Offset: 0x000F830C
		internal static MethodInfo GetStaticMethod(Type declaringType, string name)
		{
			return declaringType.GetMethod(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		// Token: 0x06008256 RID: 33366 RVA: 0x000FA128 File Offset: 0x000F8328
		internal static MethodInfo GetInstanceMethod(Type declaringType, string name, Type[] types)
		{
			bool flag = types == null;
			if (flag)
			{
				types = Helpers.EmptyTypes;
			}
			return declaringType.GetMethod(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, types, null);
		}

		// Token: 0x06008257 RID: 33367 RVA: 0x000FA158 File Offset: 0x000F8358
		internal static bool IsSubclassOf(Type type, Type baseClass)
		{
			return type.IsSubclassOf(baseClass);
		}

		// Token: 0x06008258 RID: 33368 RVA: 0x000FA174 File Offset: 0x000F8374
		public static bool IsInfinity(double value)
		{
			return double.IsInfinity(value);
		}

		// Token: 0x06008259 RID: 33369 RVA: 0x000FA18C File Offset: 0x000F838C
		public static ProtoTypeCode GetTypeCode(Type type)
		{
			TypeCode typeCode = Type.GetTypeCode(type);
			switch (typeCode)
			{
			case TypeCode.Empty:
			case TypeCode.Boolean:
			case TypeCode.Char:
			case TypeCode.SByte:
			case TypeCode.Byte:
			case TypeCode.Int16:
			case TypeCode.UInt16:
			case TypeCode.Int32:
			case TypeCode.UInt32:
			case TypeCode.Int64:
			case TypeCode.UInt64:
			case TypeCode.Single:
			case TypeCode.Double:
			case TypeCode.Decimal:
			case TypeCode.DateTime:
			case TypeCode.String:
				return (ProtoTypeCode)typeCode;
			}
			bool flag = type == typeof(TimeSpan);
			ProtoTypeCode result;
			if (flag)
			{
				result = ProtoTypeCode.TimeSpan;
			}
			else
			{
				bool flag2 = type == typeof(Guid);
				if (flag2)
				{
					result = ProtoTypeCode.Guid;
				}
				else
				{
					bool flag3 = type == typeof(Uri);
					if (flag3)
					{
						result = ProtoTypeCode.Uri;
					}
					else
					{
						bool flag4 = type == typeof(byte[]);
						if (flag4)
						{
							result = ProtoTypeCode.ByteArray;
						}
						else
						{
							bool flag5 = type == typeof(Type);
							if (flag5)
							{
								result = ProtoTypeCode.Type;
							}
							else
							{
								result = ProtoTypeCode.Unknown;
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600825A RID: 33370 RVA: 0x000FA278 File Offset: 0x000F8478
		internal static Type GetUnderlyingType(Type type)
		{
			return Nullable.GetUnderlyingType(type);
		}

		// Token: 0x0600825B RID: 33371 RVA: 0x000FA290 File Offset: 0x000F8490
		internal static bool IsValueType(Type type)
		{
			return type.IsValueType;
		}

		// Token: 0x0600825C RID: 33372 RVA: 0x000FA2A8 File Offset: 0x000F84A8
		internal static bool IsEnum(Type type)
		{
			return type.IsEnum;
		}

		// Token: 0x0600825D RID: 33373 RVA: 0x000FA2C0 File Offset: 0x000F84C0
		internal static MethodInfo GetGetMethod(PropertyInfo property, bool nonPublic, bool allowInternal)
		{
			bool flag = property == null;
			MethodInfo result;
			if (flag)
			{
				result = null;
			}
			else
			{
				MethodInfo methodInfo = property.GetGetMethod(nonPublic);
				bool flag2 = methodInfo == null && !nonPublic && allowInternal;
				if (flag2)
				{
					methodInfo = property.GetGetMethod(true);
					bool flag3 = methodInfo == null && !methodInfo.IsAssembly && !methodInfo.IsFamilyOrAssembly;
					if (flag3)
					{
						methodInfo = null;
					}
				}
				result = methodInfo;
			}
			return result;
		}

		// Token: 0x0600825E RID: 33374 RVA: 0x000FA328 File Offset: 0x000F8528
		internal static MethodInfo GetSetMethod(PropertyInfo property, bool nonPublic, bool allowInternal)
		{
			bool flag = property == null;
			MethodInfo result;
			if (flag)
			{
				result = null;
			}
			else
			{
				MethodInfo methodInfo = property.GetSetMethod(nonPublic);
				bool flag2 = methodInfo == null && !nonPublic && allowInternal;
				if (flag2)
				{
					methodInfo = property.GetGetMethod(true);
					bool flag3 = methodInfo == null && !methodInfo.IsAssembly && !methodInfo.IsFamilyOrAssembly;
					if (flag3)
					{
						methodInfo = null;
					}
				}
				result = methodInfo;
			}
			return result;
		}

		// Token: 0x0600825F RID: 33375 RVA: 0x000FA390 File Offset: 0x000F8590
		internal static ConstructorInfo GetConstructor(Type type, Type[] parameterTypes, bool nonPublic)
		{
			return type.GetConstructor(nonPublic ? (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) : (BindingFlags.Instance | BindingFlags.Public), null, parameterTypes, null);
		}

		// Token: 0x06008260 RID: 33376 RVA: 0x000FA3B4 File Offset: 0x000F85B4
		internal static ConstructorInfo[] GetConstructors(Type type, bool nonPublic)
		{
			return type.GetConstructors(nonPublic ? (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) : (BindingFlags.Instance | BindingFlags.Public));
		}

		// Token: 0x06008261 RID: 33377 RVA: 0x000FA3D8 File Offset: 0x000F85D8
		internal static PropertyInfo GetProperty(Type type, string name, bool nonPublic)
		{
			return type.GetProperty(name, nonPublic ? (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) : (BindingFlags.Instance | BindingFlags.Public));
		}

		// Token: 0x06008262 RID: 33378 RVA: 0x000FA3FC File Offset: 0x000F85FC
		internal static object ParseEnum(Type type, string value)
		{
			return Enum.Parse(type, value, true);
		}

		// Token: 0x06008263 RID: 33379 RVA: 0x000FA418 File Offset: 0x000F8618
		internal static MemberInfo[] GetInstanceFieldsAndProperties(Type type, bool publicOnly)
		{
			BindingFlags bindingAttr = publicOnly ? (BindingFlags.Instance | BindingFlags.Public) : (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			PropertyInfo[] properties = type.GetProperties(bindingAttr);
			FieldInfo[] fields = type.GetFields(bindingAttr);
			MemberInfo[] array = new MemberInfo[fields.Length + properties.Length];
			properties.CopyTo(array, 0);
			fields.CopyTo(array, properties.Length);
			return array;
		}

		// Token: 0x06008264 RID: 33380 RVA: 0x000FA468 File Offset: 0x000F8668
		internal static Type GetMemberType(MemberInfo member)
		{
			MemberTypes memberType = member.MemberType;
			Type result;
			if (memberType != MemberTypes.Field)
			{
				if (memberType != MemberTypes.Property)
				{
					result = null;
				}
				else
				{
					result = ((PropertyInfo)member).PropertyType;
				}
			}
			else
			{
				result = ((FieldInfo)member).FieldType;
			}
			return result;
		}

		// Token: 0x06008265 RID: 33381 RVA: 0x000FA4AC File Offset: 0x000F86AC
		internal static bool IsAssignableFrom(Type target, Type type)
		{
			return target.IsAssignableFrom(type);
		}

		// Token: 0x04002851 RID: 10321
		public static readonly Type[] EmptyTypes = Type.EmptyTypes;
	}
}
