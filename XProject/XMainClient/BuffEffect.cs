using System;

namespace XMainClient
{

	internal abstract class BuffEffect : IComparable<BuffEffect>
	{

		public abstract void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper);

		public abstract void OnRemove(XEntity entity, bool IsReplaced);

		public virtual void OnAppend(XEntity entity)
		{
		}

		public virtual void OnBattleEnd(XEntity entity)
		{
		}

		public virtual XBuffEffectPrioriy Priority
		{
			get
			{
				return XBuffEffectPrioriy.BEP_START;
			}
		}

		public virtual void OnBuffEffect(HurtInfo rawInput, ProjectDamageResult result)
		{
		}

		public virtual void OnCastDamage(HurtInfo rawInput, ProjectDamageResult result)
		{
		}

		public virtual void OnComboChange(uint comboCount)
		{
		}

		public virtual void OnAttributeChanged(XAttrChangeEventArgs e)
		{
		}

		public virtual void OnQTEStateChanged(XSkillQTEEventArgs e)
		{
		}

		public virtual void OnRealDead(XRealDeadEventArgs e)
		{
		}

		public virtual bool CanBuffAdd(int clearType)
		{
			return true;
		}

		public virtual void OnUpdate()
		{
		}

		public virtual void OnCastSkill(HurtInfo rawInput)
		{
		}

		public int CompareTo(BuffEffect other)
		{
			return this.Priority.CompareTo(other.Priority);
		}

		public bool bValid { get; set; }
	}
}
