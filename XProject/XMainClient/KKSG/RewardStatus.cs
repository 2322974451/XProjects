using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RewardStatus")]
	public enum RewardStatus
	{

		[ProtoEnum(Name = "REWARD_STATUS_CANNOT", Value = 0)]
		REWARD_STATUS_CANNOT,

		[ProtoEnum(Name = "REWARD_STATUS_CAN", Value = 1)]
		REWARD_STATUS_CAN,

		[ProtoEnum(Name = "REWARD_STATUS_GOT", Value = 2)]
		REWARD_STATUS_GOT
	}
}
