using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{

	internal class GuildScoreInfo
	{

		public int Index
		{
			get
			{
				return this.m_index;
			}
		}

		public void Init(Transform t, int index)
		{
			this.m_transform = t;
			this.m_index = index;
			this.m_Score = (t.FindChild("Score").GetComponent("XUILabel") as IXUILabel);
			this.m_Value = (t.FindChild("Value").GetComponent("XUILabel") as IXUILabel);
			this.m_Go = (t.FindChild("Go").GetComponent("XUIButton") as IXUIButton);
			this.m_Go.ID = (ulong)((long)this.m_index);
		}

		public void SetInfo(uint score, uint value)
		{
			this.m_Score.SetText(score.ToString());
			this.m_Value.SetText(value.ToString());
		}

		public void RegisterClickEventHandler(ButtonClickEventHandler click)
		{
			this.m_Go.RegisterClickEventHandler(click);
		}

		public void Destroy()
		{
			this.m_Go.RegisterClickEventHandler(null);
		}

		private Transform m_transform;

		private IXUILabel m_Score;

		private IXUILabel m_Value;

		private IXUIButton m_Go;

		private int m_index;
	}
}
