using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007CE RID: 1998
	[ProtoContract(Name = "MentorApplyStatus")]
	public enum MentorApplyStatus
	{
		// Token: 0x040025DD RID: 9693
		[ProtoEnum(Name = "MentorApplyMaster", Value = 1)]
		MentorApplyMaster = 1,
		// Token: 0x040025DE RID: 9694
		[ProtoEnum(Name = "MentorApplyStudent", Value = 2)]
		MentorApplyStudent,
		// Token: 0x040025DF RID: 9695
		[ProtoEnum(Name = "MentorApplyHas", Value = 3)]
		MentorApplyHas,
		// Token: 0x040025E0 RID: 9696
		[ProtoEnum(Name = "MentorApplyStatusMax", Value = 4)]
		MentorApplyStatusMax
	}
}
