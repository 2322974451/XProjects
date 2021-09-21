using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000768 RID: 1896
	[ProtoContract(Name = "AuctionAccountType")]
	public enum AuctionAccountType
	{
		// Token: 0x0400237C RID: 9084
		[ProtoEnum(Name = "AUCTACCOUNT_SALE_FAIL", Value = 1)]
		AUCTACCOUNT_SALE_FAIL = 1,
		// Token: 0x0400237D RID: 9085
		[ProtoEnum(Name = "AUCTACCOUNT_SALE_SUCCESS", Value = 2)]
		AUCTACCOUNT_SALE_SUCCESS,
		// Token: 0x0400237E RID: 9086
		[ProtoEnum(Name = "AUCTACCOUNT_BUY_FAIL", Value = 3)]
		AUCTACCOUNT_BUY_FAIL,
		// Token: 0x0400237F RID: 9087
		[ProtoEnum(Name = "AUCTACCOUNT_BUY_SUCCESS", Value = 4)]
		AUCTACCOUNT_BUY_SUCCESS
	}
}
