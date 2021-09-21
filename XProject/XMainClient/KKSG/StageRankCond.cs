using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007C2 RID: 1986
	[ProtoContract(Name = "StageRankCond")]
	public enum StageRankCond
	{
		// Token: 0x04002598 RID: 9624
		[ProtoEnum(Name = "StageRankCond_Time", Value = 1)]
		StageRankCond_Time = 1,
		// Token: 0x04002599 RID: 9625
		[ProtoEnum(Name = "StageRankCond_Hppercent", Value = 2)]
		StageRankCond_Hppercent,
		// Token: 0x0400259A RID: 9626
		[ProtoEnum(Name = "StageRankCond_Found", Value = 3)]
		StageRankCond_Found,
		// Token: 0x0400259B RID: 9627
		[ProtoEnum(Name = "StageRankCond_Behit", Value = 4)]
		StageRankCond_Behit,
		// Token: 0x0400259C RID: 9628
		[ProtoEnum(Name = "StageRankCond_NpcHp", Value = 5)]
		StageRankCond_NpcHp,
		// Token: 0x0400259D RID: 9629
		[ProtoEnum(Name = "StageRankCond_Combo", Value = 6)]
		StageRankCond_Combo,
		// Token: 0x0400259E RID: 9630
		[ProtoEnum(Name = "StageRankCond_KillEnemyScore", Value = 7)]
		StageRankCond_KillEnemyScore,
		// Token: 0x0400259F RID: 9631
		[ProtoEnum(Name = "StageRankCond_AliveTime", Value = 8)]
		StageRankCond_AliveTime,
		// Token: 0x040025A0 RID: 9632
		[ProtoEnum(Name = "StageRankCond_TotalKillEnemyScore", Value = 9)]
		StageRankCond_TotalKillEnemyScore
	}
}
