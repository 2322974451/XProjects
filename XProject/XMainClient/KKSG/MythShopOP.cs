using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000754 RID: 1876
	[ProtoContract(Name = "MythShopOP")]
	public enum MythShopOP
	{
		// Token: 0x040022AD RID: 8877
		[ProtoEnum(Name = "MythShopQuery", Value = 1)]
		MythShopQuery = 1,
		// Token: 0x040022AE RID: 8878
		[ProtoEnum(Name = "MythShopBuy", Value = 2)]
		MythShopBuy,
		// Token: 0x040022AF RID: 8879
		[ProtoEnum(Name = "MythShopRefresh", Value = 3)]
		MythShopRefresh
	}
}
