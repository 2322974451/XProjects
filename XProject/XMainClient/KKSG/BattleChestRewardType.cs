using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BattleChestRewardType")]
	public enum BattleChestRewardType
	{

		[ProtoEnum(Name = "GOLD_CHEST", Value = 1)]
		GOLD_CHEST = 1,

		[ProtoEnum(Name = "SILVER_CHEST", Value = 2)]
		SILVER_CHEST,

		[ProtoEnum(Name = "COPPER_CHEST", Value = 3)]
		COPPER_CHEST,

		[ProtoEnum(Name = "WOOD_CHEST", Value = 4)]
		WOOD_CHEST
	}
}
