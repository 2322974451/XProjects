using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MarriageOpType")]
	public enum MarriageOpType
	{

		[ProtoEnum(Name = "MarriageOpType_MarryApply", Value = 1)]
		MarriageOpType_MarryApply = 1,

		[ProtoEnum(Name = "MarriageOpType_MarryAgree", Value = 2)]
		MarriageOpType_MarryAgree,

		[ProtoEnum(Name = "MarriageOpType_MarryRefuse", Value = 3)]
		MarriageOpType_MarryRefuse,

		[ProtoEnum(Name = "MarriageOpType_Divorce", Value = 4)]
		MarriageOpType_Divorce,

		[ProtoEnum(Name = "MarriageOpType_DivorceCancel", Value = 5)]
		MarriageOpType_DivorceCancel,

		[ProtoEnum(Name = "MarriageOpType_Max", Value = 6)]
		MarriageOpType_Max
	}
}
