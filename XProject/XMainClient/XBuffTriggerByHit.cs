using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200089E RID: 2206
	internal class XBuffTriggerByHit : XBuffTrigger
	{
		// Token: 0x17002A2D RID: 10797
		// (get) Token: 0x06008603 RID: 34307 RVA: 0x0010CED4 File Offset: 0x0010B0D4
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

		// Token: 0x06008604 RID: 34308 RVA: 0x0010CEFC File Offset: 0x0010B0FC
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

		// Token: 0x06008605 RID: 34309 RVA: 0x0010CFA0 File Offset: 0x0010B1A0
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

		// Token: 0x06008606 RID: 34310 RVA: 0x0010D198 File Offset: 0x0010B398
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

		// Token: 0x06008607 RID: 34311 RVA: 0x0010D1CC File Offset: 0x0010B3CC
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

		// Token: 0x040029BB RID: 10683
		private int m_Type;

		// Token: 0x040029BC RID: 10684
		private HurtInfo m_RawInput;

		// Token: 0x040029BD RID: 10685
		private ProjectDamageResult m_Result;

		// Token: 0x040029BE RID: 10686
		private HashSet<uint> m_SpecifiedSkillsSet;

		// Token: 0x040029BF RID: 10687
		private int m_SpecifiedBuffID;

		// Token: 0x040029C0 RID: 10688
		private double m_CriticalChangeRatio = 0.0;
	}
}
