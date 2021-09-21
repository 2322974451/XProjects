using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007A4 RID: 1956
	[ProtoContract(Name = "RiskGridType")]
	public enum RiskGridType
	{
		// Token: 0x040024E1 RID: 9441
		[ProtoEnum(Name = "RISK_GRID_EMPTY", Value = 1)]
		RISK_GRID_EMPTY = 1,
		// Token: 0x040024E2 RID: 9442
		[ProtoEnum(Name = "RISK_GRID_NORMALREWARD", Value = 2)]
		RISK_GRID_NORMALREWARD,
		// Token: 0x040024E3 RID: 9443
		[ProtoEnum(Name = "RISK_GRID_REWARDBOX", Value = 3)]
		RISK_GRID_REWARDBOX,
		// Token: 0x040024E4 RID: 9444
		[ProtoEnum(Name = "RISK_GRID_ADVENTURE", Value = 4)]
		RISK_GRID_ADVENTURE,
		// Token: 0x040024E5 RID: 9445
		[ProtoEnum(Name = "RISK_GRID_DICE", Value = 5)]
		RISK_GRID_DICE,
		// Token: 0x040024E6 RID: 9446
		[ProtoEnum(Name = "RISK_GRID_MAX", Value = 6)]
		RISK_GRID_MAX
	}
}
