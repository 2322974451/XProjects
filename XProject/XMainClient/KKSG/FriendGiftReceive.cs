using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200077E RID: 1918
	[ProtoContract(Name = "FriendGiftReceive")]
	public enum FriendGiftReceive
	{
		// Token: 0x040023ED RID: 9197
		[ProtoEnum(Name = "FriendGift_ReceiveNone", Value = 0)]
		FriendGift_ReceiveNone,
		// Token: 0x040023EE RID: 9198
		[ProtoEnum(Name = "FriendGift_Received", Value = 1)]
		FriendGift_Received,
		// Token: 0x040023EF RID: 9199
		[ProtoEnum(Name = "FriendGift_ReceiveTaken", Value = 2)]
		FriendGift_ReceiveTaken
	}
}
