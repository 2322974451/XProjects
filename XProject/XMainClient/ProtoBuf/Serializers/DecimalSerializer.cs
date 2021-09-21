using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000861 RID: 2145
	internal sealed class DecimalSerializer : IProtoSerializer
	{
		// Token: 0x0600837F RID: 33663 RVA: 0x0000311A File Offset: 0x0000131A
		public DecimalSerializer(TypeModel model)
		{
		}

		// Token: 0x1700297D RID: 10621
		// (get) Token: 0x06008380 RID: 33664 RVA: 0x000FF6CC File Offset: 0x000FD8CC
		public Type ExpectedType
		{
			get
			{
				return DecimalSerializer.expectedType;
			}
		}

		// Token: 0x1700297E RID: 10622
		// (get) Token: 0x06008381 RID: 33665 RVA: 0x000FF6E4 File Offset: 0x000FD8E4
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700297F RID: 10623
		// (get) Token: 0x06008382 RID: 33666 RVA: 0x000FF6F8 File Offset: 0x000FD8F8
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06008383 RID: 33667 RVA: 0x000FF70C File Offset: 0x000FD90C
		public object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			return BclHelpers.ReadDecimal(source);
		}

		// Token: 0x06008384 RID: 33668 RVA: 0x000FF733 File Offset: 0x000FD933
		public void Write(object value, ProtoWriter dest)
		{
			BclHelpers.WriteDecimal((decimal)value, dest);
		}

		// Token: 0x040028E0 RID: 10464
		private static readonly Type expectedType = typeof(decimal);
	}
}
