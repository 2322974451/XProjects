using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000790 RID: 1936
	[ProtoContract(Name = "PVP_ONEGAMEEND_REASON")]
	public enum PVP_ONEGAMEEND_REASON
	{
		// Token: 0x04002461 RID: 9313
		[ProtoEnum(Name = "PVP_OGE_LEADER_DIE", Value = 1)]
		PVP_OGE_LEADER_DIE = 1,
		// Token: 0x04002462 RID: 9314
		[ProtoEnum(Name = "PVP_OGE_LEADER_QUIT", Value = 2)]
		PVP_OGE_LEADER_QUIT,
		// Token: 0x04002463 RID: 9315
		[ProtoEnum(Name = "PVP_OGE_TIMELIMIT", Value = 3)]
		PVP_OGE_TIMELIMIT,
		// Token: 0x04002464 RID: 9316
		[ProtoEnum(Name = "PVP_OGE_ROLE_QUIT", Value = 4)]
		PVP_OGE_ROLE_QUIT
	}
}
