using System;

namespace XMainClient
{
	// Token: 0x02000898 RID: 2200
	internal class XBuffTriggerByLife : XBuffTrigger
	{
		// Token: 0x060085E7 RID: 34279 RVA: 0x0010C920 File Offset: 0x0010AB20
		public XBuffTriggerByLife(XBuff buff) : base(buff)
		{
			this._hpTriggerPercent = base._GetTriggerParam(buff.BuffInfo, 0);
		}

		// Token: 0x060085E8 RID: 34280 RVA: 0x0010C94C File Offset: 0x0010AB4C
		public override bool CheckTriggerCondition()
		{
			bool isDummy = base.Entity.IsDummy;
			return !isDummy && base.Entity.Attributes.HPPercent <= (double)this._hpTriggerPercent;
		}

		// Token: 0x060085E9 RID: 34281 RVA: 0x0010C98D File Offset: 0x0010AB8D
		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			base.OnAdd(entity, pEffectHelper);
			base.Trigger();
		}

		// Token: 0x060085EA RID: 34282 RVA: 0x0010C9A0 File Offset: 0x0010ABA0
		public override void OnAttributeChanged(XAttrChangeEventArgs e)
		{
			bool flag = e.AttrKey == XAttributeDefine.XAttr_CurrentHP_Basic;
			if (flag)
			{
				base.Trigger();
			}
		}

		// Token: 0x040029AE RID: 10670
		private float _hpTriggerPercent = 0f;
	}
}
