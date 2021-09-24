using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HeroKillUnitType")]
	public enum HeroKillUnitType
	{

		[ProtoEnum(Name = "HeroKillUnit_Hero", Value = 1)]
		HeroKillUnit_Hero = 1,

		[ProtoEnum(Name = "HeroKillUnit_Enemy", Value = 2)]
		HeroKillUnit_Enemy
	}
}
