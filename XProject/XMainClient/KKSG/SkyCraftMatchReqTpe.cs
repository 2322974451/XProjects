using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkyCraftMatchReqTpe")]
	public enum SkyCraftMatchReqTpe
	{

		[ProtoEnum(Name = "SCMR_Match", Value = 1)]
		SCMR_Match = 1,

		[ProtoEnum(Name = "SCMR_CancelMatch", Value = 2)]
		SCMR_CancelMatch
	}
}
