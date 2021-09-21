using System;

namespace XMainClient
{
	// Token: 0x02000B04 RID: 2820
	internal enum CombatEffectType
	{
		// Token: 0x04003D1C RID: 15644
		CET_INVALID,
		// Token: 0x04003D1D RID: 15645
		CET_Buff_ChangeAttribute,
		// Token: 0x04003D1E RID: 15646
		CET_Buff_HP,
		// Token: 0x04003D1F RID: 15647
		CET_Buff_Duration,
		// Token: 0x04003D20 RID: 15648
		CET_Buff_TriggerRate,
		// Token: 0x04003D21 RID: 15649
		CET_Buff_AuraRadius,
		// Token: 0x04003D22 RID: 15650
		CET_Buff_ReduceCD,
		// Token: 0x04003D23 RID: 15651
		CET_Buff_ChangeSkillDamage,
		// Token: 0x04003D24 RID: 15652
		CET_Buff_ChangeDamage_Cast,
		// Token: 0x04003D25 RID: 15653
		CET_Buff_ChangeDamage_Receive,
		// Token: 0x04003D26 RID: 15654
		CET_Buff_DOTorHOT,
		// Token: 0x04003D27 RID: 15655
		CET_Skill_Damage = 1001,
		// Token: 0x04003D28 RID: 15656
		CET_Skill_CD,
		// Token: 0x04003D29 RID: 15657
		CET_Skill_AddBuff,
		// Token: 0x04003D2A RID: 15658
		CET_Skill_AddMobBuff
	}
}
