using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FriendGiftSend")]
	public enum FriendGiftSend
	{

		[ProtoEnum(Name = "FriendGift_SendNone", Value = 0)]
		FriendGift_SendNone,

		[ProtoEnum(Name = "FriendGift_Sended", Value = 1)]
		FriendGift_Sended
	}
}
