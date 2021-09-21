using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007A9 RID: 1961
	[ProtoContract(Name = "AuctionAllReqType")]
	public enum AuctionAllReqType
	{
		// Token: 0x040024FD RID: 9469
		[ProtoEnum(Name = "ART_REQSALE", Value = 1)]
		ART_REQSALE = 1,
		// Token: 0x040024FE RID: 9470
		[ProtoEnum(Name = "ART_QUITSALE", Value = 2)]
		ART_QUITSALE,
		// Token: 0x040024FF RID: 9471
		[ProtoEnum(Name = "ART_RESALE", Value = 3)]
		ART_RESALE,
		// Token: 0x04002500 RID: 9472
		[ProtoEnum(Name = "ART_ALLITEMBRIEF", Value = 4)]
		ART_ALLITEMBRIEF,
		// Token: 0x04002501 RID: 9473
		[ProtoEnum(Name = "ART_ITEMDATA", Value = 5)]
		ART_ITEMDATA,
		// Token: 0x04002502 RID: 9474
		[ProtoEnum(Name = "ART_MYSALE", Value = 6)]
		ART_MYSALE,
		// Token: 0x04002503 RID: 9475
		[ProtoEnum(Name = "ART_BUY", Value = 7)]
		ART_BUY,
		// Token: 0x04002504 RID: 9476
		[ProtoEnum(Name = "ART_REFRESH_FREE", Value = 8)]
		ART_REFRESH_FREE,
		// Token: 0x04002505 RID: 9477
		[ProtoEnum(Name = "ART_REFRESH_PAY", Value = 9)]
		ART_REFRESH_PAY,
		// Token: 0x04002506 RID: 9478
		[ProtoEnum(Name = "ART_TRADE_PRICE", Value = 10)]
		ART_TRADE_PRICE,
		// Token: 0x04002507 RID: 9479
		[ProtoEnum(Name = "ART_REFRESH_AUTO", Value = 11)]
		ART_REFRESH_AUTO
	}
}
