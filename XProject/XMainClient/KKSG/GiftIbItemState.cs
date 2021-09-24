using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GiftIbItemState")]
	public enum GiftIbItemState
	{

		[ProtoEnum(Name = "GiftIbWaitingReceipt", Value = 1)]
		GiftIbWaitingReceipt = 1,

		[ProtoEnum(Name = "GiftIbReply", Value = 2)]
		GiftIbReply
	}
}
