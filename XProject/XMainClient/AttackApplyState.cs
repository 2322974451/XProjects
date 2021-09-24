using System;

namespace XMainClient
{

	internal abstract class AttackApplyState
	{

		public abstract int GetStateMask();

		public abstract bool IsApplyState(XEntity entity);

		public abstract bool IsDefenseState(XEntity entity);

		public virtual void ApplyState(XEntity caster, ProjectDamageResult result)
		{
			result.Flag |= this.GetStateMask();
		}
	}
}
