using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200075E RID: 1886
	[ProtoContract(Name = "GuildMemberFlag")]
	public enum GuildMemberFlag
	{
		// Token: 0x04002317 RID: 8983
		[ProtoEnum(Name = "SEND_FATIGUE", Value = 1)]
		SEND_FATIGUE = 1,
		// Token: 0x04002318 RID: 8984
		[ProtoEnum(Name = "RECV_FATIGUE", Value = 2)]
		RECV_FATIGUE,
		// Token: 0x04002319 RID: 8985
		[ProtoEnum(Name = "RECVED_FATIGUE", Value = 4)]
		RECVED_FATIGUE = 4,
		// Token: 0x0400231A RID: 8986
		[ProtoEnum(Name = "ONLINE", Value = 8)]
		ONLINE = 8
	}
}
