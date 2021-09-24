using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuffLifeSteal : BuffEffect
	{

		public static bool TryCreate(BuffTable.RowData rowData, XBuff buff)
		{
			bool flag = rowData.LifeSteal[0] == 0f;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				buff.AddEffect(new XBuffLifeSteal(ref rowData.LifeSteal, buff));
				result = true;
			}
			return result;
		}

		public XBuffLifeSteal(ref SeqRef<float> data, XBuff _Buff)
		{
			this.m_Ratio = data[0];
			this.m_Buff = _Buff;
			this.m_UpperBoundRatio = data[1];
		}

		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			this.m_Entity = entity;
			bool flag = this.m_UpperBoundRatio > 0f && entity != null && entity.Attributes != null;
			if (flag)
			{
				this.m_StealUpperBound = entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total) * (double)this.m_UpperBoundRatio;
			}
		}

		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
		}

		public override void OnCastDamage(HurtInfo rawInput, ProjectDamageResult result)
		{
			bool flag = rawInput.SkillID == 0U;
			if (!flag)
			{
				bool flag2 = this.m_Buff.RelevantSkills != null && this.m_Buff.RelevantSkills.Count != 0;
				if (flag2)
				{
					bool flag3 = !this.m_Buff.RelevantSkills.Contains(rawInput.SkillID);
					if (flag3)
					{
						return;
					}
				}
				bool accept = result.Accept;
				if (accept)
				{
					double num = result.Value * (double)this.m_Ratio;
					bool flag4 = this.m_UpperBoundRatio > 0f;
					if (flag4)
					{
						num = Math.Min(num, this.m_StealUpperBound);
						this.m_StealUpperBound -= num;
					}
					bool flag5 = num > 0.0;
					if (flag5)
					{
						XAttrChangeEventArgs @event = XEventPool<XAttrChangeEventArgs>.GetEvent();
						@event.AttrKey = XAttributeDefine.XAttr_CurrentHP_Basic;
						@event.DeltaValue = num;
						@event.Firer = this.m_Entity;
						@event.bShowHUD = !this.m_Buff.BuffInfo.DontShowText;
						XSingleton<XEventMgr>.singleton.FireEvent(@event);
					}
				}
			}
		}

		private float m_Ratio;

		private float m_UpperBoundRatio;

		private double m_StealUpperBound = 0.0;

		private XBuff m_Buff;

		private XEntity m_Entity;
	}
}
