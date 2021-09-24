using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace ProtoBuf
{

	internal sealed class Helpers
	{

		private Helpers()
		{
		}

		public static StringBuilder AppendLine(StringBuilder builder)
		{
			return builder.AppendLine();
		}

		public static bool IsNullOrEmpty(string value)
		{
			return value == null || value.Length == 0;
		}

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

		[Conditional("DEBUG")]
		public static void DebugWriteLine(string message)
		{
			Debug.WriteLine(message);
		}

		[Conditional("TRACE")]
		public static void TraceWriteLine(string message)
		{
			Trace.WriteLine(message);
		}

		[Conditional("DEBUG")]
		public static void DebugAssert(bool condition, string message)
		{
			bool flag = !condition;
			if (flag)
			{
				Debug.Assert(false, message);
			}
		}

		[Conditional("DEBUG")]
		public static void DebugAssert(bool condition, string message, params object[] args)
		{
			bool flag = !condition;
			if (flag)
			{
				Helpers.DebugAssert(false, string.Format(message, args));
			}
		}

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

		public static void BlockCopy(byte[] from, int fromIndex, byte[] to, int toIndex, int count)
		{
			Buffer.BlockCopy(from, fromIndex, to, toIndex, count);
		}

		public static bool IsInfinity(float value)
		{
			return float.IsInfinity(value);
		}

		internal static MethodInfo GetInstanceMethod(Type declaringType, string name)
		{
			return declaringType.GetMethod(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		}

		internal static MethodInfo GetStaticMethod(Type declaringType, string name)
		{
			return declaringType.GetMethod(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		internal static MethodInfo GetInstanceMethod(Type declaringType, string name, Type[] types)
		{
			bool flag = types == null;
			if (flag)
			{
				types = Helpers.EmptyTypes;
			}
			return declaringType.GetMethod(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, types, null);
		}

		internal static bool IsSubclassOf(Type type, Type baseClass)
		{
			return type.IsSubclassOf(baseClass);
		}

		public static bool IsInfinity(double value)
		{
			return double.IsInfinity(value);
		}

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

		internal static Type GetUnderlyingType(Type type)
		{
			return Nullable.GetUnderlyingType(type);
		}

		internal static bool IsValueType(Type type)
		{
			return type.IsValueType;
		}

		internal static bool IsEnum(Type type)
		{
			return type.IsEnum;
		}

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

		internal static ConstructorInfo GetConstructor(Type type, Type[] parameterTypes, bool nonPublic)
		{
			return type.GetConstructor(nonPublic ? (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) : (BindingFlags.Instance | BindingFlags.Public), null, parameterTypes, null);
		}

		internal static ConstructorInfo[] GetConstructors(Type type, bool nonPublic)
		{
			return type.GetConstructors(nonPublic ? (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) : (BindingFlags.Instance | BindingFlags.Public));
		}

		internal static PropertyInfo GetProperty(Type type, string name, bool nonPublic)
		{
			return type.GetProperty(name, nonPublic ? (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) : (BindingFlags.Instance | BindingFlags.Public));
		}

		internal static object ParseEnum(Type type, string value)
		{
			return Enum.Parse(type, value, true);
		}

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

		internal static bool IsAssignableFrom(Type target, Type type)
		{
			return target.IsAssignableFrom(type);
		}

		public static readonly Type[] EmptyTypes = Type.EmptyTypes;
	}
}
