using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RankeType")]
	public enum RankeType
	{

		[ProtoEnum(Name = "RealTimeArenaRank", Value = 0)]
		RealTimeArenaRank,

		[ProtoEnum(Name = "ArenaRank", Value = 1)]
		ArenaRank,

		[ProtoEnum(Name = "WorldBossGuildRank", Value = 2)]
		WorldBossGuildRank,

		[ProtoEnum(Name = "WorldBossDamageRank", Value = 3)]
		WorldBossDamageRank,

		[ProtoEnum(Name = "PowerPointRank", Value = 4)]
		PowerPointRank,

		[ProtoEnum(Name = "LevelRank", Value = 5)]
		LevelRank,

		[ProtoEnum(Name = "FlowerRank", Value = 6)]
		FlowerRank,

		[ProtoEnum(Name = "GuildBossRank", Value = 7)]
		GuildBossRank,

		[ProtoEnum(Name = "GuildBossRoleRank", Value = 8)]
		GuildBossRoleRank,

		[ProtoEnum(Name = "PkRealTimeRank", Value = 9)]
		PkRealTimeRank,

		[ProtoEnum(Name = "PkRank", Value = 10)]
		PkRank,

		[ProtoEnum(Name = "FashionPowerPointRank", Value = 11)]
		FashionPowerPointRank,

		[ProtoEnum(Name = "TShowVoteCountRank", Value = 12)]
		TShowVoteCountRank,

		[ProtoEnum(Name = "TowerRank", Value = 13)]
		TowerRank,

		[ProtoEnum(Name = "FlowerYesterdayRank", Value = 14)]
		FlowerYesterdayRank,

		[ProtoEnum(Name = "FlowerTotalRank", Value = 15)]
		FlowerTotalRank,

		[ProtoEnum(Name = "FirstPassRank", Value = 16)]
		FirstPassRank,

		[ProtoEnum(Name = "DEProgressRank", Value = 17)]
		DEProgressRank,

		[ProtoEnum(Name = "SpritePowerPointRank", Value = 18)]
		SpritePowerPointRank,

		[ProtoEnum(Name = "PetPowerPointRank", Value = 19)]
		PetPowerPointRank,

		[ProtoEnum(Name = "FlowerThisWeekRank", Value = 20)]
		FlowerThisWeekRank,

		[ProtoEnum(Name = "NestWeekRank", Value = 21)]
		NestWeekRank,

		[ProtoEnum(Name = "LeagueTeamRank", Value = 22)]
		LeagueTeamRank,

		[ProtoEnum(Name = "CrossLeagueRank", Value = 23)]
		CrossLeagueRank,

		[ProtoEnum(Name = "HeroBattleRank", Value = 24)]
		HeroBattleRank,

		[ProtoEnum(Name = "MilitaryRank", Value = 25)]
		MilitaryRank,

		[ProtoEnum(Name = "LastWeek_PkRank", Value = 26)]
		LastWeek_PkRank,

		[ProtoEnum(Name = "LastWeek_NestWeekRank", Value = 27)]
		LastWeek_NestWeekRank,

		[ProtoEnum(Name = "LastWeek_HeroBattleRank", Value = 28)]
		LastWeek_HeroBattleRank,

		[ProtoEnum(Name = "LastWeek_LeagueTeamRank", Value = 29)]
		LastWeek_LeagueTeamRank,

		[ProtoEnum(Name = "SkyCraftRank", Value = 30)]
		SkyCraftRank,

		[ProtoEnum(Name = "PkRank2v2", Value = 31)]
		PkRank2v2,

		[ProtoEnum(Name = "FlowerActivityRank", Value = 32)]
		FlowerActivityRank,

		[ProtoEnum(Name = "BigMeleeRank", Value = 33)]
		BigMeleeRank,

		[ProtoEnum(Name = "BioHelllRank", Value = 34)]
		BioHelllRank,

		[ProtoEnum(Name = "CompeteDragonRank", Value = 35)]
		CompeteDragonRank,

		[ProtoEnum(Name = "SurviveRank", Value = 36)]
		SurviveRank,

		[ProtoEnum(Name = "SkyCityRank", Value = 37)]
		SkyCityRank,

		[ProtoEnum(Name = "WorldBossGuildRoleRank", Value = 38)]
		WorldBossGuildRoleRank,

		[ProtoEnum(Name = "RiftRank", Value = 39)]
		RiftRank,

		[ProtoEnum(Name = "CampDuelRank1", Value = 40)]
		CampDuelRank1,

		[ProtoEnum(Name = "CampDuelRank2", Value = 41)]
		CampDuelRank2,

		[ProtoEnum(Name = "Festival520Rank", Value = 42)]
		Festival520Rank
	}
}
