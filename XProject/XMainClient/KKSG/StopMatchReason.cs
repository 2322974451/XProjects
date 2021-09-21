using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000787 RID: 1927
	[ProtoContract(Name = "StopMatchReason")]
	public enum StopMatchReason
	{
		// Token: 0x04002429 RID: 9257
		[ProtoEnum(Name = "STOPMATCH_NONE", Value = 1)]
		STOPMATCH_NONE = 1,
		// Token: 0x0400242A RID: 9258
		[ProtoEnum(Name = "STOPMATCH_LEAVESCENE", Value = 2)]
		STOPMATCH_LEAVESCENE,
		// Token: 0x0400242B RID: 9259
		[ProtoEnum(Name = "STOPMATCH_ENTER_TIANTI", Value = 3)]
		STOPMATCH_ENTER_TIANTI,
		// Token: 0x0400242C RID: 9260
		[ProtoEnum(Name = "STOPMATCH_ENTER_BOWEIDUIZ", Value = 4)]
		STOPMATCH_ENTER_BOWEIDUIZ
	}
}
