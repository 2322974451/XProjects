using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GiftIbShipStatus")]
	public enum GiftIbShipStatus
	{

		[ProtoEnum(Name = "GIFTIB_NOT_SHIPPED", Value = 0)]
		GIFTIB_NOT_SHIPPED,

		[ProtoEnum(Name = "GIFTIB_BEING_SHIPPED", Value = 1)]
		GIFTIB_BEING_SHIPPED,

		[ProtoEnum(Name = "GIFTIB_FINISH_SHIPPED", Value = 2)]
		GIFTIB_FINISH_SHIPPED
	}
}
