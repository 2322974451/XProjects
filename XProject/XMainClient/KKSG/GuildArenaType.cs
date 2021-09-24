using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildArenaType")]
	public enum GuildArenaType
	{

		[ProtoEnum(Name = "battleone", Value = 1)]
		battleone = 1,

		[ProtoEnum(Name = "battletwo", Value = 2)]
		battletwo,

		[ProtoEnum(Name = "battlethree", Value = 3)]
		battlethree,

		[ProtoEnum(Name = "battlefour", Value = 4)]
		battlefour,

		[ProtoEnum(Name = "battlefinal", Value = 5)]
		battlefinal,

		[ProtoEnum(Name = "apply", Value = 6)]
		apply,

		[ProtoEnum(Name = "resttime", Value = 0)]
		resttime = 0,

		[ProtoEnum(Name = "notopen", Value = 7)]
		notopen = 7
	}
}
