using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000760 RID: 1888
	[ProtoContract(Name = "GuildLogEnum")]
	public enum GuildLogEnum
	{
		// Token: 0x04002320 RID: 8992
		[ProtoEnum(Name = "GUILDLOG_MEMBER_START", Value = 0)]
		GUILDLOG_MEMBER_START,
		// Token: 0x04002321 RID: 8993
		[ProtoEnum(Name = "GuildLog_Join", Value = 1)]
		GuildLog_Join,
		// Token: 0x04002322 RID: 8994
		[ProtoEnum(Name = "GuildLog_Leave", Value = 2)]
		GuildLog_Leave,
		// Token: 0x04002323 RID: 8995
		[ProtoEnum(Name = "GuildLog_ChangePosition", Value = 3)]
		GuildLog_ChangePosition,
		// Token: 0x04002324 RID: 8996
		[ProtoEnum(Name = "GUILDLOG_MEMBER_END", Value = 4)]
		GUILDLOG_MEMBER_END,
		// Token: 0x04002325 RID: 8997
		[ProtoEnum(Name = "GUILDLOG_CHECKIN_START", Value = 5)]
		GUILDLOG_CHECKIN_START,
		// Token: 0x04002326 RID: 8998
		[ProtoEnum(Name = "GUILDLOG_CHECKIN_END", Value = 6)]
		GUILDLOG_CHECKIN_END,
		// Token: 0x04002327 RID: 8999
		[ProtoEnum(Name = "GUILDLOG_REDBONUS_START", Value = 7)]
		GUILDLOG_REDBONUS_START,
		// Token: 0x04002328 RID: 9000
		[ProtoEnum(Name = "GUILDLOG_REDBONUS_END", Value = 8)]
		GUILDLOG_REDBONUS_END,
		// Token: 0x04002329 RID: 9001
		[ProtoEnum(Name = "GuildLog_BossDps", Value = 9)]
		GuildLog_BossDps
	}
}
