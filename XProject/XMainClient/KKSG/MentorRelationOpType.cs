using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MentorRelationOpType")]
	public enum MentorRelationOpType
	{

		[ProtoEnum(Name = "MentorRelationOp_ApplyMaster", Value = 1)]
		MentorRelationOp_ApplyMaster = 1,

		[ProtoEnum(Name = "MentorRelationOp_ApplyStudent", Value = 2)]
		MentorRelationOp_ApplyStudent,

		[ProtoEnum(Name = "MentorRelationOp_Inherit", Value = 3)]
		MentorRelationOp_Inherit,

		[ProtoEnum(Name = "MentorRelationOp_ReportTask", Value = 4)]
		MentorRelationOp_ReportTask,

		[ProtoEnum(Name = "MentorRelationOp_ReportAllTask", Value = 5)]
		MentorRelationOp_ReportAllTask,

		[ProtoEnum(Name = "MentorRelationOp_Break", Value = 6)]
		MentorRelationOp_Break,

		[ProtoEnum(Name = "MentorRelationOp_BreakCancel", Value = 7)]
		MentorRelationOp_BreakCancel,

		[ProtoEnum(Name = "MentorRelationOp_NormalComplete", Value = 8)]
		MentorRelationOp_NormalComplete,

		[ProtoEnum(Name = "MentorRelationOp_ForceComplete", Value = 9)]
		MentorRelationOp_ForceComplete,

		[ProtoEnum(Name = "MentorRelationOp_Max", Value = 10)]
		MentorRelationOp_Max
	}
}
