using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "G2M_MarriageOpType")]
	public enum G2M_MarriageOpType
	{

		[ProtoEnum(Name = "G2M_MarriageOpType_ReqInfo", Value = 1)]
		G2M_MarriageOpType_ReqInfo = 1,

		[ProtoEnum(Name = "G2M_MarriageOpType_AddLevelValue", Value = 2)]
		G2M_MarriageOpType_AddLevelValue
	}
}
