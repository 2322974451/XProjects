using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeagueEliType")]
	public enum LeagueEliType
	{

		[ProtoEnum(Name = "LeagueEliType_None", Value = 1)]
		LeagueEliType_None = 1,

		[ProtoEnum(Name = "LeagueEliType_Self", Value = 2)]
		LeagueEliType_Self,

		[ProtoEnum(Name = "LeagueEliType_Cross", Value = 3)]
		LeagueEliType_Cross
	}
}
