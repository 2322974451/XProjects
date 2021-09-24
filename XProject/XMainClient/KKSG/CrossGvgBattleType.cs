using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CrossGvgBattleType")]
	public enum CrossGvgBattleType
	{

		[ProtoEnum(Name = "CGBT_PointRace", Value = 1)]
		CGBT_PointRace = 1,

		[ProtoEnum(Name = "CGBT_Knockout", Value = 2)]
		CGBT_Knockout
	}
}
