using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000895 RID: 2197
	internal class XTriggerCondition
	{
		// Token: 0x060085CD RID: 34253 RVA: 0x0010C0A4 File Offset: 0x0010A2A4
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

		// Token: 0x060085CE RID: 34254 RVA: 0x0010C10C File Offset: 0x0010A30C
		public bool CanTrigger()
		{
			return this._IsTriggerBuffCD() && this._HasTriggerCount();
		}

		// Token: 0x060085CF RID: 34255 RVA: 0x0010C130 File Offset: 0x0010A330
		public void OnTrigger()
		{
			this.m_LastTriggerTime = Time.time;
			bool flag = this.m_TriggerCount != uint.MaxValue && this.m_TriggerCount > 0U;
			if (flag)
			{
				this.m_TriggerCount -= 1U;
			}
		}

		// Token: 0x060085D0 RID: 34256 RVA: 0x0010C170 File Offset: 0x0010A370
		public void OnRandFail()
		{
			bool bCDWhenRandFail = this.m_bCDWhenRandFail;
			if (bCDWhenRandFail)
			{
				this.m_LastTriggerTime = Time.time;
			}
		}

		// Token: 0x060085D1 RID: 34257 RVA: 0x0010C194 File Offset: 0x0010A394
		private bool _IsTriggerBuffCD()
		{
			return Time.time - this.m_LastTriggerTime > this.m_TriggerCD;
		}

		// Token: 0x060085D2 RID: 34258 RVA: 0x0010C1BC File Offset: 0x0010A3BC
		private bool _HasTriggerCount()
		{
			return this.m_TriggerCount == uint.MaxValue || this.m_TriggerCount > 0U;
		}

		// Token: 0x0400299B RID: 10651
		private float m_LastTriggerTime;

		// Token: 0x0400299C RID: 10652
		private float m_TriggerCD;

		// Token: 0x0400299D RID: 10653
		private uint m_TriggerCount;

		// Token: 0x0400299E RID: 10654
		private bool m_bCDWhenRandFail;
	}
}
