using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008AC RID: 2220
	internal class XBuffDamageDistanceScale : BuffEffect
	{
		// Token: 0x0600864A RID: 34378 RVA: 0x0010E49C File Offset: 0x0010C69C
		public static bool TryCreate(BuffTable.RowData rowData, XBuff buff)
		{
			bool flag = rowData.ChangeCastDamageByDistance.Count == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				buff.AddEffect(new XBuffDamageDistanceScale(buff));
				result = true;
			}
			return result;
		}

		// Token: 0x0600864B RID: 34379 RVA: 0x0010E4D4 File Offset: 0x0010C6D4
		public XBuffDamageDistanceScale(XBuff buff)
		{
			this._buff = buff;
			BuffTable.RowData buffInfo = buff.BuffInfo;
			this.m_Data.SetRange(0.0, 0.0, 10000.0, 0.0);
			this.m_Data.Init(ref buffInfo.ChangeCastDamageByDistance);
		}

		// Token: 0x17002A30 RID: 10800
		// (get) Token: 0x0600864C RID: 34380 RVA: 0x0010E54C File Offset: 0x0010C74C
		public override XBuffEffectPrioriy Priority
		{
			get
			{
				return XBuffEffectPrioriy.BEP_TargetLifeAddAttack;
			}
		}

		// Token: 0x0600864D RID: 34381 RVA: 0x0010E55F File Offset: 0x0010C75F
		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			this._entity = entity;
		}

		// Token: 0x0600864E RID: 34382 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
		}

		// Token: 0x0600864F RID: 34383 RVA: 0x0010E56C File Offset: 0x0010C76C
		public override void OnCastDamage(HurtInfo rawInput, ProjectDamageResult result)
		{
			bool flag = rawInput.SkillID == 0U;
			if (!flag)
			{
				bool flag2 = this._entity == null || rawInput.Target == null;
				if (!flag2)
				{
					double x = (double)Vector3.Distance(this._entity.MoveObj.Position, rawInput.Target.MoveObj.Position);
					result.Value *= 1.0 + this.m_Data.GetData(x);
				}
			}
		}

		// Token: 0x040029DE RID: 10718
		private XBuff _buff = null;

		// Token: 0x040029DF RID: 10719
		private XEntity _entity;

		// Token: 0x040029E0 RID: 10720
		private XPieceWiseDataMgr m_Data = new XPieceWiseDataMgr();
	}
}
