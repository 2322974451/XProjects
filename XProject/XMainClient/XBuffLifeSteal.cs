using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008A0 RID: 2208
	internal class XBuffLifeSteal : BuffEffect
	{
		// Token: 0x0600860B RID: 34315 RVA: 0x0010D2A4 File Offset: 0x0010B4A4
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

		// Token: 0x0600860C RID: 34316 RVA: 0x0010D2E5 File Offset: 0x0010B4E5
		public XBuffLifeSteal(ref SeqRef<float> data, XBuff _Buff)
		{
			this.m_Ratio = data[0];
			this.m_Buff = _Buff;
			this.m_UpperBoundRatio = data[1];
		}

		// Token: 0x0600860D RID: 34317 RVA: 0x0010D320 File Offset: 0x0010B520
		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			this.m_Entity = entity;
			bool flag = this.m_UpperBoundRatio > 0f && entity != null && entity.Attributes != null;
			if (flag)
			{
				this.m_StealUpperBound = entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total) * (double)this.m_UpperBoundRatio;
			}
		}

		// Token: 0x0600860E RID: 34318 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
		}

		// Token: 0x0600860F RID: 34319 RVA: 0x0010D378 File Offset: 0x0010B578
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

		// Token: 0x040029C3 RID: 10691
		private float m_Ratio;

		// Token: 0x040029C4 RID: 10692
		private float m_UpperBoundRatio;

		// Token: 0x040029C5 RID: 10693
		private double m_StealUpperBound = 0.0;

		// Token: 0x040029C6 RID: 10694
		private XBuff m_Buff;

		// Token: 0x040029C7 RID: 10695
		private XEntity m_Entity;
	}
}
