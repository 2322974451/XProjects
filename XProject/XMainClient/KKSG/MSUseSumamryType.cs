using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200079A RID: 1946
	[ProtoContract(Name = "MSUseSumamryType")]
	public enum MSUseSumamryType
	{
		// Token: 0x0400249A RID: 9370
		[ProtoEnum(Name = "MSUS_GET", Value = 1)]
		MSUS_GET = 1,
		// Token: 0x0400249B RID: 9371
		[ProtoEnum(Name = "MSUS_FREE", Value = 2)]
		MSUS_FREE
	}
}
