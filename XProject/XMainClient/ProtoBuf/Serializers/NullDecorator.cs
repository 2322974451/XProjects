using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000871 RID: 2161
	internal sealed class NullDecorator : ProtoDecoratorBase
	{
		// Token: 0x060083EA RID: 33770 RVA: 0x00101024 File Offset: 0x000FF224
		public NullDecorator(TypeModel model, IProtoSerializer tail) : base(tail)
		{
			bool flag = !tail.ReturnsValue;
			if (flag)
			{
				throw new NotSupportedException("NullDecorator only supports implementations that return values");
			}
			Type type = tail.ExpectedType;
			bool flag2 = Helpers.IsValueType(type);
			if (flag2)
			{
				this.expectedType = model.MapType(typeof(Nullable<>)).MakeGenericType(new Type[]
				{
					type
				});
			}
			else
			{
				this.expectedType = type;
			}
		}

		// Token: 0x170029AD RID: 10669
		// (get) Token: 0x060083EB RID: 33771 RVA: 0x00101098 File Offset: 0x000FF298
		public override Type ExpectedType
		{
			get
			{
				return this.expectedType;
			}
		}

		// Token: 0x170029AE RID: 10670
		// (get) Token: 0x060083EC RID: 33772 RVA: 0x001010B0 File Offset: 0x000FF2B0
		public override bool ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170029AF RID: 10671
		// (get) Token: 0x060083ED RID: 33773 RVA: 0x001010C4 File Offset: 0x000FF2C4
		public override bool RequiresOldValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060083EE RID: 33774 RVA: 0x001010D8 File Offset: 0x000FF2D8
		public override object Read(object value, ProtoReader source)
		{
			SubItemToken token = ProtoReader.StartSubItem(source);
			int num;
			while ((num = source.ReadFieldHeader()) > 0)
			{
				bool flag = num == 1;
				if (flag)
				{
					value = this.Tail.Read(value, source);
				}
				else
				{
					source.SkipField();
				}
			}
			ProtoReader.EndSubItem(token, source);
			return value;
		}

		// Token: 0x060083EF RID: 33775 RVA: 0x00101134 File Offset: 0x000FF334
		public override void Write(object value, ProtoWriter dest)
		{
			SubItemToken token = ProtoWriter.StartSubItem(null, dest);
			bool flag = value != null;
			if (flag)
			{
				this.Tail.Write(value, dest);
			}
			ProtoWriter.EndSubItem(token, dest);
		}

		// Token: 0x04002902 RID: 10498
		private readonly Type expectedType;

		// Token: 0x04002903 RID: 10499
		public const int Tag = 1;
	}
}
