using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildQAType")]
	public enum GuildQAType
	{

		[ProtoEnum(Name = "NO_GUILD", Value = 0)]
		NO_GUILD,

		[ProtoEnum(Name = "BEFORE_OPEN", Value = 1)]
		BEFORE_OPEN,

		[ProtoEnum(Name = "IN_TIME_NOT_OPEN", Value = 2)]
		IN_TIME_NOT_OPEN,

		[ProtoEnum(Name = "IN_TIME_OPENING", Value = 3)]
		IN_TIME_OPENING,

		[ProtoEnum(Name = "AFTER_OPEN", Value = 4)]
		AFTER_OPEN,

		[ProtoEnum(Name = "NOT_OPEN_DAY", Value = 5)]
		NOT_OPEN_DAY
	}
}
