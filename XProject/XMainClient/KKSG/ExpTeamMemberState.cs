using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ExpTeamMemberState")]
	public enum ExpTeamMemberState
	{

		[ProtoEnum(Name = "EXPTEAM_IDLE", Value = 0)]
		EXPTEAM_IDLE,

		[ProtoEnum(Name = "EXPTEAM_READY", Value = 1)]
		EXPTEAM_READY,

		[ProtoEnum(Name = "EXPTEAM_DISAGREE", Value = 2)]
		EXPTEAM_DISAGREE,

		[ProtoEnum(Name = "EXPTEAM_FINISH", Value = 3)]
		EXPTEAM_FINISH
	}
}
