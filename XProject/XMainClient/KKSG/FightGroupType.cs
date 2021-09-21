using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000763 RID: 1891
	[ProtoContract(Name = "FightGroupType")]
	public enum FightGroupType
	{
		// Token: 0x0400234E RID: 9038
		[ProtoEnum(Name = "FightEnemy", Value = 0)]
		FightEnemy,
		// Token: 0x0400234F RID: 9039
		[ProtoEnum(Name = "FightRole", Value = 1)]
		FightRole,
		// Token: 0x04002350 RID: 9040
		[ProtoEnum(Name = "FightNeutral", Value = 2)]
		FightNeutral,
		// Token: 0x04002351 RID: 9041
		[ProtoEnum(Name = "FightHostility", Value = 3)]
		FightHostility,
		// Token: 0x04002352 RID: 9042
		[ProtoEnum(Name = "FightDummy", Value = 10)]
		FightDummy = 10
	}
}
