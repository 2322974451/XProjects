using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WeddingInviteOperType")]
	public enum WeddingInviteOperType
	{

		[ProtoEnum(Name = "Wedding_Invite", Value = 1)]
		Wedding_Invite = 1,

		[ProtoEnum(Name = "Wedding_Apply", Value = 2)]
		Wedding_Apply,

		[ProtoEnum(Name = "Wedding_AgreeApply", Value = 3)]
		Wedding_AgreeApply,

		[ProtoEnum(Name = "Wedding_DisagreeApply", Value = 4)]
		Wedding_DisagreeApply,

		[ProtoEnum(Name = "Wedding_PermitStranger", Value = 5)]
		Wedding_PermitStranger,

		[ProtoEnum(Name = "Wedding_ForbidStranger", Value = 6)]
		Wedding_ForbidStranger,

		[ProtoEnum(Name = "Wedding_CarCutScene", Value = 7)]
		Wedding_CarCutScene,

		[ProtoEnum(Name = "Wedding_Start", Value = 8)]
		Wedding_Start
	}
}
