using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AbyssFlameStage")]
	public enum AbyssFlameStage
	{

		[ProtoEnum(Name = "ABYSS_NONE_FLAME", Value = 1)]
		ABYSS_NONE_FLAME = 1,

		[ProtoEnum(Name = "ABYSS_ON_FLAME", Value = 2)]
		ABYSS_ON_FLAME,

		[ProtoEnum(Name = "ABYSS_WIN_FLAME", Value = 3)]
		ABYSS_WIN_FLAME
	}
}
