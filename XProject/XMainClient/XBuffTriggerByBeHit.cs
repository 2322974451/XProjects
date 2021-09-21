using System;

namespace XMainClient
{
	// Token: 0x02000897 RID: 2199
	internal class XBuffTriggerByBeHit : XBuffTrigger
	{
		// Token: 0x060085E2 RID: 34274 RVA: 0x0010C81A File Offset: 0x0010AA1A
		public XBuffTriggerByBeHit(XBuff buff) : base(buff)
		{
			this.m_Type = base._GetTriggerParamInt(buff.BuffInfo, 0);
			this.m_Param0 = base._GetTriggerParamInt(buff.BuffInfo, 1);
		}

		// Token: 0x17002A2B RID: 10795
		// (get) Token: 0x060085E3 RID: 34275 RVA: 0x0010C84C File Offset: 0x0010AA4C
		public override XBuffEffectPrioriy Priority
		{
			get
			{
				return XBuffEffectPrioriy.BEP_TriggerByBeHit;
			}
		}

		// Token: 0x060085E4 RID: 34276 RVA: 0x0010C85F File Offset: 0x0010AA5F
		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			base.OnAdd(entity, pEffectHelper);
			this.m_Entity = entity;
		}

		// Token: 0x060085E5 RID: 34277 RVA: 0x0010C874 File Offset: 0x0010AA74
		public override void OnBuffEffect(HurtInfo rawInput, ProjectDamageResult result)
		{
			bool flag = rawInput.SkillID == 0U;
			if (!flag)
			{
				this.m_RawInput = rawInput;
				this.m_Result = result;
				base.Trigger();
			}
		}

		// Token: 0x060085E6 RID: 34278 RVA: 0x0010C8A8 File Offset: 0x0010AAA8
		public override bool CheckTriggerCondition()
		{
			int type = this.m_Type;
			if (type != 0)
			{
				if (type == 1)
				{
					bool flag = this.m_Result.Result != ProjectResultType.PJRES_IMMORTAL;
					if (flag)
					{
						return false;
					}
					bool flag2 = this.m_Param0 != 0;
					if (flag2)
					{
						XBuff buffByID = this.m_Entity.Buffs.GetBuffByID(this.m_Param0);
						bool flag3 = buffByID == null;
						if (flag3)
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		// Token: 0x040029A9 RID: 10665
		private int m_Type;

		// Token: 0x040029AA RID: 10666
		private int m_Param0;

		// Token: 0x040029AB RID: 10667
		private XEntity m_Entity;

		// Token: 0x040029AC RID: 10668
		private HurtInfo m_RawInput;

		// Token: 0x040029AD RID: 10669
		private ProjectDamageResult m_Result;
	}
}
