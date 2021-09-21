using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007D0 RID: 2000
	[ProtoContract(Name = "MentorMsgApplyType")]
	public enum MentorMsgApplyType
	{
		// Token: 0x040025E8 RID: 9704
		[ProtoEnum(Name = "MentorMsgApplyMaster", Value = 1)]
		MentorMsgApplyMaster = 1,
		// Token: 0x040025E9 RID: 9705
		[ProtoEnum(Name = "MentorMsgApplyStudent", Value = 2)]
		MentorMsgApplyStudent,
		// Token: 0x040025EA RID: 9706
		[ProtoEnum(Name = "MentorMsgApplyInherit", Value = 3)]
		MentorMsgApplyInherit,
		// Token: 0x040025EB RID: 9707
		[ProtoEnum(Name = "MentorMsgApplyReportTask", Value = 4)]
		MentorMsgApplyReportTask,
		// Token: 0x040025EC RID: 9708
		[ProtoEnum(Name = "MentorMsgApplyBreak", Value = 5)]
		MentorMsgApplyBreak,
		// Token: 0x040025ED RID: 9709
		[ProtoEnum(Name = "MentorMsgApplyMax", Value = 6)]
		MentorMsgApplyMax
	}
}
