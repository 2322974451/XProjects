using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RoleEventType")]
	public enum RoleEventType
	{

		[ProtoEnum(Name = "OnSendFriendGift", Value = 1)]
		OnSendFriendGift = 1
	}
}
