using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FriendGiftReceive")]
	public enum FriendGiftReceive
	{

		[ProtoEnum(Name = "FriendGift_ReceiveNone", Value = 0)]
		FriendGift_ReceiveNone,

		[ProtoEnum(Name = "FriendGift_Received", Value = 1)]
		FriendGift_Received,

		[ProtoEnum(Name = "FriendGift_ReceiveTaken", Value = 2)]
		FriendGift_ReceiveTaken
	}
}
