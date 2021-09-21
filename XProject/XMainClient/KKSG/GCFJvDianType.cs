using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007DA RID: 2010
	[ProtoContract(Name = "GCFJvDianType")]
	public enum GCFJvDianType
	{
		// Token: 0x04002625 RID: 9765
		[ProtoEnum(Name = "GCF_JUDIAN_UP", Value = 1)]
		GCF_JUDIAN_UP = 1,
		// Token: 0x04002626 RID: 9766
		[ProtoEnum(Name = "GCF_JUDIAN_MID", Value = 2)]
		GCF_JUDIAN_MID,
		// Token: 0x04002627 RID: 9767
		[ProtoEnum(Name = "GCF_JUDIAN_DOWN", Value = 3)]
		GCF_JUDIAN_DOWN
	}
}
