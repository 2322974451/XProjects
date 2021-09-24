using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkyCraftMatchNtfType")]
	public enum SkyCraftMatchNtfType
	{

		[ProtoEnum(Name = "SCMN_Start", Value = 1)]
		SCMN_Start = 1,

		[ProtoEnum(Name = "SCMN_Stop", Value = 2)]
		SCMN_Stop,

		[ProtoEnum(Name = "SCMN_Timeout", Value = 3)]
		SCMN_Timeout
	}
}
