using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000877 RID: 2167
	internal sealed class StringSerializer : IProtoSerializer
	{
		// Token: 0x06008416 RID: 33814 RVA: 0x0000311A File Offset: 0x0000131A
		public StringSerializer(TypeModel model)
		{
		}

		// Token: 0x170029BF RID: 10687
		// (get) Token: 0x06008417 RID: 33815 RVA: 0x00101734 File Offset: 0x000FF934
		public Type ExpectedType
		{
			get
			{
				return StringSerializer.expectedType;
			}
		}

		// Token: 0x06008418 RID: 33816 RVA: 0x0010174B File Offset: 0x000FF94B
		public void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteString((string)value, dest);
		}

		// Token: 0x170029C0 RID: 10688
		// (get) Token: 0x06008419 RID: 33817 RVA: 0x0010175C File Offset: 0x000FF95C
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170029C1 RID: 10689
		// (get) Token: 0x0600841A RID: 33818 RVA: 0x00101770 File Offset: 0x000FF970
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600841B RID: 33819 RVA: 0x00101784 File Offset: 0x000FF984
		public object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			return source.ReadString();
		}

		// Token: 0x0400290F RID: 10511
		private static readonly Type expectedType = typeof(string);
	}
}
