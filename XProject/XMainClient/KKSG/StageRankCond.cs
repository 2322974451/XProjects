using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "StageRankCond")]
	public enum StageRankCond
	{

		[ProtoEnum(Name = "StageRankCond_Time", Value = 1)]
		StageRankCond_Time = 1,

		[ProtoEnum(Name = "StageRankCond_Hppercent", Value = 2)]
		StageRankCond_Hppercent,

		[ProtoEnum(Name = "StageRankCond_Found", Value = 3)]
		StageRankCond_Found,

		[ProtoEnum(Name = "StageRankCond_Behit", Value = 4)]
		StageRankCond_Behit,

		[ProtoEnum(Name = "StageRankCond_NpcHp", Value = 5)]
		StageRankCond_NpcHp,

		[ProtoEnum(Name = "StageRankCond_Combo", Value = 6)]
		StageRankCond_Combo,

		[ProtoEnum(Name = "StageRankCond_KillEnemyScore", Value = 7)]
		StageRankCond_KillEnemyScore,

		[ProtoEnum(Name = "StageRankCond_AliveTime", Value = 8)]
		StageRankCond_AliveTime,

		[ProtoEnum(Name = "StageRankCond_TotalKillEnemyScore", Value = 9)]
		StageRankCond_TotalKillEnemyScore
	}
}
