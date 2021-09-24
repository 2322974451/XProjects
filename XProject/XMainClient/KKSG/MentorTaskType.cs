using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MentorTaskType")]
	public enum MentorTaskType
	{

		[ProtoEnum(Name = "MentorTask_JoinGuild", Value = 1)]
		MentorTask_JoinGuild = 1,

		[ProtoEnum(Name = "MentorTask_Jade", Value = 2)]
		MentorTask_Jade,

		[ProtoEnum(Name = "MentorTask_Title", Value = 3)]
		MentorTask_Title,

		[ProtoEnum(Name = "MentorTask_Pandora", Value = 4)]
		MentorTask_Pandora,

		[ProtoEnum(Name = "MentorTask_StageTypeCount", Value = 5)]
		MentorTask_StageTypeCount,

		[ProtoEnum(Name = "MentorTask_GuildCheckIn", Value = 6)]
		MentorTask_GuildCheckIn,

		[ProtoEnum(Name = "MentorTask_GuildAuctBenefit", Value = 7)]
		MentorTask_GuildAuctBenefit,

		[ProtoEnum(Name = "MentorTask_RiskStage", Value = 8)]
		MentorTask_RiskStage,

		[ProtoEnum(Name = "MentorTask_ProtectCaptain", Value = 9)]
		MentorTask_ProtectCaptain,

		[ProtoEnum(Name = "MentorTask_TianTi", Value = 10)]
		MentorTask_TianTi,

		[ProtoEnum(Name = "MentorTask_Emblem", Value = 11)]
		MentorTask_Emblem,

		[ProtoEnum(Name = "MentorTask_DailyActive", Value = 12)]
		MentorTask_DailyActive,

		[ProtoEnum(Name = "MentorTask_WorldBossCount", Value = 13)]
		MentorTask_WorldBossCount,

		[ProtoEnum(Name = "MentorTask_BossRush", Value = 14)]
		MentorTask_BossRush,

		[ProtoEnum(Name = "MentorTask_StageStar", Value = 15)]
		MentorTask_StageStar,

		[ProtoEnum(Name = "MentorTask_SkyFloor", Value = 16)]
		MentorTask_SkyFloor,

		[ProtoEnum(Name = "MentorTask_TowerFloor", Value = 17)]
		MentorTask_TowerFloor,

		[ProtoEnum(Name = "MentorTask_WorldBossRank", Value = 18)]
		MentorTask_WorldBossRank,

		[ProtoEnum(Name = "MentorTask_GuildBossCount", Value = 19)]
		MentorTask_GuildBossCount,

		[ProtoEnum(Name = "MentorTask_DailyTask", Value = 20)]
		MentorTask_DailyTask,

		[ProtoEnum(Name = "MentorTask_SkyCount", Value = 21)]
		MentorTask_SkyCount,

		[ProtoEnum(Name = "MentorTask_AllEquipStengthen", Value = 22)]
		MentorTask_AllEquipStengthen,

		[ProtoEnum(Name = "MentorTask_GuildTianTiCount", Value = 23)]
		MentorTask_GuildTianTiCount,

		[ProtoEnum(Name = "MentorTask_MentorIntimacy", Value = 24)]
		MentorTask_MentorIntimacy,

		[ProtoEnum(Name = "MentorTask_IBShopBuy", Value = 25)]
		MentorTask_IBShopBuy,

		[ProtoEnum(Name = "MentorTask_BuyPrivilege", Value = 26)]
		MentorTask_BuyPrivilege,

		[ProtoEnum(Name = "MentorTask_BuyFund", Value = 27)]
		MentorTask_BuyFund,

		[ProtoEnum(Name = "MentorTask_BuyGift", Value = 28)]
		MentorTask_BuyGift,

		[ProtoEnum(Name = "MentorTask_AllEquipQuality", Value = 29)]
		MentorTask_AllEquipQuality,

		[ProtoEnum(Name = "MentorTask_AuctBuy", Value = 30)]
		MentorTask_AuctBuy,

		[ProtoEnum(Name = "MentorTask_AuctSale", Value = 31)]
		MentorTask_AuctSale
	}
}
