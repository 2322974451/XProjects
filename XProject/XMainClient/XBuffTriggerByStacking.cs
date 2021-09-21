using System;

namespace XMainClient
{
	// Token: 0x020008AA RID: 2218
	internal class XBuffTriggerByStacking : XBuffTrigger
	{
		// Token: 0x06008642 RID: 34370 RVA: 0x0010E388 File Offset: 0x0010C588
		public XBuffTriggerByStacking(XBuff buff) : base(buff)
		{
			this.m_Base = (uint)base._GetTriggerParamInt(buff.BuffInfo, 0);
			bool flag = this.m_Base == 0U;
			if (flag)
			{
				this.m_Base = 1U;
			}
		}

		// Token: 0x06008643 RID: 34371 RVA: 0x0010E3C8 File Offset: 0x0010C5C8
		public override bool CheckTriggerCondition()
		{
			return this._Buff.StackCount % this.m_Base == 0U;
		}

		// Token: 0x06008644 RID: 34372 RVA: 0x0010E3EF File Offset: 0x0010C5EF
		public override void OnAppend(XEntity entity)
		{
			base.OnAppend(entity);
			base.Trigger();
		}

		// Token: 0x040029DD RID: 10717
		private uint m_Base;
	}
}
