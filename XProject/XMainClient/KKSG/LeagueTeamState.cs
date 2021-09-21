using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007E5 RID: 2021
	[ProtoContract(Name = "LeagueTeamState")]
	public enum LeagueTeamState
	{
		// Token: 0x0400265D RID: 9821
		[ProtoEnum(Name = "LeagueTeamState_Idle", Value = 1)]
		LeagueTeamState_Idle = 1,
		// Token: 0x0400265E RID: 9822
		[ProtoEnum(Name = "LeagueTeamState_Match", Value = 2)]
		LeagueTeamState_Match,
		// Token: 0x0400265F RID: 9823
		[ProtoEnum(Name = "LeagueTeamState_Battle", Value = 3)]
		LeagueTeamState_Battle
	}
}
