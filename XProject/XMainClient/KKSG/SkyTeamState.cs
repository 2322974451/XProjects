using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007F9 RID: 2041
	[ProtoContract(Name = "SkyTeamState")]
	public enum SkyTeamState
	{
		// Token: 0x040026E3 RID: 9955
		[ProtoEnum(Name = "SkyTeamState_Idle", Value = 1)]
		SkyTeamState_Idle = 1,
		// Token: 0x040026E4 RID: 9956
		[ProtoEnum(Name = "SkyTeamState_Match", Value = 2)]
		SkyTeamState_Match,
		// Token: 0x040026E5 RID: 9957
		[ProtoEnum(Name = "SkyTeamState_Battle", Value = 3)]
		SkyTeamState_Battle
	}
}
