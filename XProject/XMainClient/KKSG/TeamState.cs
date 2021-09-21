using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000756 RID: 1878
	[ProtoContract(Name = "TeamState")]
	public enum TeamState
	{
		// Token: 0x040022C1 RID: 8897
		[ProtoEnum(Name = "TEAM_WAITING", Value = 0)]
		TEAM_WAITING,
		// Token: 0x040022C2 RID: 8898
		[ProtoEnum(Name = "TEAM_IN_BATTLE", Value = 1)]
		TEAM_IN_BATTLE,
		// Token: 0x040022C3 RID: 8899
		[ProtoEnum(Name = "TEAM_VOTE", Value = 2)]
		TEAM_VOTE,
		// Token: 0x040022C4 RID: 8900
		[ProtoEnum(Name = "TEAM_MATCH", Value = 3)]
		TEAM_MATCH
	}
}
