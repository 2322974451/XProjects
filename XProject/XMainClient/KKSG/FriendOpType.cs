using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200077C RID: 1916
	[ProtoContract(Name = "FriendOpType")]
	public enum FriendOpType
	{
		// Token: 0x040023DD RID: 9181
		[ProtoEnum(Name = "Friend_AgreeApply", Value = 1)]
		Friend_AgreeApply = 1,
		// Token: 0x040023DE RID: 9182
		[ProtoEnum(Name = "Friend_IgnoreApply", Value = 2)]
		Friend_IgnoreApply,
		// Token: 0x040023DF RID: 9183
		[ProtoEnum(Name = "Friend_FriendAll", Value = 3)]
		Friend_FriendAll,
		// Token: 0x040023E0 RID: 9184
		[ProtoEnum(Name = "Friend_ApplyAll", Value = 4)]
		Friend_ApplyAll,
		// Token: 0x040023E1 RID: 9185
		[ProtoEnum(Name = "Friend_FriendAdd", Value = 5)]
		Friend_FriendAdd,
		// Token: 0x040023E2 RID: 9186
		[ProtoEnum(Name = "Friend_FriendDelete", Value = 6)]
		Friend_FriendDelete,
		// Token: 0x040023E3 RID: 9187
		[ProtoEnum(Name = "Friend_ApplyAdd", Value = 7)]
		Friend_ApplyAdd,
		// Token: 0x040023E4 RID: 9188
		[ProtoEnum(Name = "Friend_ApplyDelete", Value = 8)]
		Friend_ApplyDelete,
		// Token: 0x040023E5 RID: 9189
		[ProtoEnum(Name = "Friend_ReveiveGift", Value = 9)]
		Friend_ReveiveGift,
		// Token: 0x040023E6 RID: 9190
		[ProtoEnum(Name = "Friend_SendGift", Value = 10)]
		Friend_SendGift,
		// Token: 0x040023E7 RID: 9191
		[ProtoEnum(Name = "Friend_TakeGift", Value = 11)]
		Friend_TakeGift,
		// Token: 0x040023E8 RID: 9192
		[ProtoEnum(Name = "Friend_GiftInfo", Value = 12)]
		Friend_GiftInfo
	}
}
