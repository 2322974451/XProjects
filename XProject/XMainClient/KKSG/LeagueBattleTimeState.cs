using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007E3 RID: 2019
	[ProtoContract(Name = "LeagueBattleTimeState")]
	public enum LeagueBattleTimeState
	{
		// Token: 0x04002650 RID: 9808
		[ProtoEnum(Name = "LBTS_BeforeOpen", Value = 1)]
		LBTS_BeforeOpen = 1,
		// Token: 0x04002651 RID: 9809
		[ProtoEnum(Name = "LBTS_Apply", Value = 2)]
		LBTS_Apply,
		// Token: 0x04002652 RID: 9810
		[ProtoEnum(Name = "LBTS_Idle", Value = 3)]
		LBTS_Idle,
		// Token: 0x04002653 RID: 9811
		[ProtoEnum(Name = "LBTS_PointRace", Value = 4)]
		LBTS_PointRace,
		// Token: 0x04002654 RID: 9812
		[ProtoEnum(Name = "LBTS_Elimination", Value = 5)]
		LBTS_Elimination,
		// Token: 0x04002655 RID: 9813
		[ProtoEnum(Name = "LBTS_CrossIdle", Value = 6)]
		LBTS_CrossIdle,
		// Token: 0x04002656 RID: 9814
		[ProtoEnum(Name = "LBTS_CrossPointRace", Value = 7)]
		LBTS_CrossPointRace,
		// Token: 0x04002657 RID: 9815
		[ProtoEnum(Name = "LBTS_CrossElimination", Value = 8)]
		LBTS_CrossElimination,
		// Token: 0x04002658 RID: 9816
		[ProtoEnum(Name = "LBTS_SeasonEnd", Value = 9)]
		LBTS_SeasonEnd
	}
}
