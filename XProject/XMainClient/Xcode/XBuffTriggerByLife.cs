using System;

namespace XMainClient
{

	internal class XBuffTriggerByLife : XBuffTrigger
	{

		public XBuffTriggerByLife(XBuff buff) : base(buff)
		{
			this._hpTriggerPercent = base._GetTriggerParam(buff.BuffInfo, 0);
		}

		public override bool CheckTriggerCondition()
		{
			bool isDummy = base.Entity.IsDummy;
			return !isDummy && base.Entity.Attributes.HPPercent <= (double)this._hpTriggerPercent;
		}

		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			base.OnAdd(entity, pEffectHelper);
			base.Trigger();
		}

		public override void OnAttributeChanged(XAttrChangeEventArgs e)
		{
			bool flag = e.AttrKey == XAttributeDefine.XAttr_CurrentHP_Basic;
			if (flag)
			{
				base.Trigger();
			}
		}

		private float _hpTriggerPercent = 0f;
	}
}
