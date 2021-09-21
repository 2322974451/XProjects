using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000819 RID: 2073
	[ProtoContract(Name = "MarriageOpType")]
	public enum MarriageOpType
	{
		// Token: 0x04002774 RID: 10100
		[ProtoEnum(Name = "MarriageOpType_MarryApply", Value = 1)]
		MarriageOpType_MarryApply = 1,
		// Token: 0x04002775 RID: 10101
		[ProtoEnum(Name = "MarriageOpType_MarryAgree", Value = 2)]
		MarriageOpType_MarryAgree,
		// Token: 0x04002776 RID: 10102
		[ProtoEnum(Name = "MarriageOpType_MarryRefuse", Value = 3)]
		MarriageOpType_MarryRefuse,
		// Token: 0x04002777 RID: 10103
		[ProtoEnum(Name = "MarriageOpType_Divorce", Value = 4)]
		MarriageOpType_Divorce,
		// Token: 0x04002778 RID: 10104
		[ProtoEnum(Name = "MarriageOpType_DivorceCancel", Value = 5)]
		MarriageOpType_DivorceCancel,
		// Token: 0x04002779 RID: 10105
		[ProtoEnum(Name = "MarriageOpType_Max", Value = 6)]
		MarriageOpType_Max
	}
}
