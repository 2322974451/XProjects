using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007AF RID: 1967
	[ProtoContract(Name = "SkyCityTimeType")]
	public enum SkyCityTimeType
	{
		// Token: 0x0400251C RID: 9500
		[ProtoEnum(Name = "Waiting", Value = 1)]
		Waiting = 1,
		// Token: 0x0400251D RID: 9501
		[ProtoEnum(Name = "Race", Value = 2)]
		Race,
		// Token: 0x0400251E RID: 9502
		[ProtoEnum(Name = "MidleEndInRest", Value = 3)]
		MidleEndInRest,
		// Token: 0x0400251F RID: 9503
		[ProtoEnum(Name = "FirstWaiting", Value = 4)]
		FirstWaiting,
		// Token: 0x04002520 RID: 9504
		[ProtoEnum(Name = "SecondWaiting", Value = 5)]
		SecondWaiting,
		// Token: 0x04002521 RID: 9505
		[ProtoEnum(Name = "SC_NONE", Value = 6)]
		SC_NONE
	}
}
