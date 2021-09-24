using System;

namespace XMainClient
{

	internal class XBuffTriggerByBeHit : XBuffTrigger
	{

		public XBuffTriggerByBeHit(XBuff buff) : base(buff)
		{
			this.m_Type = base._GetTriggerParamInt(buff.BuffInfo, 0);
			this.m_Param0 = base._GetTriggerParamInt(buff.BuffInfo, 1);
		}

		public override XBuffEffectPrioriy Priority
		{
			get
			{
				return XBuffEffectPrioriy.BEP_TriggerByBeHit;
			}
		}

		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			base.OnAdd(entity, pEffectHelper);
			this.m_Entity = entity;
		}

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

		private int m_Type;

		private int m_Param0;

		private XEntity m_Entity;

		private HurtInfo m_RawInput;

		private ProjectDamageResult m_Result;
	}
}
