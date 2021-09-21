using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007F1 RID: 2033
	[ProtoContract(Name = "MentorTaskType")]
	public enum MentorTaskType
	{
		// Token: 0x0400269D RID: 9885
		[ProtoEnum(Name = "MentorTask_JoinGuild", Value = 1)]
		MentorTask_JoinGuild = 1,
		// Token: 0x0400269E RID: 9886
		[ProtoEnum(Name = "MentorTask_Jade", Value = 2)]
		MentorTask_Jade,
		// Token: 0x0400269F RID: 9887
		[ProtoEnum(Name = "MentorTask_Title", Value = 3)]
		MentorTask_Title,
		// Token: 0x040026A0 RID: 9888
		[ProtoEnum(Name = "MentorTask_Pandora", Value = 4)]
		MentorTask_Pandora,
		// Token: 0x040026A1 RID: 9889
		[ProtoEnum(Name = "MentorTask_StageTypeCount", Value = 5)]
		MentorTask_StageTypeCount,
		// Token: 0x040026A2 RID: 9890
		[ProtoEnum(Name = "MentorTask_GuildCheckIn", Value = 6)]
		MentorTask_GuildCheckIn,
		// Token: 0x040026A3 RID: 9891
		[ProtoEnum(Name = "MentorTask_GuildAuctBenefit", Value = 7)]
		MentorTask_GuildAuctBenefit,
		// Token: 0x040026A4 RID: 9892
		[ProtoEnum(Name = "MentorTask_RiskStage", Value = 8)]
		MentorTask_RiskStage,
		// Token: 0x040026A5 RID: 9893
		[ProtoEnum(Name = "MentorTask_ProtectCaptain", Value = 9)]
		MentorTask_ProtectCaptain,
		// Token: 0x040026A6 RID: 9894
		[ProtoEnum(Name = "MentorTask_TianTi", Value = 10)]
		MentorTask_TianTi,
		// Token: 0x040026A7 RID: 9895
		[ProtoEnum(Name = "MentorTask_Emblem", Value = 11)]
		MentorTask_Emblem,
		// Token: 0x040026A8 RID: 9896
		[ProtoEnum(Name = "MentorTask_DailyActive", Value = 12)]
		MentorTask_DailyActive,
		// Token: 0x040026A9 RID: 9897
		[ProtoEnum(Name = "MentorTask_WorldBossCount", Value = 13)]
		MentorTask_WorldBossCount,
		// Token: 0x040026AA RID: 9898
		[ProtoEnum(Name = "MentorTask_BossRush", Value = 14)]
		MentorTask_BossRush,
		// Token: 0x040026AB RID: 9899
		[ProtoEnum(Name = "MentorTask_StageStar", Value = 15)]
		MentorTask_StageStar,
		// Token: 0x040026AC RID: 9900
		[ProtoEnum(Name = "MentorTask_SkyFloor", Value = 16)]
		MentorTask_SkyFloor,
		// Token: 0x040026AD RID: 9901
		[ProtoEnum(Name = "MentorTask_TowerFloor", Value = 17)]
		MentorTask_TowerFloor,
		// Token: 0x040026AE RID: 9902
		[ProtoEnum(Name = "MentorTask_WorldBossRank", Value = 18)]
		MentorTask_WorldBossRank,
		// Token: 0x040026AF RID: 9903
		[ProtoEnum(Name = "MentorTask_GuildBossCount", Value = 19)]
		MentorTask_GuildBossCount,
		// Token: 0x040026B0 RID: 9904
		[ProtoEnum(Name = "MentorTask_DailyTask", Value = 20)]
		MentorTask_DailyTask,
		// Token: 0x040026B1 RID: 9905
		[ProtoEnum(Name = "MentorTask_SkyCount", Value = 21)]
		MentorTask_SkyCount,
		// Token: 0x040026B2 RID: 9906
		[ProtoEnum(Name = "MentorTask_AllEquipStengthen", Value = 22)]
		MentorTask_AllEquipStengthen,
		// Token: 0x040026B3 RID: 9907
		[ProtoEnum(Name = "MentorTask_GuildTianTiCount", Value = 23)]
		MentorTask_GuildTianTiCount,
		// Token: 0x040026B4 RID: 9908
		[ProtoEnum(Name = "MentorTask_MentorIntimacy", Value = 24)]
		MentorTask_MentorIntimacy,
		// Token: 0x040026B5 RID: 9909
		[ProtoEnum(Name = "MentorTask_IBShopBuy", Value = 25)]
		MentorTask_IBShopBuy,
		// Token: 0x040026B6 RID: 9910
		[ProtoEnum(Name = "MentorTask_BuyPrivilege", Value = 26)]
		MentorTask_BuyPrivilege,
		// Token: 0x040026B7 RID: 9911
		[ProtoEnum(Name = "MentorTask_BuyFund", Value = 27)]
		MentorTask_BuyFund,
		// Token: 0x040026B8 RID: 9912
		[ProtoEnum(Name = "MentorTask_BuyGift", Value = 28)]
		MentorTask_BuyGift,
		// Token: 0x040026B9 RID: 9913
		[ProtoEnum(Name = "MentorTask_AllEquipQuality", Value = 29)]
		MentorTask_AllEquipQuality,
		// Token: 0x040026BA RID: 9914
		[ProtoEnum(Name = "MentorTask_AuctBuy", Value = 30)]
		MentorTask_AuctBuy,
		// Token: 0x040026BB RID: 9915
		[ProtoEnum(Name = "MentorTask_AuctSale", Value = 31)]
		MentorTask_AuctSale
	}
}
