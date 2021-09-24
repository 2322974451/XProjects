using System;
using System.Reflection;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{

	internal sealed class ParseableSerializer : IProtoSerializer
	{

		public static ParseableSerializer TryCreate(Type type, TypeModel model)
		{
			bool flag = type == null;
			if (flag)
			{
				throw new ArgumentNullException("type");
			}
			MethodInfo method = type.GetMethod("Parse", BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public, null, new Type[]
			{
				model.MapType(typeof(string))
			}, null);
			bool flag2 = method != null && method.ReturnType == type;
			ParseableSerializer result;
			if (flag2)
			{
				bool flag3 = Helpers.IsValueType(type);
				if (flag3)
				{
					MethodInfo customToString = ParseableSerializer.GetCustomToString(type);
					bool flag4 = customToString == null || customToString.ReturnType != model.MapType(typeof(string));
					if (flag4)
					{
						return null;
					}
				}
				result = new ParseableSerializer(method);
			}
			else
			{
				result = null;
			}
			return result;
		}

		private static MethodInfo GetCustomToString(Type type)
		{
			return type.GetMethod("ToString", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public, null, Helpers.EmptyTypes, null);
		}

		private ParseableSerializer(MethodInfo parse)
		{
			this.parse = parse;
		}

		public Type ExpectedType
		{
			get
			{
				return this.parse.DeclaringType;
			}
		}

		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		public object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			ProtoDecoratorBase.s_argsRead[0] = source.ReadString();
			return this.parse.Invoke(null, ProtoDecoratorBase.s_argsRead);
		}

		public void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteString(value.ToString(), dest);
		}

		private readonly MethodInfo parse;
	}
}
