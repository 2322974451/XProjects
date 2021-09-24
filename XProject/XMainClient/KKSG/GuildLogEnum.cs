using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildLogEnum")]
	public enum GuildLogEnum
	{

		[ProtoEnum(Name = "GUILDLOG_MEMBER_START", Value = 0)]
		GUILDLOG_MEMBER_START,

		[ProtoEnum(Name = "GuildLog_Join", Value = 1)]
		GuildLog_Join,

		[ProtoEnum(Name = "GuildLog_Leave", Value = 2)]
		GuildLog_Leave,

		[ProtoEnum(Name = "GuildLog_ChangePosition", Value = 3)]
		GuildLog_ChangePosition,

		[ProtoEnum(Name = "GUILDLOG_MEMBER_END", Value = 4)]
		GUILDLOG_MEMBER_END,

		[ProtoEnum(Name = "GUILDLOG_CHECKIN_START", Value = 5)]
		GUILDLOG_CHECKIN_START,

		[ProtoEnum(Name = "GUILDLOG_CHECKIN_END", Value = 6)]
		GUILDLOG_CHECKIN_END,

		[ProtoEnum(Name = "GUILDLOG_REDBONUS_START", Value = 7)]
		GUILDLOG_REDBONUS_START,

		[ProtoEnum(Name = "GUILDLOG_REDBONUS_END", Value = 8)]
		GUILDLOG_REDBONUS_END,

		[ProtoEnum(Name = "GuildLog_BossDps", Value = 9)]
		GuildLog_BossDps
	}
}
