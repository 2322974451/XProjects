using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AuctionReqType")]
	public enum AuctionReqType
	{

		[ProtoEnum(Name = "AUCTION_ONSALE", Value = 1)]
		AUCTION_ONSALE = 1,

		[ProtoEnum(Name = "AUCTION_OUTSALE", Value = 2)]
		AUCTION_OUTSALE,

		[ProtoEnum(Name = "AUCTION_BUYNOW", Value = 3)]
		AUCTION_BUYNOW
	}
}
