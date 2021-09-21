using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007D1 RID: 2001
	[ProtoContract(Name = "MentorRelationOpType")]
	public enum MentorRelationOpType
	{
		// Token: 0x040025EF RID: 9711
		[ProtoEnum(Name = "MentorRelationOp_ApplyMaster", Value = 1)]
		MentorRelationOp_ApplyMaster = 1,
		// Token: 0x040025F0 RID: 9712
		[ProtoEnum(Name = "MentorRelationOp_ApplyStudent", Value = 2)]
		MentorRelationOp_ApplyStudent,
		// Token: 0x040025F1 RID: 9713
		[ProtoEnum(Name = "MentorRelationOp_Inherit", Value = 3)]
		MentorRelationOp_Inherit,
		// Token: 0x040025F2 RID: 9714
		[ProtoEnum(Name = "MentorRelationOp_ReportTask", Value = 4)]
		MentorRelationOp_ReportTask,
		// Token: 0x040025F3 RID: 9715
		[ProtoEnum(Name = "MentorRelationOp_ReportAllTask", Value = 5)]
		MentorRelationOp_ReportAllTask,
		// Token: 0x040025F4 RID: 9716
		[ProtoEnum(Name = "MentorRelationOp_Break", Value = 6)]
		MentorRelationOp_Break,
		// Token: 0x040025F5 RID: 9717
		[ProtoEnum(Name = "MentorRelationOp_BreakCancel", Value = 7)]
		MentorRelationOp_BreakCancel,
		// Token: 0x040025F6 RID: 9718
		[ProtoEnum(Name = "MentorRelationOp_NormalComplete", Value = 8)]
		MentorRelationOp_NormalComplete,
		// Token: 0x040025F7 RID: 9719
		[ProtoEnum(Name = "MentorRelationOp_ForceComplete", Value = 9)]
		MentorRelationOp_ForceComplete,
		// Token: 0x040025F8 RID: 9720
		[ProtoEnum(Name = "MentorRelationOp_Max", Value = 10)]
		MentorRelationOp_Max
	}
}
