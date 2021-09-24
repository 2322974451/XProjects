using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildAuctResultType")]
	public enum GuildAuctResultType
	{

		[ProtoEnum(Name = "GA_RESULT_BUY_NOW", Value = 1)]
		GA_RESULT_BUY_NOW = 1,

		[ProtoEnum(Name = "GA_RESULT_BUY_AUCT", Value = 2)]
		GA_RESULT_BUY_AUCT,

		[ProtoEnum(Name = "GA_RESULT_TO_WORLD", Value = 3)]
		GA_RESULT_TO_WORLD
	}
}
