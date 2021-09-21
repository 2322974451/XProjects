using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000788 RID: 1928
	[ProtoContract(Name = "GuildMatchFightState")]
	public enum GuildMatchFightState
	{
		// Token: 0x0400242E RID: 9262
		[ProtoEnum(Name = "GUILD_MF_NONE", Value = 1)]
		GUILD_MF_NONE = 1,
		// Token: 0x0400242F RID: 9263
		[ProtoEnum(Name = "GUILD_MF_WAITING", Value = 2)]
		GUILD_MF_WAITING,
		// Token: 0x04002430 RID: 9264
		[ProtoEnum(Name = "GUILD_MF_REFUSE", Value = 3)]
		GUILD_MF_REFUSE,
		// Token: 0x04002431 RID: 9265
		[ProtoEnum(Name = "GUILD_MF_LEAVE", Value = 4)]
		GUILD_MF_LEAVE,
		// Token: 0x04002432 RID: 9266
		[ProtoEnum(Name = "GUILD_MF_FIGHTING", Value = 5)]
		GUILD_MF_FIGHTING,
		// Token: 0x04002433 RID: 9267
		[ProtoEnum(Name = "GUILD_MF_FAILED", Value = 6)]
		GUILD_MF_FAILED,
		// Token: 0x04002434 RID: 9268
		[ProtoEnum(Name = "GUILD_MF_WIN", Value = 7)]
		GUILD_MF_WIN,
		// Token: 0x04002435 RID: 9269
		[ProtoEnum(Name = "GUILD_MF_ERR", Value = 100)]
		GUILD_MF_ERR = 100
	}
}
