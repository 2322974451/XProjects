using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeagueBattleFightState")]
	public enum LeagueBattleFightState
	{

		[ProtoEnum(Name = "LBFight_None", Value = 1)]
		LBFight_None = 1,

		[ProtoEnum(Name = "LBFight_Wait", Value = 2)]
		LBFight_Wait,

		[ProtoEnum(Name = "LBFight_Fight", Value = 3)]
		LBFight_Fight,

		[ProtoEnum(Name = "LBFight_Result", Value = 4)]
		LBFight_Result
	}
}
