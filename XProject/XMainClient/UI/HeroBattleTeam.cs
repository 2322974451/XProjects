using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x0200172C RID: 5932
	internal class HeroBattleTeam
	{
		// Token: 0x0600F4EB RID: 62699 RVA: 0x00372208 File Offset: 0x00370408
		public HeroBattleTeam(Transform ts)
		{
			this.m_Ring = (ts.Find("Ring").GetComponent("XUIProgress") as IXUIProgress);
			this.m_Ring.value = 0f;
			this.m_Score = (ts.Find("Score").GetComponent("XUILabel") as IXUILabel);
			this.m_Score.SetText("0%");
			this.m_OccupantCircle = ts.Find("Circle").gameObject;
			this.m_OccupantCircle.transform.localPosition = XGameUI.Far_Far_Away;
		}

		// Token: 0x170037B5 RID: 14261
		// (set) Token: 0x0600F4EC RID: 62700 RVA: 0x003722B4 File Offset: 0x003704B4
		public uint Score
		{
			set
			{
				bool flag = this._score != value;
				if (flag)
				{
					this._score = value;
					this.m_Score.SetText(string.Format("{0}%", this._score));
				}
			}
		}

		// Token: 0x0600F4ED RID: 62701 RVA: 0x003722FC File Offset: 0x003704FC
		public void SetOccupyValue(float value)
		{
			this.m_Ring.value = value;
		}

		// Token: 0x0600F4EE RID: 62702 RVA: 0x0037230C File Offset: 0x0037050C
		public void SetOccupantState(bool state)
		{
			this.m_OccupantCircle.transform.localPosition = (state ? Vector3.zero : XGameUI.Far_Far_Away);
			if (state)
			{
				this.SetOccupyValue(0f);
			}
		}

		// Token: 0x040069C5 RID: 27077
		public GameObject m_OccupantCircle;

		// Token: 0x040069C6 RID: 27078
		public IXUIProgress m_Ring;

		// Token: 0x040069C7 RID: 27079
		public IXUILabel m_Score;

		// Token: 0x040069C8 RID: 27080
		private uint _score = 0U;
	}
}
