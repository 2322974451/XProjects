using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007E0 RID: 2016
	[ProtoContract(Name = "PayAccessDataType")]
	public enum PayAccessDataType
	{
		// Token: 0x04002642 RID: 9794
		[ProtoEnum(Name = "PayAccess_SaveAmt", Value = 1)]
		PayAccess_SaveAmt = 1,
		// Token: 0x04002643 RID: 9795
		[ProtoEnum(Name = "PayAccess_Other", Value = 2)]
		PayAccess_Other,
		// Token: 0x04002644 RID: 9796
		[ProtoEnum(Name = "PayAccess_Send", Value = 3)]
		PayAccess_Send,
		// Token: 0x04002645 RID: 9797
		[ProtoEnum(Name = "PayAccess_Consume", Value = 4)]
		PayAccess_Consume,
		// Token: 0x04002646 RID: 9798
		[ProtoEnum(Name = "PayAccess_ALL", Value = 5)]
		PayAccess_ALL
	}
}
