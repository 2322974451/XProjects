using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildCardOp")]
	public enum GuildCardOp
	{

		[ProtoEnum(Name = "GuildCard_Query", Value = 1)]
		GuildCard_Query = 1,

		[ProtoEnum(Name = "GuildCard_Start", Value = 2)]
		GuildCard_Start,

		[ProtoEnum(Name = "GuildCard_Change", Value = 3)]
		GuildCard_Change,

		[ProtoEnum(Name = "GuildCard_End", Value = 4)]
		GuildCard_End
	}
}
