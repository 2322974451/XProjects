using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MythShopOP")]
	public enum MythShopOP
	{

		[ProtoEnum(Name = "MythShopQuery", Value = 1)]
		MythShopQuery = 1,

		[ProtoEnum(Name = "MythShopBuy", Value = 2)]
		MythShopBuy,

		[ProtoEnum(Name = "MythShopRefresh", Value = 3)]
		MythShopRefresh
	}
}
