using System;

namespace XMainClient
{

	internal class XBuffTriggerByStacking : XBuffTrigger
	{

		public XBuffTriggerByStacking(XBuff buff) : base(buff)
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
			return this._Buff.StackCount % this.m_Base == 0U;
		}

		public override void OnAppend(XEntity entity)
		{
			base.OnAppend(entity);
			base.Trigger();
		}

		private uint m_Base;
	}
}
