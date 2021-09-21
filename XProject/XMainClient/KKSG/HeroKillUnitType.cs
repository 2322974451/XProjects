using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000811 RID: 2065
	[ProtoContract(Name = "HeroKillUnitType")]
	public enum HeroKillUnitType
	{
		// Token: 0x04002758 RID: 10072
		[ProtoEnum(Name = "HeroKillUnit_Hero", Value = 1)]
		HeroKillUnit_Hero = 1,
		// Token: 0x04002759 RID: 10073
		[ProtoEnum(Name = "HeroKillUnit_Enemy", Value = 2)]
		HeroKillUnit_Enemy
	}
}
