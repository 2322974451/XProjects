using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "buyextype")]
	public enum buyextype
	{

		[ProtoEnum(Name = "DIAMONE_BUY_DRAGONCOIN", Value = 1)]
		DIAMONE_BUY_DRAGONCOIN = 1,

		[ProtoEnum(Name = "DIAMONE_BUY_GOLD", Value = 2)]
		DIAMONE_BUY_GOLD,

		[ProtoEnum(Name = "DRAGONCOIN_BUY_GOLD", Value = 3)]
		DRAGONCOIN_BUY_GOLD,

		[ProtoEnum(Name = "DRAGON_BUY_FATIGUE", Value = 4)]
		DRAGON_BUY_FATIGUE,

		[ProtoEnum(Name = "DIAMOND_BUY_FATIGUE", Value = 5)]
		DIAMOND_BUY_FATIGUE,

		[ProtoEnum(Name = "DRAGONCOIN_BUY_BLUEBIRD", Value = 6)]
		DRAGONCOIN_BUY_BLUEBIRD,

		[ProtoEnum(Name = "DIAMOND_EXCHANGE_DRAGONCOIN", Value = 7)]
		DIAMOND_EXCHANGE_DRAGONCOIN
	}
}
