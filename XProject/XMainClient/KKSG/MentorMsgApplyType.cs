using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MentorMsgApplyType")]
	public enum MentorMsgApplyType
	{

		[ProtoEnum(Name = "MentorMsgApplyMaster", Value = 1)]
		MentorMsgApplyMaster = 1,

		[ProtoEnum(Name = "MentorMsgApplyStudent", Value = 2)]
		MentorMsgApplyStudent,

		[ProtoEnum(Name = "MentorMsgApplyInherit", Value = 3)]
		MentorMsgApplyInherit,

		[ProtoEnum(Name = "MentorMsgApplyReportTask", Value = 4)]
		MentorMsgApplyReportTask,

		[ProtoEnum(Name = "MentorMsgApplyBreak", Value = 5)]
		MentorMsgApplyBreak,

		[ProtoEnum(Name = "MentorMsgApplyMax", Value = 6)]
		MentorMsgApplyMax
	}
}
