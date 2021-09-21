using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000894 RID: 2196
	internal class XBuffReduceDamage : BuffEffect
	{
		// Token: 0x060085C6 RID: 34246 RVA: 0x0010BEFC File Offset: 0x0010A0FC
		public static bool TryCreate(BuffTable.RowData rowData, XBuff buff)
		{
			bool flag = rowData.DamageReduce.Count == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				buff.AddEffect(new XBuffReduceDamage(ref rowData.DamageReduce, rowData.BuffID));
				result = true;
			}
			return result;
		}

		// Token: 0x060085C7 RID: 34247 RVA: 0x0010BF40 File Offset: 0x0010A140
		public XBuffReduceDamage(ref SeqListRef<float> reducePecents, int buffID)
		{
			this._buffID = buffID;
			this.m_Data.SetRange(0.0, 1.0, 1.0, 0.0);
			this.m_Data.Init(ref reducePecents);
		}

		// Token: 0x17002A29 RID: 10793
		// (get) Token: 0x060085C8 RID: 34248 RVA: 0x0010BFA4 File Offset: 0x0010A1A4
		public override XBuffEffectPrioriy Priority
		{
			get
			{
				return XBuffEffectPrioriy.BEP_ReduceDamage;
			}
		}

		// Token: 0x060085C9 RID: 34249 RVA: 0x0010BFB7 File Offset: 0x0010A1B7
		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			this._entity = entity;
		}

		// Token: 0x060085CA RID: 34250 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
		}

		// Token: 0x060085CB RID: 34251 RVA: 0x0010BFC4 File Offset: 0x0010A1C4
		public override void OnAttributeChanged(XAttrChangeEventArgs e)
		{
			bool flag = e.AttrKey == XAttributeDefine.XAttr_CurrentHP_Basic;
			if (flag)
			{
				bool flag2 = this.m_Data.GetData(this._entity.Attributes.HPPercent) < 1E-06;
				if (flag2)
				{
					XBuffRemoveEventArgs @event = XEventPool<XBuffRemoveEventArgs>.GetEvent();
					@event.xBuffID = this._buffID;
					@event.Firer = this._entity;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
					XSingleton<XDebug>.singleton.AddGreenLog("delete reduce damage buff", null, null, null, null, null);
				}
			}
		}

		// Token: 0x060085CC RID: 34252 RVA: 0x0010C050 File Offset: 0x0010A250
		public override void OnBuffEffect(HurtInfo rawInput, ProjectDamageResult result)
		{
			int num = (int)result.Value;
			double hppercent = rawInput.Target.Attributes.HPPercent;
			result.Value *= 1.0 - this.m_Data.GetData(hppercent);
			int num2 = (int)result.Value;
		}

		// Token: 0x04002998 RID: 10648
		private int _buffID;

		// Token: 0x04002999 RID: 10649
		private XPieceWiseDataMgr m_Data = new XPieceWiseDataMgr();

		// Token: 0x0400299A RID: 10650
		private XEntity _entity;
	}
}
