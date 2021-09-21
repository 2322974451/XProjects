using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007AE RID: 1966
	[ProtoContract(Name = "TaskStatus")]
	public enum TaskStatus
	{
		// Token: 0x04002517 RID: 9495
		[ProtoEnum(Name = "TaskStatus_CanTake", Value = 1)]
		TaskStatus_CanTake = 1,
		// Token: 0x04002518 RID: 9496
		[ProtoEnum(Name = "TaskStatus_Taked", Value = 2)]
		TaskStatus_Taked,
		// Token: 0x04002519 RID: 9497
		[ProtoEnum(Name = "TaskStatus_Finish", Value = 3)]
		TaskStatus_Finish,
		// Token: 0x0400251A RID: 9498
		[ProtoEnum(Name = "TaskStatus_Over", Value = 4)]
		TaskStatus_Over
	}
}
