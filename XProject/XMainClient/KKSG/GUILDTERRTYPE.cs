using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GUILDTERRTYPE")]
	public enum GUILDTERRTYPE
	{

		[ProtoEnum(Name = "TERR_NOT_OPEN", Value = 1)]
		TERR_NOT_OPEN = 1,

		[ProtoEnum(Name = "ALLIANCE", Value = 2)]
		ALLIANCE,

		[ProtoEnum(Name = "TERR_WARING", Value = 3)]
		TERR_WARING,

		[ProtoEnum(Name = "TERR_END", Value = 4)]
		TERR_END,

		[ProtoEnum(Name = "WAITING", Value = 5)]
		WAITING
	}
}
