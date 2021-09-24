using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RiskGridType")]
	public enum RiskGridType
	{

		[ProtoEnum(Name = "RISK_GRID_EMPTY", Value = 1)]
		RISK_GRID_EMPTY = 1,

		[ProtoEnum(Name = "RISK_GRID_NORMALREWARD", Value = 2)]
		RISK_GRID_NORMALREWARD,

		[ProtoEnum(Name = "RISK_GRID_REWARDBOX", Value = 3)]
		RISK_GRID_REWARDBOX,

		[ProtoEnum(Name = "RISK_GRID_ADVENTURE", Value = 4)]
		RISK_GRID_ADVENTURE,

		[ProtoEnum(Name = "RISK_GRID_DICE", Value = 5)]
		RISK_GRID_DICE,

		[ProtoEnum(Name = "RISK_GRID_MAX", Value = 6)]
		RISK_GRID_MAX
	}
}
