using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SystemRewardType")]
	public enum SystemRewardType
	{

		[ProtoEnum(Name = "RewardDinner", Value = 1)]
		RewardDinner = 1,

		[ProtoEnum(Name = "RewardSupper", Value = 2)]
		RewardSupper,

		[ProtoEnum(Name = "RewardArena", Value = 3)]
		RewardArena,

		[ProtoEnum(Name = "RewardWorldBoss", Value = 4)]
		RewardWorldBoss,

		[ProtoEnum(Name = "RewardChargeFirst", Value = 5)]
		RewardChargeFirst,

		[ProtoEnum(Name = "RewardGuildBoss", Value = 6)]
		RewardGuildBoss,

		[ProtoEnum(Name = "RewardGuildBossRole", Value = 7)]
		RewardGuildBossRole,

		[ProtoEnum(Name = "RewardPk", Value = 8)]
		RewardPk,

		[ProtoEnum(Name = "RewardVip", Value = 101)]
		RewardVip = 101,

		[ProtoEnum(Name = "RewardMonthCard", Value = 102)]
		RewardMonthCard,

		[ProtoEnum(Name = "RewardMakeUp", Value = 103)]
		RewardMakeUp,

		[ProtoEnum(Name = "RewardArenaUp", Value = 104)]
		RewardArenaUp,

		[ProtoEnum(Name = "RewardGM", Value = 105)]
		RewardGM,

		[ProtoEnum(Name = "RewardDegree", Value = 106)]
		RewardDegree,

		[ProtoEnum(Name = "RewardFashionPowerRank", Value = 107)]
		RewardFashionPowerRank
	}
}
