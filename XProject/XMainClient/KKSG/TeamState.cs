using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamState")]
	public enum TeamState
	{

		[ProtoEnum(Name = "TEAM_WAITING", Value = 0)]
		TEAM_WAITING,

		[ProtoEnum(Name = "TEAM_IN_BATTLE", Value = 1)]
		TEAM_IN_BATTLE,

		[ProtoEnum(Name = "TEAM_VOTE", Value = 2)]
		TEAM_VOTE,

		[ProtoEnum(Name = "TEAM_MATCH", Value = 3)]
		TEAM_MATCH
	}
}
