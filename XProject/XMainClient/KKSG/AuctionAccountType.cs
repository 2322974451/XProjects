using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AuctionAccountType")]
	public enum AuctionAccountType
	{

		[ProtoEnum(Name = "AUCTACCOUNT_SALE_FAIL", Value = 1)]
		AUCTACCOUNT_SALE_FAIL = 1,

		[ProtoEnum(Name = "AUCTACCOUNT_SALE_SUCCESS", Value = 2)]
		AUCTACCOUNT_SALE_SUCCESS,

		[ProtoEnum(Name = "AUCTACCOUNT_BUY_FAIL", Value = 3)]
		AUCTACCOUNT_BUY_FAIL,

		[ProtoEnum(Name = "AUCTACCOUNT_BUY_SUCCESS", Value = 4)]
		AUCTACCOUNT_BUY_SUCCESS
	}
}
