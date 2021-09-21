using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007A8 RID: 1960
	[ProtoContract(Name = "GuildOpType")]
	public enum GuildOpType
	{
		// Token: 0x040024FA RID: 9466
		[ProtoEnum(Name = "STUDY_SKILL", Value = 1)]
		STUDY_SKILL = 1,
		// Token: 0x040024FB RID: 9467
		[ProtoEnum(Name = "GUILD_DARE_INFO", Value = 2)]
		GUILD_DARE_INFO
	}
}
