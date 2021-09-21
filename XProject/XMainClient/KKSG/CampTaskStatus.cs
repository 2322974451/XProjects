using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200076F RID: 1903
	[ProtoContract(Name = "CampTaskStatus")]
	public enum CampTaskStatus
	{
		// Token: 0x040023A1 RID: 9121
		[ProtoEnum(Name = "CAMPTASK_GET", Value = 1)]
		CAMPTASK_GET = 1,
		// Token: 0x040023A2 RID: 9122
		[ProtoEnum(Name = "CAMPTASK_VIEW", Value = 2)]
		CAMPTASK_VIEW,
		// Token: 0x040023A3 RID: 9123
		[ProtoEnum(Name = "CAMPTASK_FINISH", Value = 3)]
		CAMPTASK_FINISH,
		// Token: 0x040023A4 RID: 9124
		[ProtoEnum(Name = "CAMPTASK_REWARD", Value = 4)]
		CAMPTASK_REWARD
	}
}
