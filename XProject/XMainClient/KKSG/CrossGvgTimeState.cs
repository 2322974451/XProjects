using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CrossGvgTimeState")]
	public enum CrossGvgTimeState
	{

		[ProtoEnum(Name = "CGVG_NotOpen", Value = 1)]
		CGVG_NotOpen = 1,

		[ProtoEnum(Name = "CGVG_Select", Value = 2)]
		CGVG_Select,

		[ProtoEnum(Name = "CGVG_PointRace", Value = 3)]
		CGVG_PointRace,

		[ProtoEnum(Name = "CGVG_Guess", Value = 4)]
		CGVG_Guess,

		[ProtoEnum(Name = "CGVG_Knockout", Value = 5)]
		CGVG_Knockout,

		[ProtoEnum(Name = "CGVG_SeasonEnd", Value = 6)]
		CGVG_SeasonEnd
	}
}
