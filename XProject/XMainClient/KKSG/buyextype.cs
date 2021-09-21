using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000773 RID: 1907
	[ProtoContract(Name = "buyextype")]
	public enum buyextype
	{
		// Token: 0x040023B1 RID: 9137
		[ProtoEnum(Name = "DIAMONE_BUY_DRAGONCOIN", Value = 1)]
		DIAMONE_BUY_DRAGONCOIN = 1,
		// Token: 0x040023B2 RID: 9138
		[ProtoEnum(Name = "DIAMONE_BUY_GOLD", Value = 2)]
		DIAMONE_BUY_GOLD,
		// Token: 0x040023B3 RID: 9139
		[ProtoEnum(Name = "DRAGONCOIN_BUY_GOLD", Value = 3)]
		DRAGONCOIN_BUY_GOLD,
		// Token: 0x040023B4 RID: 9140
		[ProtoEnum(Name = "DRAGON_BUY_FATIGUE", Value = 4)]
		DRAGON_BUY_FATIGUE,
		// Token: 0x040023B5 RID: 9141
		[ProtoEnum(Name = "DIAMOND_BUY_FATIGUE", Value = 5)]
		DIAMOND_BUY_FATIGUE,
		// Token: 0x040023B6 RID: 9142
		[ProtoEnum(Name = "DRAGONCOIN_BUY_BLUEBIRD", Value = 6)]
		DRAGONCOIN_BUY_BLUEBIRD,
		// Token: 0x040023B7 RID: 9143
		[ProtoEnum(Name = "DIAMOND_EXCHANGE_DRAGONCOIN", Value = 7)]
		DIAMOND_EXCHANGE_DRAGONCOIN
	}
}
