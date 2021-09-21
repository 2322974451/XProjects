using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200080A RID: 2058
	[ProtoContract(Name = "GiftIbShipStatus")]
	public enum GiftIbShipStatus
	{
		// Token: 0x0400273B RID: 10043
		[ProtoEnum(Name = "GIFTIB_NOT_SHIPPED", Value = 0)]
		GIFTIB_NOT_SHIPPED,
		// Token: 0x0400273C RID: 10044
		[ProtoEnum(Name = "GIFTIB_BEING_SHIPPED", Value = 1)]
		GIFTIB_BEING_SHIPPED,
		// Token: 0x0400273D RID: 10045
		[ProtoEnum(Name = "GIFTIB_FINISH_SHIPPED", Value = 2)]
		GIFTIB_FINISH_SHIPPED
	}
}
