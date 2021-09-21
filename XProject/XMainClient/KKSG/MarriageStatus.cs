using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200081A RID: 2074
	[ProtoContract(Name = "MarriageStatus")]
	public enum MarriageStatus
	{
		// Token: 0x0400277B RID: 10107
		[ProtoEnum(Name = "MarriageStatus_Null", Value = 1)]
		MarriageStatus_Null = 1,
		// Token: 0x0400277C RID: 10108
		[ProtoEnum(Name = "MarriageStatus_Marriaged", Value = 2)]
		MarriageStatus_Marriaged,
		// Token: 0x0400277D RID: 10109
		[ProtoEnum(Name = "MarriageStatus_WeddingHoldingNoCar", Value = 3)]
		MarriageStatus_WeddingHoldingNoCar,
		// Token: 0x0400277E RID: 10110
		[ProtoEnum(Name = "MarriageStatus_WeddingHoldedNoCar", Value = 4)]
		MarriageStatus_WeddingHoldedNoCar,
		// Token: 0x0400277F RID: 10111
		[ProtoEnum(Name = "MarriageStatus_WeddingCarNoWedding", Value = 5)]
		MarriageStatus_WeddingCarNoWedding,
		// Token: 0x04002780 RID: 10112
		[ProtoEnum(Name = "MarriageStatus_WeddingHoldingAndCar", Value = 6)]
		MarriageStatus_WeddingHoldingAndCar,
		// Token: 0x04002781 RID: 10113
		[ProtoEnum(Name = "MarriageStatus_WeddingHoldedAndCar", Value = 7)]
		MarriageStatus_WeddingHoldedAndCar,
		// Token: 0x04002782 RID: 10114
		[ProtoEnum(Name = "MarriageStatus_DivorceApply", Value = 8)]
		MarriageStatus_DivorceApply,
		// Token: 0x04002783 RID: 10115
		[ProtoEnum(Name = "MarriageStatus_Divorced", Value = 9)]
		MarriageStatus_Divorced,
		// Token: 0x04002784 RID: 10116
		[ProtoEnum(Name = "MarriageStatus_Max", Value = 10)]
		MarriageStatus_Max
	}
}
