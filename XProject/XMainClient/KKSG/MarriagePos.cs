using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200081C RID: 2076
	[ProtoContract(Name = "MarriagePos")]
	public enum MarriagePos
	{
		// Token: 0x0400278F RID: 10127
		[ProtoEnum(Name = "MarriagePos_Null", Value = 1)]
		MarriagePos_Null = 1,
		// Token: 0x04002790 RID: 10128
		[ProtoEnum(Name = "MarriagePos_Husband", Value = 2)]
		MarriagePos_Husband,
		// Token: 0x04002791 RID: 10129
		[ProtoEnum(Name = "MarriagePos_Wife", Value = 3)]
		MarriagePos_Wife,
		// Token: 0x04002792 RID: 10130
		[ProtoEnum(Name = "Marriage_Max", Value = 4)]
		Marriage_Max
	}
}
