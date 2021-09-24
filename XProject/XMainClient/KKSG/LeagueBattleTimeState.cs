using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeagueBattleTimeState")]
	public enum LeagueBattleTimeState
	{

		[ProtoEnum(Name = "LBTS_BeforeOpen", Value = 1)]
		LBTS_BeforeOpen = 1,

		[ProtoEnum(Name = "LBTS_Apply", Value = 2)]
		LBTS_Apply,

		[ProtoEnum(Name = "LBTS_Idle", Value = 3)]
		LBTS_Idle,

		[ProtoEnum(Name = "LBTS_PointRace", Value = 4)]
		LBTS_PointRace,

		[ProtoEnum(Name = "LBTS_Elimination", Value = 5)]
		LBTS_Elimination,

		[ProtoEnum(Name = "LBTS_CrossIdle", Value = 6)]
		LBTS_CrossIdle,

		[ProtoEnum(Name = "LBTS_CrossPointRace", Value = 7)]
		LBTS_CrossPointRace,

		[ProtoEnum(Name = "LBTS_CrossElimination", Value = 8)]
		LBTS_CrossElimination,

		[ProtoEnum(Name = "LBTS_SeasonEnd", Value = 9)]
		LBTS_SeasonEnd
	}
}
