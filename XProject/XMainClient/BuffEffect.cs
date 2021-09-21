using System;

namespace XMainClient
{
	// Token: 0x02000DAE RID: 3502
	internal abstract class BuffEffect : IComparable<BuffEffect>
	{
		// Token: 0x0600BDD3 RID: 48595
		public abstract void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper);

		// Token: 0x0600BDD4 RID: 48596
		public abstract void OnRemove(XEntity entity, bool IsReplaced);

		// Token: 0x0600BDD5 RID: 48597 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnAppend(XEntity entity)
		{
		}

		// Token: 0x0600BDD6 RID: 48598 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnBattleEnd(XEntity entity)
		{
		}

		// Token: 0x1700333B RID: 13115
		// (get) Token: 0x0600BDD7 RID: 48599 RVA: 0x00277AA8 File Offset: 0x00275CA8
		public virtual XBuffEffectPrioriy Priority
		{
			get
			{
				return XBuffEffectPrioriy.BEP_START;
			}
		}

		// Token: 0x0600BDD8 RID: 48600 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnBuffEffect(HurtInfo rawInput, ProjectDamageResult result)
		{
		}

		// Token: 0x0600BDD9 RID: 48601 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnCastDamage(HurtInfo rawInput, ProjectDamageResult result)
		{
		}

		// Token: 0x0600BDDA RID: 48602 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnComboChange(uint comboCount)
		{
		}

		// Token: 0x0600BDDB RID: 48603 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnAttributeChanged(XAttrChangeEventArgs e)
		{
		}

		// Token: 0x0600BDDC RID: 48604 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnQTEStateChanged(XSkillQTEEventArgs e)
		{
		}

		// Token: 0x0600BDDD RID: 48605 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnRealDead(XRealDeadEventArgs e)
		{
		}

		// Token: 0x0600BDDE RID: 48606 RVA: 0x00277ABC File Offset: 0x00275CBC
		public virtual bool CanBuffAdd(int clearType)
		{
			return true;
		}

		// Token: 0x0600BDDF RID: 48607 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnUpdate()
		{
		}

		// Token: 0x0600BDE0 RID: 48608 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnCastSkill(HurtInfo rawInput)
		{
		}

		// Token: 0x0600BDE1 RID: 48609 RVA: 0x00277AD0 File Offset: 0x00275CD0
		public int CompareTo(BuffEffect other)
		{
			return this.Priority.CompareTo(other.Priority);
		}

		// Token: 0x1700333C RID: 13116
		// (get) Token: 0x0600BDE2 RID: 48610 RVA: 0x00277B01 File Offset: 0x00275D01
		// (set) Token: 0x0600BDE3 RID: 48611 RVA: 0x00277B09 File Offset: 0x00275D09
		public bool bValid { get; set; }
	}
}
