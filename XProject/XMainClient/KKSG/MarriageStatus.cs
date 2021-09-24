using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MarriageStatus")]
	public enum MarriageStatus
	{

		[ProtoEnum(Name = "MarriageStatus_Null", Value = 1)]
		MarriageStatus_Null = 1,

		[ProtoEnum(Name = "MarriageStatus_Marriaged", Value = 2)]
		MarriageStatus_Marriaged,

		[ProtoEnum(Name = "MarriageStatus_WeddingHoldingNoCar", Value = 3)]
		MarriageStatus_WeddingHoldingNoCar,

		[ProtoEnum(Name = "MarriageStatus_WeddingHoldedNoCar", Value = 4)]
		MarriageStatus_WeddingHoldedNoCar,

		[ProtoEnum(Name = "MarriageStatus_WeddingCarNoWedding", Value = 5)]
		MarriageStatus_WeddingCarNoWedding,

		[ProtoEnum(Name = "MarriageStatus_WeddingHoldingAndCar", Value = 6)]
		MarriageStatus_WeddingHoldingAndCar,

		[ProtoEnum(Name = "MarriageStatus_WeddingHoldedAndCar", Value = 7)]
		MarriageStatus_WeddingHoldedAndCar,

		[ProtoEnum(Name = "MarriageStatus_DivorceApply", Value = 8)]
		MarriageStatus_DivorceApply,

		[ProtoEnum(Name = "MarriageStatus_Divorced", Value = 9)]
		MarriageStatus_Divorced,

		[ProtoEnum(Name = "MarriageStatus_Max", Value = 10)]
		MarriageStatus_Max
	}
}
