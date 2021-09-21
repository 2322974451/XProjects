using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000783 RID: 1923
	[ProtoContract(Name = "MulActivityTimeState")]
	public enum MulActivityTimeState
	{
		// Token: 0x040023FE RID: 9214
		[ProtoEnum(Name = "MULACTIVITY_BEfOREOPEN", Value = 1)]
		MULACTIVITY_BEfOREOPEN = 1,
		// Token: 0x040023FF RID: 9215
		[ProtoEnum(Name = "MULACTIVITY_RUNNING", Value = 2)]
		MULACTIVITY_RUNNING,
		// Token: 0x04002400 RID: 9216
		[ProtoEnum(Name = "MULACTIVITY_END", Value = 3)]
		MULACTIVITY_END,
		// Token: 0x04002401 RID: 9217
		[ProtoEnum(Name = "MULACTIVITY_UNOPEN_TODAY", Value = 4)]
		MULACTIVITY_UNOPEN_TODAY
	}
}
