using System;

namespace XMainClient
{

	internal class XBuffTriggerByCombo : XBuffTrigger
	{

		public XBuffTriggerByCombo(XBuff buff) : base(buff)
		{
			this.m_Base = (uint)base._GetTriggerParamInt(buff.BuffInfo, 0);
			bool flag = this.m_Base == 0U;
			if (flag)
			{
				this.m_Base = 1U;
			}
		}

		public override bool CheckTriggerCondition()
		{
			return this.m_Count != 0U && this.m_Count % this.m_Base == 0U;
		}

		public override void OnComboChange(uint comboCount)
		{
			this.m_Count = comboCount;
			base.Trigger();
		}

		private uint m_Base;

		private uint m_Count;
	}
}
