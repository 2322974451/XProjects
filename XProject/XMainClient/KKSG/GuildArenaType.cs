using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007C1 RID: 1985
	[ProtoContract(Name = "GuildArenaType")]
	public enum GuildArenaType
	{
		// Token: 0x0400258F RID: 9615
		[ProtoEnum(Name = "battleone", Value = 1)]
		battleone = 1,
		// Token: 0x04002590 RID: 9616
		[ProtoEnum(Name = "battletwo", Value = 2)]
		battletwo,
		// Token: 0x04002591 RID: 9617
		[ProtoEnum(Name = "battlethree", Value = 3)]
		battlethree,
		// Token: 0x04002592 RID: 9618
		[ProtoEnum(Name = "battlefour", Value = 4)]
		battlefour,
		// Token: 0x04002593 RID: 9619
		[ProtoEnum(Name = "battlefinal", Value = 5)]
		battlefinal,
		// Token: 0x04002594 RID: 9620
		[ProtoEnum(Name = "apply", Value = 6)]
		apply,
		// Token: 0x04002595 RID: 9621
		[ProtoEnum(Name = "resttime", Value = 0)]
		resttime = 0,
		// Token: 0x04002596 RID: 9622
		[ProtoEnum(Name = "notopen", Value = 7)]
		notopen = 7
	}
}
