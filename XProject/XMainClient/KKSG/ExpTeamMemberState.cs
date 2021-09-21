using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000758 RID: 1880
	[ProtoContract(Name = "ExpTeamMemberState")]
	public enum ExpTeamMemberState
	{
		// Token: 0x040022E0 RID: 8928
		[ProtoEnum(Name = "EXPTEAM_IDLE", Value = 0)]
		EXPTEAM_IDLE,
		// Token: 0x040022E1 RID: 8929
		[ProtoEnum(Name = "EXPTEAM_READY", Value = 1)]
		EXPTEAM_READY,
		// Token: 0x040022E2 RID: 8930
		[ProtoEnum(Name = "EXPTEAM_DISAGREE", Value = 2)]
		EXPTEAM_DISAGREE,
		// Token: 0x040022E3 RID: 8931
		[ProtoEnum(Name = "EXPTEAM_FINISH", Value = 3)]
		EXPTEAM_FINISH
	}
}
