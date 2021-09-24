using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FriendOpType")]
	public enum FriendOpType
	{

		[ProtoEnum(Name = "Friend_AgreeApply", Value = 1)]
		Friend_AgreeApply = 1,

		[ProtoEnum(Name = "Friend_IgnoreApply", Value = 2)]
		Friend_IgnoreApply,

		[ProtoEnum(Name = "Friend_FriendAll", Value = 3)]
		Friend_FriendAll,

		[ProtoEnum(Name = "Friend_ApplyAll", Value = 4)]
		Friend_ApplyAll,

		[ProtoEnum(Name = "Friend_FriendAdd", Value = 5)]
		Friend_FriendAdd,

		[ProtoEnum(Name = "Friend_FriendDelete", Value = 6)]
		Friend_FriendDelete,

		[ProtoEnum(Name = "Friend_ApplyAdd", Value = 7)]
		Friend_ApplyAdd,

		[ProtoEnum(Name = "Friend_ApplyDelete", Value = 8)]
		Friend_ApplyDelete,

		[ProtoEnum(Name = "Friend_ReveiveGift", Value = 9)]
		Friend_ReveiveGift,

		[ProtoEnum(Name = "Friend_SendGift", Value = 10)]
		Friend_SendGift,

		[ProtoEnum(Name = "Friend_TakeGift", Value = 11)]
		Friend_TakeGift,

		[ProtoEnum(Name = "Friend_GiftInfo", Value = 12)]
		Friend_GiftInfo
	}
}
