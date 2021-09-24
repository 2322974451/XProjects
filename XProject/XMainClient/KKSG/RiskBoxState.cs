using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RiskBoxState")]
	public enum RiskBoxState
	{

		[ProtoEnum(Name = "RISK_BOX_LOCKED", Value = 1)]
		RISK_BOX_LOCKED = 1,

		[ProtoEnum(Name = "RISK_BOX_UNLOCKED", Value = 2)]
		RISK_BOX_UNLOCKED,

		[ProtoEnum(Name = "RISK_BOX_CANGETREWARD", Value = 3)]
		RISK_BOX_CANGETREWARD,

		[ProtoEnum(Name = "RISK_BOX_GETREWARD", Value = 4)]
		RISK_BOX_GETREWARD,

		[ProtoEnum(Name = "RISK_BOX_DELETE", Value = 5)]
		RISK_BOX_DELETE
	}
}
