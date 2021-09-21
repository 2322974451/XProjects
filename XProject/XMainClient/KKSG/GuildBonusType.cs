using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000761 RID: 1889
	[ProtoContract(Name = "GuildBonusType")]
	public enum GuildBonusType
	{
		// Token: 0x0400232B RID: 9003
		[ProtoEnum(Name = "GBONUS_LEVELUP", Value = 1)]
		GBONUS_LEVELUP = 1,
		// Token: 0x0400232C RID: 9004
		[ProtoEnum(Name = "GBONUS_CARDREWARD", Value = 2)]
		GBONUS_CARDREWARD,
		// Token: 0x0400232D RID: 9005
		[ProtoEnum(Name = "GBONUS_KILLDRAGON", Value = 3)]
		GBONUS_KILLDRAGON,
		// Token: 0x0400232E RID: 9006
		[ProtoEnum(Name = "GBONUS_GUILDGOBLIN", Value = 4)]
		GBONUS_GUILDGOBLIN,
		// Token: 0x0400232F RID: 9007
		[ProtoEnum(Name = "GBONUS_GUILDGOBLIN_LEVELUP", Value = 5)]
		GBONUS_GUILDGOBLIN_LEVELUP,
		// Token: 0x04002330 RID: 9008
		[ProtoEnum(Name = "GBONUS_CHECKIN", Value = 6)]
		GBONUS_CHECKIN,
		// Token: 0x04002331 RID: 9009
		[ProtoEnum(Name = "GBONUS_TIANTIRANK", Value = 7)]
		GBONUS_TIANTIRANK,
		// Token: 0x04002332 RID: 9010
		[ProtoEnum(Name = "GBONUS_KILLSTAGEDRAGON", Value = 8)]
		GBONUS_KILLSTAGEDRAGON,
		// Token: 0x04002333 RID: 9011
		[ProtoEnum(Name = "GBONUS_CHARGETIMES", Value = 9)]
		GBONUS_CHARGETIMES,
		// Token: 0x04002334 RID: 9012
		[ProtoEnum(Name = "GBONUS_VIPLEVEL", Value = 10)]
		GBONUS_VIPLEVEL,
		// Token: 0x04002335 RID: 9013
		[ProtoEnum(Name = "GBONUS_DRAWLOTTERY_TEN", Value = 11)]
		GBONUS_DRAWLOTTERY_TEN,
		// Token: 0x04002336 RID: 9014
		[ProtoEnum(Name = "GBONUS_TITLE", Value = 12)]
		GBONUS_TITLE,
		// Token: 0x04002337 RID: 9015
		[ProtoEnum(Name = "GBONUS_STRENGTHEN", Value = 13)]
		GBONUS_STRENGTHEN,
		// Token: 0x04002338 RID: 9016
		[ProtoEnum(Name = "GBONUS_TOWER", Value = 14)]
		GBONUS_TOWER,
		// Token: 0x04002339 RID: 9017
		[ProtoEnum(Name = "GBONUS_TIMEBONUS", Value = 15)]
		GBONUS_TIMEBONUS,
		// Token: 0x0400233A RID: 9018
		[ProtoEnum(Name = "GBONUS_CHARGEPRIVILEGE", Value = 16)]
		GBONUS_CHARGEPRIVILEGE,
		// Token: 0x0400233B RID: 9019
		[ProtoEnum(Name = "GBONUS_PURCHASEFUND", Value = 17)]
		GBONUS_PURCHASEFUND,
		// Token: 0x0400233C RID: 9020
		[ProtoEnum(Name = "GBONUS_DRAGONJADEL_ALLLEVEL", Value = 18)]
		GBONUS_DRAGONJADEL_ALLLEVEL,
		// Token: 0x0400233D RID: 9021
		[ProtoEnum(Name = "GBONUS_SKYARENA_FLOOR", Value = 19)]
		GBONUS_SKYARENA_FLOOR,
		// Token: 0x0400233E RID: 9022
		[ProtoEnum(Name = "GBONUS_HORSE_QUALITY", Value = 20)]
		GBONUS_HORSE_QUALITY,
		// Token: 0x0400233F RID: 9023
		[ProtoEnum(Name = "GBONUS_DRAGONNEST_SCENE", Value = 21)]
		GBONUS_DRAGONNEST_SCENE,
		// Token: 0x04002340 RID: 9024
		[ProtoEnum(Name = "GBONUS_GMF_RANK", Value = 22)]
		GBONUS_GMF_RANK,
		// Token: 0x04002341 RID: 9025
		[ProtoEnum(Name = "GBONUS_BOSSRUSH", Value = 23)]
		GBONUS_BOSSRUSH,
		// Token: 0x04002342 RID: 9026
		[ProtoEnum(Name = "GBONUS_BUYIBSHOP", Value = 24)]
		GBONUS_BUYIBSHOP,
		// Token: 0x04002343 RID: 9027
		[ProtoEnum(Name = "GBONUS_MAYHEMRANK", Value = 25)]
		GBONUS_MAYHEMRANK,
		// Token: 0x04002344 RID: 9028
		[ProtoEnum(Name = "GBONUS_USETHREESUIT", Value = 26)]
		GBONUS_USETHREESUIT,
		// Token: 0x04002345 RID: 9029
		[ProtoEnum(Name = "GBONUS_USEITEM", Value = 27)]
		GBONUS_USEITEM,
		// Token: 0x04002346 RID: 9030
		[ProtoEnum(Name = "GBONUS_MAX", Value = 28)]
		GBONUS_MAX
	}
}
