using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MentorApplyStatus")]
	public enum MentorApplyStatus
	{

		[ProtoEnum(Name = "MentorApplyMaster", Value = 1)]
		MentorApplyMaster = 1,

		[ProtoEnum(Name = "MentorApplyStudent", Value = 2)]
		MentorApplyStudent,

		[ProtoEnum(Name = "MentorApplyHas", Value = 3)]
		MentorApplyHas,

		[ProtoEnum(Name = "MentorApplyStatusMax", Value = 4)]
		MentorApplyStatusMax
	}
}
