using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000794 RID: 1940
	[ProtoContract(Name = "MSGiveItemType")]
	public enum MSGiveItemType
	{
		// Token: 0x0400247A RID: 9338
		[ProtoEnum(Name = "MSItem_FriendGift", Value = 1)]
		MSItem_FriendGift = 1
	}
}
