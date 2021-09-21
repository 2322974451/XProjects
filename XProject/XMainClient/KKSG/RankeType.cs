using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000753 RID: 1875
	[ProtoContract(Name = "RankeType")]
	public enum RankeType
	{
		// Token: 0x04002281 RID: 8833
		[ProtoEnum(Name = "RealTimeArenaRank", Value = 0)]
		RealTimeArenaRank,
		// Token: 0x04002282 RID: 8834
		[ProtoEnum(Name = "ArenaRank", Value = 1)]
		ArenaRank,
		// Token: 0x04002283 RID: 8835
		[ProtoEnum(Name = "WorldBossGuildRank", Value = 2)]
		WorldBossGuildRank,
		// Token: 0x04002284 RID: 8836
		[ProtoEnum(Name = "WorldBossDamageRank", Value = 3)]
		WorldBossDamageRank,
		// Token: 0x04002285 RID: 8837
		[ProtoEnum(Name = "PowerPointRank", Value = 4)]
		PowerPointRank,
		// Token: 0x04002286 RID: 8838
		[ProtoEnum(Name = "LevelRank", Value = 5)]
		LevelRank,
		// Token: 0x04002287 RID: 8839
		[ProtoEnum(Name = "FlowerRank", Value = 6)]
		FlowerRank,
		// Token: 0x04002288 RID: 8840
		[ProtoEnum(Name = "GuildBossRank", Value = 7)]
		GuildBossRank,
		// Token: 0x04002289 RID: 8841
		[ProtoEnum(Name = "GuildBossRoleRank", Value = 8)]
		GuildBossRoleRank,
		// Token: 0x0400228A RID: 8842
		[ProtoEnum(Name = "PkRealTimeRank", Value = 9)]
		PkRealTimeRank,
		// Token: 0x0400228B RID: 8843
		[ProtoEnum(Name = "PkRank", Value = 10)]
		PkRank,
		// Token: 0x0400228C RID: 8844
		[ProtoEnum(Name = "FashionPowerPointRank", Value = 11)]
		FashionPowerPointRank,
		// Token: 0x0400228D RID: 8845
		[ProtoEnum(Name = "TShowVoteCountRank", Value = 12)]
		TShowVoteCountRank,
		// Token: 0x0400228E RID: 8846
		[ProtoEnum(Name = "TowerRank", Value = 13)]
		TowerRank,
		// Token: 0x0400228F RID: 8847
		[ProtoEnum(Name = "FlowerYesterdayRank", Value = 14)]
		FlowerYesterdayRank,
		// Token: 0x04002290 RID: 8848
		[ProtoEnum(Name = "FlowerTotalRank", Value = 15)]
		FlowerTotalRank,
		// Token: 0x04002291 RID: 8849
		[ProtoEnum(Name = "FirstPassRank", Value = 16)]
		FirstPassRank,
		// Token: 0x04002292 RID: 8850
		[ProtoEnum(Name = "DEProgressRank", Value = 17)]
		DEProgressRank,
		// Token: 0x04002293 RID: 8851
		[ProtoEnum(Name = "SpritePowerPointRank", Value = 18)]
		SpritePowerPointRank,
		// Token: 0x04002294 RID: 8852
		[ProtoEnum(Name = "PetPowerPointRank", Value = 19)]
		PetPowerPointRank,
		// Token: 0x04002295 RID: 8853
		[ProtoEnum(Name = "FlowerThisWeekRank", Value = 20)]
		FlowerThisWeekRank,
		// Token: 0x04002296 RID: 8854
		[ProtoEnum(Name = "NestWeekRank", Value = 21)]
		NestWeekRank,
		// Token: 0x04002297 RID: 8855
		[ProtoEnum(Name = "LeagueTeamRank", Value = 22)]
		LeagueTeamRank,
		// Token: 0x04002298 RID: 8856
		[ProtoEnum(Name = "CrossLeagueRank", Value = 23)]
		CrossLeagueRank,
		// Token: 0x04002299 RID: 8857
		[ProtoEnum(Name = "HeroBattleRank", Value = 24)]
		HeroBattleRank,
		// Token: 0x0400229A RID: 8858
		[ProtoEnum(Name = "MilitaryRank", Value = 25)]
		MilitaryRank,
		// Token: 0x0400229B RID: 8859
		[ProtoEnum(Name = "LastWeek_PkRank", Value = 26)]
		LastWeek_PkRank,
		// Token: 0x0400229C RID: 8860
		[ProtoEnum(Name = "LastWeek_NestWeekRank", Value = 27)]
		LastWeek_NestWeekRank,
		// Token: 0x0400229D RID: 8861
		[ProtoEnum(Name = "LastWeek_HeroBattleRank", Value = 28)]
		LastWeek_HeroBattleRank,
		// Token: 0x0400229E RID: 8862
		[ProtoEnum(Name = "LastWeek_LeagueTeamRank", Value = 29)]
		LastWeek_LeagueTeamRank,
		// Token: 0x0400229F RID: 8863
		[ProtoEnum(Name = "SkyCraftRank", Value = 30)]
		SkyCraftRank,
		// Token: 0x040022A0 RID: 8864
		[ProtoEnum(Name = "PkRank2v2", Value = 31)]
		PkRank2v2,
		// Token: 0x040022A1 RID: 8865
		[ProtoEnum(Name = "FlowerActivityRank", Value = 32)]
		FlowerActivityRank,
		// Token: 0x040022A2 RID: 8866
		[ProtoEnum(Name = "BigMeleeRank", Value = 33)]
		BigMeleeRank,
		// Token: 0x040022A3 RID: 8867
		[ProtoEnum(Name = "BioHelllRank", Value = 34)]
		BioHelllRank,
		// Token: 0x040022A4 RID: 8868
		[ProtoEnum(Name = "CompeteDragonRank", Value = 35)]
		CompeteDragonRank,
		// Token: 0x040022A5 RID: 8869
		[ProtoEnum(Name = "SurviveRank", Value = 36)]
		SurviveRank,
		// Token: 0x040022A6 RID: 8870
		[ProtoEnum(Name = "SkyCityRank", Value = 37)]
		SkyCityRank,
		// Token: 0x040022A7 RID: 8871
		[ProtoEnum(Name = "WorldBossGuildRoleRank", Value = 38)]
		WorldBossGuildRoleRank,
		// Token: 0x040022A8 RID: 8872
		[ProtoEnum(Name = "RiftRank", Value = 39)]
		RiftRank,
		// Token: 0x040022A9 RID: 8873
		[ProtoEnum(Name = "CampDuelRank1", Value = 40)]
		CampDuelRank1,
		// Token: 0x040022AA RID: 8874
		[ProtoEnum(Name = "CampDuelRank2", Value = 41)]
		CampDuelRank2,
		// Token: 0x040022AB RID: 8875
		[ProtoEnum(Name = "Festival520Rank", Value = 42)]
		Festival520Rank
	}
}
