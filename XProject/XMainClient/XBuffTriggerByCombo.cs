using System;

namespace XMainClient
{
	// Token: 0x0200089F RID: 2207
	internal class XBuffTriggerByCombo : XBuffTrigger
	{
		// Token: 0x06008608 RID: 34312 RVA: 0x0010D224 File Offset: 0x0010B424
		public XBuffTriggerByCombo(XBuff buff) : base(buff)
		{
			this.m_Base = (uint)base._GetTriggerParamInt(buff.BuffInfo, 0);
			bool flag = this.m_Base == 0U;
			if (flag)
			{
				this.m_Base = 1U;
			}
		}

		// Token: 0x06008609 RID: 34313 RVA: 0x0010D264 File Offset: 0x0010B464
		public override bool CheckTriggerCondition()
		{
			return this.m_Count != 0U && this.m_Count % this.m_Base == 0U;
		}

		// Token: 0x0600860A RID: 34314 RVA: 0x0010D291 File Offset: 0x0010B491
		public override void OnComboChange(uint comboCount)
		{
			this.m_Count = comboCount;
			base.Trigger();
		}

		// Token: 0x040029C1 RID: 10689
		private uint m_Base;

		// Token: 0x040029C2 RID: 10690
		private uint m_Count;
	}
}
