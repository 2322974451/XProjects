using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuffTriggerByHit : XBuffTrigger
	{

		public override XBuffEffectPrioriy Priority
		{
			get
			{
				bool flag = this.m_Type == 3;
				XBuffEffectPrioriy result;
				if (flag)
				{
					result = XBuffEffectPrioriy.BEP_TriggerByHit_Death;
				}
				else
				{
					result = XBuffEffectPrioriy.BEP_TriggerByHit;
				}
				return result;
			}
		}

		public XBuffTriggerByHit(XBuff buff) : base(buff)
		{
			this.m_Type = base._GetTriggerParamInt(buff.BuffInfo, 0);
			this.m_SpecifiedSkillsSet = buff.RelevantSkills;
			int type = this.m_Type;
			if (type != 2)
			{
				if (type == 5)
				{
					this.m_SpecifiedBuffID = base._GetTriggerParamInt(buff.BuffInfo, 1);
				}
			}
			else
			{
				this.m_CriticalChangeRatio = Math.Max(0.0, 1.0 + (double)(base._GetTriggerParam(buff.BuffInfo, 1) / 100f));
			}
		}

		public override bool CheckTriggerCondition()
		{
			bool flag = this.m_SpecifiedSkillsSet != null && (this.m_RawInput == null || !this.m_SpecifiedSkillsSet.Contains(this.m_RawInput.SkillID));
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				switch (this.m_Type)
				{
				case 0:
					return true;
				case 1:
				{
					bool flag2 = this.m_RawInput != null && base.Entity.SkillMgr != null && base.Entity.SkillMgr.IsPhysicalAttack(this.m_RawInput.SkillID);
					if (flag2)
					{
						return true;
					}
					break;
				}
				case 2:
				{
					bool flag3 = (this.m_Result.Flag & XFastEnumIntEqualityComparer<DamageFlag>.ToInt(DamageFlag.DMGFLAG_CRITICAL)) != 0;
					if (flag3)
					{
						return true;
					}
					break;
				}
				case 3:
				{
					bool isTargetDead = this.m_Result.IsTargetDead;
					if (isTargetDead)
					{
						return true;
					}
					bool flag4 = this.m_RawInput != null && this.m_RawInput.Target != null && !this.m_RawInput.Target.Deprecated && this.m_RawInput.Target.Attributes != null;
					if (flag4)
					{
						return this.m_RawInput.Target.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic) - this.m_Result.Value <= 0.0;
					}
					break;
				}
				case 5:
				{
					bool flag5 = this.m_RawInput != null && this.m_RawInput.Target != null && !this.m_RawInput.Target.Deprecated;
					if (flag5)
					{
						XBuffComponent buffs = this.m_RawInput.Target.Buffs;
						bool flag6 = buffs != null && buffs.GetBuffByID(this.m_SpecifiedBuffID) != null;
						if (flag6)
						{
							base._SetTarget(this.m_RawInput.Target);
							return true;
						}
					}
					break;
				}
				}
				result = false;
			}
			return result;
		}

		public override void OnCastDamage(HurtInfo rawInput, ProjectDamageResult result)
		{
			bool flag = rawInput.SkillID == 0U;
			if (!flag)
			{
				this.m_RawInput = rawInput;
				this.m_Result = result;
				base.Trigger();
			}
		}

		protected override void OnTrigger()
		{
			base.OnTrigger();
			int type = this.m_Type;
			if (type == 2)
			{
				bool flag = this.m_CriticalChangeRatio != 1.0;
				if (flag)
				{
					this.m_Result.Value *= this.m_CriticalChangeRatio;
				}
			}
		}

		private int m_Type;

		private HurtInfo m_RawInput;

		private ProjectDamageResult m_Result;

		private HashSet<uint> m_SpecifiedSkillsSet;

		private int m_SpecifiedBuffID;

		private double m_CriticalChangeRatio = 0.0;
	}
}
