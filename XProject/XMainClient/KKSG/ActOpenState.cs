using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007B6 RID: 1974
	[ProtoContract(Name = "ActOpenState")]
	public enum ActOpenState
	{
		// Token: 0x04002549 RID: 9545
		[ProtoEnum(Name = "ActOpenState_NotOpen", Value = 1)]
		ActOpenState_NotOpen = 1,
		// Token: 0x0400254A RID: 9546
		[ProtoEnum(Name = "ActOpenState_Prepare", Value = 2)]
		ActOpenState_Prepare,
		// Token: 0x0400254B RID: 9547
		[ProtoEnum(Name = "ActOpenState_Running", Value = 3)]
		ActOpenState_Running,
		// Token: 0x0400254C RID: 9548
		[ProtoEnum(Name = "ActOpenState_Over", Value = 4)]
		ActOpenState_Over
	}
}
