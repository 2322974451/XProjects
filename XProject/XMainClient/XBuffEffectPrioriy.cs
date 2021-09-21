using System;

namespace XMainClient
{
	// Token: 0x02000DAC RID: 3500
	internal enum XBuffEffectPrioriy
	{
		// Token: 0x04004D72 RID: 19826
		BEP_START,
		// Token: 0x04004D73 RID: 19827
		BEP_Default = 0,
		// Token: 0x04004D74 RID: 19828
		BEP_SpecialState_Trapped,
		// Token: 0x04004D75 RID: 19829
		BEP_TriggerByHit,
		// Token: 0x04004D76 RID: 19830
		BEP_TargetLifeAddAttack,
		// Token: 0x04004D77 RID: 19831
		BEP_ReduceDamage,
		// Token: 0x04004D78 RID: 19832
		BEP_SpecialState_Immortal,
		// Token: 0x04004D79 RID: 19833
		BEP_SpecialState_Shield,
		// Token: 0x04004D7A RID: 19834
		BEP_SpecialState_CantDie,
		// Token: 0x04004D7B RID: 19835
		BEP_TriggerByBeHit,
		// Token: 0x04004D7C RID: 19836
		BEP_DamageReflection,
		// Token: 0x04004D7D RID: 19837
		BEP_TriggerByHit_Death,
		// Token: 0x04004D7E RID: 19838
		BEP_Kill,
		// Token: 0x04004D7F RID: 19839
		BEP_END
	}
}
