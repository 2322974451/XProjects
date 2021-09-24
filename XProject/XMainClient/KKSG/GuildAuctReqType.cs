using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildAuctReqType")]
	public enum GuildAuctReqType
	{

		[ProtoEnum(Name = "GART_ACT_TYPE", Value = 1)]
		GART_ACT_TYPE = 1,

		[ProtoEnum(Name = "GART_ITEM_TYPE", Value = 2)]
		GART_ITEM_TYPE,

		[ProtoEnum(Name = "GART_BUY_AUCT", Value = 5)]
		GART_BUY_AUCT = 5,

		[ProtoEnum(Name = "GART_BUY_NOW", Value = 6)]
		GART_BUY_NOW,

		[ProtoEnum(Name = "GART_AUCT_GUILD_HISTORY", Value = 7)]
		GART_AUCT_GUILD_HISTORY,

		[ProtoEnum(Name = "GART_AUCT_WORLD_HISTORY", Value = 8)]
		GART_AUCT_WORLD_HISTORY
	}
}
