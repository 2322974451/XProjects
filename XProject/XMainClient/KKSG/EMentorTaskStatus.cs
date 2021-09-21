using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007D3 RID: 2003
	[ProtoContract(Name = "EMentorTaskStatus")]
	public enum EMentorTaskStatus
	{
		// Token: 0x040025FE RID: 9726
		[ProtoEnum(Name = "EMentorTask_UnComplete", Value = 1)]
		EMentorTask_UnComplete = 1,
		// Token: 0x040025FF RID: 9727
		[ProtoEnum(Name = "EMentorTask_CanReport", Value = 2)]
		EMentorTask_CanReport,
		// Token: 0x04002600 RID: 9728
		[ProtoEnum(Name = "EMentorTask_AlreadyReport", Value = 3)]
		EMentorTask_AlreadyReport,
		// Token: 0x04002601 RID: 9729
		[ProtoEnum(Name = "EMentorTask_ConfirmReport", Value = 4)]
		EMentorTask_ConfirmReport,
		// Token: 0x04002602 RID: 9730
		[ProtoEnum(Name = "EMentorTask_CompleteBefore", Value = 5)]
		EMentorTask_CompleteBefore,
		// Token: 0x04002603 RID: 9731
		[ProtoEnum(Name = "EMentorTask_Max", Value = 6)]
		EMentorTask_Max
	}
}
