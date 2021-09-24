using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MentorRelationStatus")]
	public enum MentorRelationStatus
	{

		[ProtoEnum(Name = "MentorRelationIn", Value = 1)]
		MentorRelationIn = 1,

		[ProtoEnum(Name = "MentorRelationComplete", Value = 2)]
		MentorRelationComplete,

		[ProtoEnum(Name = "MentorRelationBreakApply", Value = 3)]
		MentorRelationBreakApply,

		[ProtoEnum(Name = "MentorRelationBreak", Value = 4)]
		MentorRelationBreak,

		[ProtoEnum(Name = "MentorRelationMax", Value = 5)]
		MentorRelationMax
	}
}
