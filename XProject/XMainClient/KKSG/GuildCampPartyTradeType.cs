using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildCampPartyTradeType")]
	public enum GuildCampPartyTradeType
	{

		[ProtoEnum(Name = "TRADE_INVITATION", Value = 1)]
		TRADE_INVITATION = 1,

		[ProtoEnum(Name = "UPDATA_TRADE_STATUS", Value = 2)]
		UPDATA_TRADE_STATUS
	}
}
