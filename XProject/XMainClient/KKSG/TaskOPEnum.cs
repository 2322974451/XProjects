using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200074F RID: 1871
	[ProtoContract(Name = "TaskOPEnum")]
	public enum TaskOPEnum
	{
		// Token: 0x0400226D RID: 8813
		[ProtoEnum(Name = "TAKE_TASK", Value = 1)]
		TAKE_TASK = 1,
		// Token: 0x0400226E RID: 8814
		[ProtoEnum(Name = "FINISH_TASK", Value = 2)]
		FINISH_TASK
	}
}
