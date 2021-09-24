using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTriggerCondition
	{

		public XTriggerCondition(BuffTable.RowData info)
		{
			this.m_LastTriggerTime = 0f;
			this.m_TriggerCD = Math.Abs(info.BuffTriggerCD);
			this.m_TriggerCount = (uint)info.BuffTriggerCount;
			this.m_bCDWhenRandFail = (info.BuffTriggerCD < 0f);
			bool flag = this.m_TriggerCount == 0U;
			if (flag)
			{
				this.m_TriggerCount = uint.MaxValue;
			}
		}

		public bool CanTrigger()
		{
			return this._IsTriggerBuffCD() && this._HasTriggerCount();
		}

		public void OnTrigger()
		{
			this.m_LastTriggerTime = Time.time;
			bool flag = this.m_TriggerCount != uint.MaxValue && this.m_TriggerCount > 0U;
			if (flag)
			{
				this.m_TriggerCount -= 1U;
			}
		}

		public void OnRandFail()
		{
			bool bCDWhenRandFail = this.m_bCDWhenRandFail;
			if (bCDWhenRandFail)
			{
				this.m_LastTriggerTime = Time.time;
			}
		}

		private bool _IsTriggerBuffCD()
		{
			return Time.time - this.m_LastTriggerTime > this.m_TriggerCD;
		}

		private bool _HasTriggerCount()
		{
			return this.m_TriggerCount == uint.MaxValue || this.m_TriggerCount > 0U;
		}

		private float m_LastTriggerTime;

		private float m_TriggerCD;

		private uint m_TriggerCount;

		private bool m_bCDWhenRandFail;
	}
}
