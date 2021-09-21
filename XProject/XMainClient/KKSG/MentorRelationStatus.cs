using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007CF RID: 1999
	[ProtoContract(Name = "MentorRelationStatus")]
	public enum MentorRelationStatus
	{
		// Token: 0x040025E2 RID: 9698
		[ProtoEnum(Name = "MentorRelationIn", Value = 1)]
		MentorRelationIn = 1,
		// Token: 0x040025E3 RID: 9699
		[ProtoEnum(Name = "MentorRelationComplete", Value = 2)]
		MentorRelationComplete,
		// Token: 0x040025E4 RID: 9700
		[ProtoEnum(Name = "MentorRelationBreakApply", Value = 3)]
		MentorRelationBreakApply,
		// Token: 0x040025E5 RID: 9701
		[ProtoEnum(Name = "MentorRelationBreak", Value = 4)]
		MentorRelationBreak,
		// Token: 0x040025E6 RID: 9702
		[ProtoEnum(Name = "MentorRelationMax", Value = 5)]
		MentorRelationMax
	}
}
