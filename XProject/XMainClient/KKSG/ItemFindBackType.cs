using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ItemFindBackType")]
	public enum ItemFindBackType
	{

		[ProtoEnum(Name = "TOWER", Value = 1)]
		TOWER = 1,

		[ProtoEnum(Name = "NVSHENSHILIAN", Value = 2)]
		NVSHENSHILIAN,

		[ProtoEnum(Name = "GUILDACTIVITY", Value = 3)]
		GUILDACTIVITY,

		[ProtoEnum(Name = "FATIGUE_RECOVER", Value = 4)]
		FATIGUE_RECOVER,

		[ProtoEnum(Name = "FATIGUE_GET", Value = 5)]
		FATIGUE_GET,

		[ProtoEnum(Name = "FATIGUE_BUY", Value = 6)]
		FATIGUE_BUY,

		[ProtoEnum(Name = "DICE_BACK", Value = 7)]
		DICE_BACK,

		[ProtoEnum(Name = "WUJINSHENYUAN_BACK", Value = 8)]
		WUJINSHENYUAN_BACK,

		[ProtoEnum(Name = "DRAGONEXP_BACK", Value = 9)]
		DRAGONEXP_BACK,

		[ProtoEnum(Name = "QAMULTI_BACK", Value = 10)]
		QAMULTI_BACK,

		[ProtoEnum(Name = "GUILDCHECKIN_BACK", Value = 11)]
		GUILDCHECKIN_BACK,

		[ProtoEnum(Name = "GUILD_VOICE", Value = 12)]
		GUILD_VOICE,

		[ProtoEnum(Name = "COMMERCETASK_BACK", Value = 13)]
		COMMERCETASK_BACK,

		[ProtoEnum(Name = "DayActiveBack", Value = 14)]
		DayActiveBack,

		[ProtoEnum(Name = "NestBack", Value = 15)]
		NestBack,

		[ProtoEnum(Name = "FINDBACK_MAX", Value = 16)]
		FINDBACK_MAX
	}
}
