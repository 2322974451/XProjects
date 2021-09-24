using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HeroBattleOver")]
	public enum HeroBattleOver
	{

		[ProtoEnum(Name = "HeroBattleOver_Win", Value = 1)]
		HeroBattleOver_Win = 1,

		[ProtoEnum(Name = "HeroBattleOver_Lose", Value = 2)]
		HeroBattleOver_Lose,

		[ProtoEnum(Name = "HeroBattleOver_Draw", Value = 3)]
		HeroBattleOver_Draw
	}
}
