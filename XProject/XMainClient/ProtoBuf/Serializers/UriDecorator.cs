using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000882 RID: 2178
	internal sealed class UriDecorator : ProtoDecoratorBase
	{
		// Token: 0x0600847C RID: 33916 RVA: 0x00102DEC File Offset: 0x00100FEC
		public UriDecorator(TypeModel model, IProtoSerializer tail) : base(tail)
		{
		}

		// Token: 0x170029E2 RID: 10722
		// (get) Token: 0x0600847D RID: 33917 RVA: 0x00102DF8 File Offset: 0x00100FF8
		public override Type ExpectedType
		{
			get
			{
				return UriDecorator.expectedType;
			}
		}

		// Token: 0x170029E3 RID: 10723
		// (get) Token: 0x0600847E RID: 33918 RVA: 0x00102E10 File Offset: 0x00101010
		public override bool RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170029E4 RID: 10724
		// (get) Token: 0x0600847F RID: 33919 RVA: 0x00102E24 File Offset: 0x00101024
		public override bool ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06008480 RID: 33920 RVA: 0x00102E37 File Offset: 0x00101037
		public override void Write(object value, ProtoWriter dest)
		{
			this.Tail.Write(((Uri)value).AbsoluteUri, dest);
		}

		// Token: 0x06008481 RID: 33921 RVA: 0x00102E54 File Offset: 0x00101054
		public override object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			string text = (string)this.Tail.Read(null, source);
			return (text.Length == 0) ? null : new Uri(text);
		}

		// Token: 0x04002930 RID: 10544
		private static readonly Type expectedType = typeof(Uri);
	}
}
