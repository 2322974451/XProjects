using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TaskActivityType")]
	public enum TaskActivityType
	{

		[ProtoEnum(Name = "TaskActType_Dragonexp", Value = 1)]
		TaskActType_Dragonexp = 1,

		[ProtoEnum(Name = "TaskActType_Tower", Value = 2)]
		TaskActType_Tower,

		[ProtoEnum(Name = "TaskActType_SuperRisk", Value = 3)]
		TaskActType_SuperRisk,

		[ProtoEnum(Name = "TaskActType_SkyCityRound", Value = 4)]
		TaskActType_SkyCityRound,

		[ProtoEnum(Name = "TaskActType_BigmeleeKill", Value = 5)]
		TaskActType_BigmeleeKill,

		[ProtoEnum(Name = "TaskActType_BigmeleeScore", Value = 6)]
		TaskActType_BigmeleeScore,

		[ProtoEnum(Name = "TaskActType_GuildBoss", Value = 7)]
		TaskActType_GuildBoss,

		[ProtoEnum(Name = "TaskActType_HeroBattleWin", Value = 8)]
		TaskActType_HeroBattleWin,

		[ProtoEnum(Name = "TaskActType_PkWin", Value = 9)]
		TaskActType_PkWin,

		[ProtoEnum(Name = "TaskActType_Help", Value = 10)]
		TaskActType_Help,

		[ProtoEnum(Name = "TaskActType_DonateItem", Value = 11)]
		TaskActType_DonateItem,

		[ProtoEnum(Name = "TaskActType_Fish", Value = 12)]
		TaskActType_Fish,

		[ProtoEnum(Name = "TaskActType_GardenSteal", Value = 13)]
		TaskActType_GardenSteal,

		[ProtoEnum(Name = "TaskActType_GardenHarvest", Value = 14)]
		TaskActType_GardenHarvest,

		[ProtoEnum(Name = "TaskActType_Cooking", Value = 15)]
		TaskActType_Cooking,

		[ProtoEnum(Name = "TaskActType_Banquet", Value = 16)]
		TaskActType_Banquet,

		[ProtoEnum(Name = "TaskActType_JoinBanquet", Value = 17)]
		TaskActType_JoinBanquet,

		[ProtoEnum(Name = "TaskActType_WorldBoss", Value = 18)]
		TaskActType_WorldBoss,

		[ProtoEnum(Name = "TaskActType_CampDuel", Value = 19)]
		TaskActType_CampDuel
	}
}
