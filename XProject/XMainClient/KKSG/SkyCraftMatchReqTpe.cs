using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007FA RID: 2042
	[ProtoContract(Name = "SkyCraftMatchReqTpe")]
	public enum SkyCraftMatchReqTpe
	{
		// Token: 0x040026E7 RID: 9959
		[ProtoEnum(Name = "SCMR_Match", Value = 1)]
		SCMR_Match = 1,
		// Token: 0x040026E8 RID: 9960
		[ProtoEnum(Name = "SCMR_CancelMatch", Value = 2)]
		SCMR_CancelMatch
	}
}
