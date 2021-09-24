using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MSGiveItemType")]
	public enum MSGiveItemType
	{

		[ProtoEnum(Name = "MSItem_FriendGift", Value = 1)]
		MSItem_FriendGift = 1
	}
}
