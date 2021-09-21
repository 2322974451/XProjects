using System;
using System.Reflection;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000872 RID: 2162
	internal sealed class ParseableSerializer : IProtoSerializer
	{
		// Token: 0x060083F0 RID: 33776 RVA: 0x0010116C File Offset: 0x000FF36C
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

		// Token: 0x060083F1 RID: 33777 RVA: 0x00101220 File Offset: 0x000FF420
		private static MethodInfo GetCustomToString(Type type)
		{
			return type.GetMethod("ToString", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public, null, Helpers.EmptyTypes, null);
		}

		// Token: 0x060083F2 RID: 33778 RVA: 0x00101246 File Offset: 0x000FF446
		private ParseableSerializer(MethodInfo parse)
		{
			this.parse = parse;
		}

		// Token: 0x170029B0 RID: 10672
		// (get) Token: 0x060083F3 RID: 33779 RVA: 0x00101258 File Offset: 0x000FF458
		public Type ExpectedType
		{
			get
			{
				return this.parse.DeclaringType;
			}
		}

		// Token: 0x170029B1 RID: 10673
		// (get) Token: 0x060083F4 RID: 33780 RVA: 0x00101278 File Offset: 0x000FF478
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170029B2 RID: 10674
		// (get) Token: 0x060083F5 RID: 33781 RVA: 0x0010128C File Offset: 0x000FF48C
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060083F6 RID: 33782 RVA: 0x001012A0 File Offset: 0x000FF4A0
		public object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			ProtoDecoratorBase.s_argsRead[0] = source.ReadString();
			return this.parse.Invoke(null, ProtoDecoratorBase.s_argsRead);
		}

		// Token: 0x060083F7 RID: 33783 RVA: 0x001012DA File Offset: 0x000FF4DA
		public void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteString(value.ToString(), dest);
		}

		// Token: 0x04002904 RID: 10500
		private readonly MethodInfo parse;
	}
}
