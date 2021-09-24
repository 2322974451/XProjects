using System;

namespace XMainClient
{

	internal enum CombatEffectType
	{

		CET_INVALID,

		CET_Buff_ChangeAttribute,

		CET_Buff_HP,

		CET_Buff_Duration,

		CET_Buff_TriggerRate,

		CET_Buff_AuraRadius,

		CET_Buff_ReduceCD,

		CET_Buff_ChangeSkillDamage,

		CET_Buff_ChangeDamage_Cast,

		CET_Buff_ChangeDamage_Receive,

		CET_Buff_DOTorHOT,

		CET_Skill_Damage = 1001,

		CET_Skill_CD,

		CET_Skill_AddBuff,

		CET_Skill_AddMobBuff
	}
}
