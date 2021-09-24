using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeagueTeamState")]
	public enum LeagueTeamState
	{

		[ProtoEnum(Name = "LeagueTeamState_Idle", Value = 1)]
		LeagueTeamState_Idle = 1,

		[ProtoEnum(Name = "LeagueTeamState_Match", Value = 2)]
		LeagueTeamState_Match,

		[ProtoEnum(Name = "LeagueTeamState_Battle", Value = 3)]
		LeagueTeamState_Battle
	}
}
