using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000891 RID: 2193
	internal class XBuffLifeAddAttack : BuffEffect
	{
		// Token: 0x060085BB RID: 34235 RVA: 0x0010BB3C File Offset: 0x00109D3C
		public static bool TryCreate(BuffTable.RowData rowData, XBuff buff)
		{
			bool flag = rowData.SelfLifeAddAttack.Count == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				buff.AddEffect(new XBuffLifeAddAttack(buff));
				result = true;
			}
			return result;
		}

		// Token: 0x060085BC RID: 34236 RVA: 0x0010BB74 File Offset: 0x00109D74
		public XBuffLifeAddAttack(XBuff buff)
		{
			this._buff = buff;
			BuffTable.RowData buffInfo = buff.BuffInfo;
			this.m_Data.SetRange(0.0, 0.0, 1.0, 0.0);
			this.m_Data.Init(ref buffInfo.SelfLifeAddAttack);
		}

		// Token: 0x17002A28 RID: 10792
		// (get) Token: 0x060085BD RID: 34237 RVA: 0x0010BBEC File Offset: 0x00109DEC
		public override XBuffEffectPrioriy Priority
		{
			get
			{
				return XBuffEffectPrioriy.BEP_TargetLifeAddAttack;
			}
		}

		// Token: 0x060085BE RID: 34238 RVA: 0x0010BBFF File Offset: 0x00109DFF
		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			this._entity = entity;
		}

		// Token: 0x060085BF RID: 34239 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
		}

		// Token: 0x060085C0 RID: 34240 RVA: 0x0010BC0C File Offset: 0x00109E0C
		public override void OnCastDamage(HurtInfo rawInput, ProjectDamageResult result)
		{
			double hppercent = this._entity.Attributes.HPPercent;
			result.Value *= 1.0 + this.m_Data.GetData(hppercent);
		}

		// Token: 0x0400298E RID: 10638
		private XBuff _buff = null;

		// Token: 0x0400298F RID: 10639
		private XEntity _entity;

		// Token: 0x04002990 RID: 10640
		private XPieceWiseDataMgr m_Data = new XPieceWiseDataMgr();
	}
}
