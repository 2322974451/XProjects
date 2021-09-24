using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FightGroupType")]
	public enum FightGroupType
	{

		[ProtoEnum(Name = "FightEnemy", Value = 0)]
		FightEnemy,

		[ProtoEnum(Name = "FightRole", Value = 1)]
		FightRole,

		[ProtoEnum(Name = "FightNeutral", Value = 2)]
		FightNeutral,

		[ProtoEnum(Name = "FightHostility", Value = 3)]
		FightHostility,

		[ProtoEnum(Name = "FightDummy", Value = 10)]
		FightDummy = 10
	}
}
