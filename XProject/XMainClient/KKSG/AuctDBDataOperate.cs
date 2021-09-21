using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200076D RID: 1901
	[ProtoContract(Name = "AuctDBDataOperate")]
	public enum AuctDBDataOperate
	{
		// Token: 0x04002398 RID: 9112
		[ProtoEnum(Name = "AUCTDBDATA_INSERT", Value = 1)]
		AUCTDBDATA_INSERT = 1,
		// Token: 0x04002399 RID: 9113
		[ProtoEnum(Name = "AUCTDBDATA_UPDATE", Value = 2)]
		AUCTDBDATA_UPDATE,
		// Token: 0x0400239A RID: 9114
		[ProtoEnum(Name = "AUCTDBDATA_DELETE", Value = 3)]
		AUCTDBDATA_DELETE
	}
}
