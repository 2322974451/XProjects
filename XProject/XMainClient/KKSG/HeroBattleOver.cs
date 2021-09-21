using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007E2 RID: 2018
	[ProtoContract(Name = "HeroBattleOver")]
	public enum HeroBattleOver
	{
		// Token: 0x0400264C RID: 9804
		[ProtoEnum(Name = "HeroBattleOver_Win", Value = 1)]
		HeroBattleOver_Win = 1,
		// Token: 0x0400264D RID: 9805
		[ProtoEnum(Name = "HeroBattleOver_Lose", Value = 2)]
		HeroBattleOver_Lose,
		// Token: 0x0400264E RID: 9806
		[ProtoEnum(Name = "HeroBattleOver_Draw", Value = 3)]
		HeroBattleOver_Draw
	}
}
