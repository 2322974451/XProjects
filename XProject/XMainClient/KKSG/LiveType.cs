using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LiveType")]
	public enum LiveType
	{

		[ProtoEnum(Name = "LIVE_RECOMMEND", Value = 1)]
		LIVE_RECOMMEND = 1,

		[ProtoEnum(Name = "LIVE_PVP", Value = 2)]
		LIVE_PVP,

		[ProtoEnum(Name = "LIVE_NEST", Value = 3)]
		LIVE_NEST,

		[ProtoEnum(Name = "LIVE_PROTECTCAPTAIN", Value = 4)]
		LIVE_PROTECTCAPTAIN,

		[ProtoEnum(Name = "LIVE_GUILDBATTLE", Value = 5)]
		LIVE_GUILDBATTLE,

		[ProtoEnum(Name = "LIVE_DRAGON", Value = 6)]
		LIVE_DRAGON,

		[ProtoEnum(Name = "LIVE_FRIEND", Value = 7)]
		LIVE_FRIEND,

		[ProtoEnum(Name = "LIVE_GUILD", Value = 8)]
		LIVE_GUILD,

		[ProtoEnum(Name = "LIVE_FRIENDANDGUILD", Value = 9)]
		LIVE_FRIENDANDGUILD,

		[ProtoEnum(Name = "LIVE_HEROBATTLE", Value = 10)]
		LIVE_HEROBATTLE,

		[ProtoEnum(Name = "LIVE_LEAGUEBATTLE", Value = 11)]
		LIVE_LEAGUEBATTLE,

		[ProtoEnum(Name = "LIVE_PVP2", Value = 12)]
		LIVE_PVP2,

		[ProtoEnum(Name = "LIVE_CUSTOMPK", Value = 13)]
		LIVE_CUSTOMPK,

		[ProtoEnum(Name = "LIVE_CROSSGVG", Value = 14)]
		LIVE_CROSSGVG,

		[ProtoEnum(Name = "LIVE_MAX", Value = 15)]
		LIVE_MAX
	}
}
