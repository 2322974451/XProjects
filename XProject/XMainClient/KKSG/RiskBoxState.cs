using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007A5 RID: 1957
	[ProtoContract(Name = "RiskBoxState")]
	public enum RiskBoxState
	{
		// Token: 0x040024E8 RID: 9448
		[ProtoEnum(Name = "RISK_BOX_LOCKED", Value = 1)]
		RISK_BOX_LOCKED = 1,
		// Token: 0x040024E9 RID: 9449
		[ProtoEnum(Name = "RISK_BOX_UNLOCKED", Value = 2)]
		RISK_BOX_UNLOCKED,
		// Token: 0x040024EA RID: 9450
		[ProtoEnum(Name = "RISK_BOX_CANGETREWARD", Value = 3)]
		RISK_BOX_CANGETREWARD,
		// Token: 0x040024EB RID: 9451
		[ProtoEnum(Name = "RISK_BOX_GETREWARD", Value = 4)]
		RISK_BOX_GETREWARD,
		// Token: 0x040024EC RID: 9452
		[ProtoEnum(Name = "RISK_BOX_DELETE", Value = 5)]
		RISK_BOX_DELETE
	}
}
