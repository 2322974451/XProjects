using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AuctionAllReqType")]
	public enum AuctionAllReqType
	{

		[ProtoEnum(Name = "ART_REQSALE", Value = 1)]
		ART_REQSALE = 1,

		[ProtoEnum(Name = "ART_QUITSALE", Value = 2)]
		ART_QUITSALE,

		[ProtoEnum(Name = "ART_RESALE", Value = 3)]
		ART_RESALE,

		[ProtoEnum(Name = "ART_ALLITEMBRIEF", Value = 4)]
		ART_ALLITEMBRIEF,

		[ProtoEnum(Name = "ART_ITEMDATA", Value = 5)]
		ART_ITEMDATA,

		[ProtoEnum(Name = "ART_MYSALE", Value = 6)]
		ART_MYSALE,

		[ProtoEnum(Name = "ART_BUY", Value = 7)]
		ART_BUY,

		[ProtoEnum(Name = "ART_REFRESH_FREE", Value = 8)]
		ART_REFRESH_FREE,

		[ProtoEnum(Name = "ART_REFRESH_PAY", Value = 9)]
		ART_REFRESH_PAY,

		[ProtoEnum(Name = "ART_TRADE_PRICE", Value = 10)]
		ART_TRADE_PRICE,

		[ProtoEnum(Name = "ART_REFRESH_AUTO", Value = 11)]
		ART_REFRESH_AUTO
	}
}
