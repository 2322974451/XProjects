using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007F4 RID: 2036
	[ProtoContract(Name = "GiftIbItemState")]
	public enum GiftIbItemState
	{
		// Token: 0x040026CF RID: 9935
		[ProtoEnum(Name = "GiftIbWaitingReceipt", Value = 1)]
		GiftIbWaitingReceipt = 1,
		// Token: 0x040026D0 RID: 9936
		[ProtoEnum(Name = "GiftIbReply", Value = 2)]
		GiftIbReply
	}
}
