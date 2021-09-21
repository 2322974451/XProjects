using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007BB RID: 1979
	[ProtoContract(Name = "WageRewardState")]
	public enum WageRewardState
	{
		// Token: 0x04002567 RID: 9575
		[ProtoEnum(Name = "cannot", Value = 1)]
		cannot = 1,
		// Token: 0x04002568 RID: 9576
		[ProtoEnum(Name = "rewarded", Value = 2)]
		rewarded,
		// Token: 0x04002569 RID: 9577
		[ProtoEnum(Name = "notreward", Value = 3)]
		notreward
	}
}
