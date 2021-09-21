using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200074E RID: 1870
	[ProtoContract(Name = "BattleChestRewardType")]
	public enum BattleChestRewardType
	{
		// Token: 0x04002268 RID: 8808
		[ProtoEnum(Name = "GOLD_CHEST", Value = 1)]
		GOLD_CHEST = 1,
		// Token: 0x04002269 RID: 8809
		[ProtoEnum(Name = "SILVER_CHEST", Value = 2)]
		SILVER_CHEST,
		// Token: 0x0400226A RID: 8810
		[ProtoEnum(Name = "COPPER_CHEST", Value = 3)]
		COPPER_CHEST,
		// Token: 0x0400226B RID: 8811
		[ProtoEnum(Name = "WOOD_CHEST", Value = 4)]
		WOOD_CHEST
	}
}
