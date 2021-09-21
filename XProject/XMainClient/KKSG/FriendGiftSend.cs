using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200077D RID: 1917
	[ProtoContract(Name = "FriendGiftSend")]
	public enum FriendGiftSend
	{
		// Token: 0x040023EA RID: 9194
		[ProtoEnum(Name = "FriendGift_SendNone", Value = 0)]
		FriendGift_SendNone,
		// Token: 0x040023EB RID: 9195
		[ProtoEnum(Name = "FriendGift_Sended", Value = 1)]
		FriendGift_Sended
	}
}
