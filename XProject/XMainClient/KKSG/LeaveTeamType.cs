using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeaveTeamType")]
	public enum LeaveTeamType
	{

		[ProtoEnum(Name = "LTT_BY_SELF", Value = 0)]
		LTT_BY_SELF,

		[ProtoEnum(Name = "LTT_KICK", Value = 1)]
		LTT_KICK,

		[ProtoEnum(Name = "LTT_DEL_ROBOT", Value = 2)]
		LTT_DEL_ROBOT,

		[ProtoEnum(Name = "LTT_MS_CRASH", Value = 3)]
		LTT_MS_CRASH,

		[ProtoEnum(Name = "LLT_LEADER_TIMEOVER", Value = 4)]
		LLT_LEADER_TIMEOVER
	}
}
