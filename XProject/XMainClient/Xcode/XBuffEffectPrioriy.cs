using System;

namespace XMainClient
{

	internal enum XBuffEffectPrioriy
	{

		BEP_START,

		BEP_Default = 0,

		BEP_SpecialState_Trapped,

		BEP_TriggerByHit,

		BEP_TargetLifeAddAttack,

		BEP_ReduceDamage,

		BEP_SpecialState_Immortal,

		BEP_SpecialState_Shield,

		BEP_SpecialState_CantDie,

		BEP_TriggerByBeHit,

		BEP_DamageReflection,

		BEP_TriggerByHit_Death,

		BEP_Kill,

		BEP_END
	}
}
