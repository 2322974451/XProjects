using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007A1 RID: 1953
	[ProtoContract(Name = "ItemFindBackType")]
	public enum ItemFindBackType
	{
		// Token: 0x040024BF RID: 9407
		[ProtoEnum(Name = "TOWER", Value = 1)]
		TOWER = 1,
		// Token: 0x040024C0 RID: 9408
		[ProtoEnum(Name = "NVSHENSHILIAN", Value = 2)]
		NVSHENSHILIAN,
		// Token: 0x040024C1 RID: 9409
		[ProtoEnum(Name = "GUILDACTIVITY", Value = 3)]
		GUILDACTIVITY,
		// Token: 0x040024C2 RID: 9410
		[ProtoEnum(Name = "FATIGUE_RECOVER", Value = 4)]
		FATIGUE_RECOVER,
		// Token: 0x040024C3 RID: 9411
		[ProtoEnum(Name = "FATIGUE_GET", Value = 5)]
		FATIGUE_GET,
		// Token: 0x040024C4 RID: 9412
		[ProtoEnum(Name = "FATIGUE_BUY", Value = 6)]
		FATIGUE_BUY,
		// Token: 0x040024C5 RID: 9413
		[ProtoEnum(Name = "DICE_BACK", Value = 7)]
		DICE_BACK,
		// Token: 0x040024C6 RID: 9414
		[ProtoEnum(Name = "WUJINSHENYUAN_BACK", Value = 8)]
		WUJINSHENYUAN_BACK,
		// Token: 0x040024C7 RID: 9415
		[ProtoEnum(Name = "DRAGONEXP_BACK", Value = 9)]
		DRAGONEXP_BACK,
		// Token: 0x040024C8 RID: 9416
		[ProtoEnum(Name = "QAMULTI_BACK", Value = 10)]
		QAMULTI_BACK,
		// Token: 0x040024C9 RID: 9417
		[ProtoEnum(Name = "GUILDCHECKIN_BACK", Value = 11)]
		GUILDCHECKIN_BACK,
		// Token: 0x040024CA RID: 9418
		[ProtoEnum(Name = "GUILD_VOICE", Value = 12)]
		GUILD_VOICE,
		// Token: 0x040024CB RID: 9419
		[ProtoEnum(Name = "COMMERCETASK_BACK", Value = 13)]
		COMMERCETASK_BACK,
		// Token: 0x040024CC RID: 9420
		[ProtoEnum(Name = "DayActiveBack", Value = 14)]
		DayActiveBack,
		// Token: 0x040024CD RID: 9421
		[ProtoEnum(Name = "NestBack", Value = 15)]
		NestBack,
		// Token: 0x040024CE RID: 9422
		[ProtoEnum(Name = "FINDBACK_MAX", Value = 16)]
		FINDBACK_MAX
	}
}
