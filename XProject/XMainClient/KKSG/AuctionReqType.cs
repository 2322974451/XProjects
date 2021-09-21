using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200079D RID: 1949
	[ProtoContract(Name = "AuctionReqType")]
	public enum AuctionReqType
	{
		// Token: 0x040024A4 RID: 9380
		[ProtoEnum(Name = "AUCTION_ONSALE", Value = 1)]
		AUCTION_ONSALE = 1,
		// Token: 0x040024A5 RID: 9381
		[ProtoEnum(Name = "AUCTION_OUTSALE", Value = 2)]
		AUCTION_OUTSALE,
		// Token: 0x040024A6 RID: 9382
		[ProtoEnum(Name = "AUCTION_BUYNOW", Value = 3)]
		AUCTION_BUYNOW
	}
}
