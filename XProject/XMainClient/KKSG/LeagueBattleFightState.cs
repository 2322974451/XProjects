using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007EA RID: 2026
	[ProtoContract(Name = "LeagueBattleFightState")]
	public enum LeagueBattleFightState
	{
		// Token: 0x04002679 RID: 9849
		[ProtoEnum(Name = "LBFight_None", Value = 1)]
		LBFight_None = 1,
		// Token: 0x0400267A RID: 9850
		[ProtoEnum(Name = "LBFight_Wait", Value = 2)]
		LBFight_Wait,
		// Token: 0x0400267B RID: 9851
		[ProtoEnum(Name = "LBFight_Fight", Value = 3)]
		LBFight_Fight,
		// Token: 0x0400267C RID: 9852
		[ProtoEnum(Name = "LBFight_Result", Value = 4)]
		LBFight_Result
	}
}
