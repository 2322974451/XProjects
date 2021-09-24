using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "KMatchType")]
	public enum KMatchType
	{

		[ProtoEnum(Name = "KMT_NONE", Value = 0)]
		KMT_NONE,

		[ProtoEnum(Name = "KMT_EXP", Value = 1)]
		KMT_EXP,

		[ProtoEnum(Name = "KMT_PVP", Value = 2)]
		KMT_PVP,

		[ProtoEnum(Name = "KMT_HERO", Value = 3)]
		KMT_HERO,

		[ProtoEnum(Name = "KMT_PK", Value = 4)]
		KMT_PK,

		[ProtoEnum(Name = "KMT_LEAGUE", Value = 5)]
		KMT_LEAGUE,

		[ProtoEnum(Name = "KMT_SKYCRAFT", Value = 6)]
		KMT_SKYCRAFT,

		[ProtoEnum(Name = "KMT_PKTWO", Value = 7)]
		KMT_PKTWO,

		[ProtoEnum(Name = "KMT_MOBA", Value = 8)]
		KMT_MOBA,

		[ProtoEnum(Name = "KMT_WEEKEND_ACT", Value = 9)]
		KMT_WEEKEND_ACT,

		[ProtoEnum(Name = "KMT_CUSTOM_PKTWO", Value = 10)]
		KMT_CUSTOM_PKTWO,

		[ProtoEnum(Name = "KMT_SURVIVE", Value = 11)]
		KMT_SURVIVE
	}
}
