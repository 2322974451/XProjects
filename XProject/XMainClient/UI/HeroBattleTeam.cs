using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{

	internal class HeroBattleTeam
	{

		public HeroBattleTeam(Transform ts)
		{
			this.m_Ring = (ts.Find("Ring").GetComponent("XUIProgress") as IXUIProgress);
			this.m_Ring.value = 0f;
			this.m_Score = (ts.Find("Score").GetComponent("XUILabel") as IXUILabel);
			this.m_Score.SetText("0%");
			this.m_OccupantCircle = ts.Find("Circle").gameObject;
			this.m_OccupantCircle.transform.localPosition = XGameUI.Far_Far_Away;
		}

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

		public void SetOccupyValue(float value)
		{
			this.m_Ring.value = value;
		}

		public void SetOccupantState(bool state)
		{
			this.m_OccupantCircle.transform.localPosition = (state ? Vector3.zero : XGameUI.Far_Far_Away);
			if (state)
			{
				this.SetOccupyValue(0f);
			}
		}

		public GameObject m_OccupantCircle;

		public IXUIProgress m_Ring;

		public IXUILabel m_Score;

		private uint _score = 0U;
	}
}
