using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildBonusType")]
	public enum GuildBonusType
	{

		[ProtoEnum(Name = "GBONUS_LEVELUP", Value = 1)]
		GBONUS_LEVELUP = 1,

		[ProtoEnum(Name = "GBONUS_CARDREWARD", Value = 2)]
		GBONUS_CARDREWARD,

		[ProtoEnum(Name = "GBONUS_KILLDRAGON", Value = 3)]
		GBONUS_KILLDRAGON,

		[ProtoEnum(Name = "GBONUS_GUILDGOBLIN", Value = 4)]
		GBONUS_GUILDGOBLIN,

		[ProtoEnum(Name = "GBONUS_GUILDGOBLIN_LEVELUP", Value = 5)]
		GBONUS_GUILDGOBLIN_LEVELUP,

		[ProtoEnum(Name = "GBONUS_CHECKIN", Value = 6)]
		GBONUS_CHECKIN,

		[ProtoEnum(Name = "GBONUS_TIANTIRANK", Value = 7)]
		GBONUS_TIANTIRANK,

		[ProtoEnum(Name = "GBONUS_KILLSTAGEDRAGON", Value = 8)]
		GBONUS_KILLSTAGEDRAGON,

		[ProtoEnum(Name = "GBONUS_CHARGETIMES", Value = 9)]
		GBONUS_CHARGETIMES,

		[ProtoEnum(Name = "GBONUS_VIPLEVEL", Value = 10)]
		GBONUS_VIPLEVEL,

		[ProtoEnum(Name = "GBONUS_DRAWLOTTERY_TEN", Value = 11)]
		GBONUS_DRAWLOTTERY_TEN,

		[ProtoEnum(Name = "GBONUS_TITLE", Value = 12)]
		GBONUS_TITLE,

		[ProtoEnum(Name = "GBONUS_STRENGTHEN", Value = 13)]
		GBONUS_STRENGTHEN,

		[ProtoEnum(Name = "GBONUS_TOWER", Value = 14)]
		GBONUS_TOWER,

		[ProtoEnum(Name = "GBONUS_TIMEBONUS", Value = 15)]
		GBONUS_TIMEBONUS,

		[ProtoEnum(Name = "GBONUS_CHARGEPRIVILEGE", Value = 16)]
		GBONUS_CHARGEPRIVILEGE,

		[ProtoEnum(Name = "GBONUS_PURCHASEFUND", Value = 17)]
		GBONUS_PURCHASEFUND,

		[ProtoEnum(Name = "GBONUS_DRAGONJADEL_ALLLEVEL", Value = 18)]
		GBONUS_DRAGONJADEL_ALLLEVEL,

		[ProtoEnum(Name = "GBONUS_SKYARENA_FLOOR", Value = 19)]
		GBONUS_SKYARENA_FLOOR,

		[ProtoEnum(Name = "GBONUS_HORSE_QUALITY", Value = 20)]
		GBONUS_HORSE_QUALITY,

		[ProtoEnum(Name = "GBONUS_DRAGONNEST_SCENE", Value = 21)]
		GBONUS_DRAGONNEST_SCENE,

		[ProtoEnum(Name = "GBONUS_GMF_RANK", Value = 22)]
		GBONUS_GMF_RANK,

		[ProtoEnum(Name = "GBONUS_BOSSRUSH", Value = 23)]
		GBONUS_BOSSRUSH,

		[ProtoEnum(Name = "GBONUS_BUYIBSHOP", Value = 24)]
		GBONUS_BUYIBSHOP,

		[ProtoEnum(Name = "GBONUS_MAYHEMRANK", Value = 25)]
		GBONUS_MAYHEMRANK,

		[ProtoEnum(Name = "GBONUS_USETHREESUIT", Value = 26)]
		GBONUS_USETHREESUIT,

		[ProtoEnum(Name = "GBONUS_USEITEM", Value = 27)]
		GBONUS_USEITEM,

		[ProtoEnum(Name = "GBONUS_MAX", Value = 28)]
		GBONUS_MAX
	}
}
