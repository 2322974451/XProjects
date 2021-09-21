using System;

namespace XMainClient
{
	// Token: 0x02000D4A RID: 3402
	internal abstract class AttackApplyState
	{
		// Token: 0x0600BC2D RID: 48173
		public abstract int GetStateMask();

		// Token: 0x0600BC2E RID: 48174
		public abstract bool IsApplyState(XEntity entity);

		// Token: 0x0600BC2F RID: 48175
		public abstract bool IsDefenseState(XEntity entity);

		// Token: 0x0600BC30 RID: 48176 RVA: 0x0026C940 File Offset: 0x0026AB40
		public virtual void ApplyState(XEntity caster, ProjectDamageResult result)
		{
			result.Flag |= this.GetStateMask();
		}
	}
}
