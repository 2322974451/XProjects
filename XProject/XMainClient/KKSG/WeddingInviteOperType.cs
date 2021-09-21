using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200081B RID: 2075
	[ProtoContract(Name = "WeddingInviteOperType")]
	public enum WeddingInviteOperType
	{
		// Token: 0x04002786 RID: 10118
		[ProtoEnum(Name = "Wedding_Invite", Value = 1)]
		Wedding_Invite = 1,
		// Token: 0x04002787 RID: 10119
		[ProtoEnum(Name = "Wedding_Apply", Value = 2)]
		Wedding_Apply,
		// Token: 0x04002788 RID: 10120
		[ProtoEnum(Name = "Wedding_AgreeApply", Value = 3)]
		Wedding_AgreeApply,
		// Token: 0x04002789 RID: 10121
		[ProtoEnum(Name = "Wedding_DisagreeApply", Value = 4)]
		Wedding_DisagreeApply,
		// Token: 0x0400278A RID: 10122
		[ProtoEnum(Name = "Wedding_PermitStranger", Value = 5)]
		Wedding_PermitStranger,
		// Token: 0x0400278B RID: 10123
		[ProtoEnum(Name = "Wedding_ForbidStranger", Value = 6)]
		Wedding_ForbidStranger,
		// Token: 0x0400278C RID: 10124
		[ProtoEnum(Name = "Wedding_CarCutScene", Value = 7)]
		Wedding_CarCutScene,
		// Token: 0x0400278D RID: 10125
		[ProtoEnum(Name = "Wedding_Start", Value = 8)]
		Wedding_Start
	}
}
