using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008A6 RID: 2214
	internal class XBuffTargetLifeAddAttack : BuffEffect
	{
		// Token: 0x0600862D RID: 34349 RVA: 0x0010DEF8 File Offset: 0x0010C0F8
		public static bool TryCreate(BuffTable.RowData rowData, XBuff buff)
		{
			bool flag = rowData.TargetLifeAddAttack.Count == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				buff.AddEffect(new XBuffTargetLifeAddAttack(ref rowData.TargetLifeAddAttack));
				result = true;
			}
			return result;
		}

		// Token: 0x0600862E RID: 34350 RVA: 0x0010DF34 File Offset: 0x0010C134
		public XBuffTargetLifeAddAttack(ref SeqListRef<float> reducePecents)
		{
			this.m_Data.SetRange(0.0, 0.0, 1.0, 0.0);
			this.m_Data.Init(ref reducePecents);
		}

		// Token: 0x17002A2E RID: 10798
		// (get) Token: 0x0600862F RID: 34351 RVA: 0x0010DF94 File Offset: 0x0010C194
		public override XBuffEffectPrioriy Priority
		{
			get
			{
				return XBuffEffectPrioriy.BEP_TargetLifeAddAttack;
			}
		}

		// Token: 0x06008630 RID: 34352 RVA: 0x0010DFA7 File Offset: 0x0010C1A7
		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			this._entity = entity;
		}

		// Token: 0x06008631 RID: 34353 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
		}

		// Token: 0x06008632 RID: 34354 RVA: 0x0010DFB4 File Offset: 0x0010C1B4
		public override void OnCastDamage(HurtInfo rawInput, ProjectDamageResult result)
		{
			double hppercent = rawInput.Target.Attributes.HPPercent;
			result.Value *= 1.0 + this.m_Data.GetData(hppercent);
		}

		// Token: 0x040029D4 RID: 10708
		private XPieceWiseDataMgr m_Data = new XPieceWiseDataMgr();

		// Token: 0x040029D5 RID: 10709
		private XEntity _entity;
	}
}
