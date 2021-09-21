using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x02001770 RID: 6000
	internal class GuildScoreInfo
	{
		// Token: 0x1700381F RID: 14367
		// (get) Token: 0x0600F7C0 RID: 63424 RVA: 0x00387A30 File Offset: 0x00385C30
		public int Index
		{
			get
			{
				return this.m_index;
			}
		}

		// Token: 0x0600F7C1 RID: 63425 RVA: 0x00387A48 File Offset: 0x00385C48
		public void Init(Transform t, int index)
		{
			this.m_transform = t;
			this.m_index = index;
			this.m_Score = (t.FindChild("Score").GetComponent("XUILabel") as IXUILabel);
			this.m_Value = (t.FindChild("Value").GetComponent("XUILabel") as IXUILabel);
			this.m_Go = (t.FindChild("Go").GetComponent("XUIButton") as IXUIButton);
			this.m_Go.ID = (ulong)((long)this.m_index);
		}

		// Token: 0x0600F7C2 RID: 63426 RVA: 0x00387AD7 File Offset: 0x00385CD7
		public void SetInfo(uint score, uint value)
		{
			this.m_Score.SetText(score.ToString());
			this.m_Value.SetText(value.ToString());
		}

		// Token: 0x0600F7C3 RID: 63427 RVA: 0x00387B00 File Offset: 0x00385D00
		public void RegisterClickEventHandler(ButtonClickEventHandler click)
		{
			this.m_Go.RegisterClickEventHandler(click);
		}

		// Token: 0x0600F7C4 RID: 63428 RVA: 0x00387B10 File Offset: 0x00385D10
		public void Destroy()
		{
			this.m_Go.RegisterClickEventHandler(null);
		}

		// Token: 0x04006BFD RID: 27645
		private Transform m_transform;

		// Token: 0x04006BFE RID: 27646
		private IXUILabel m_Score;

		// Token: 0x04006BFF RID: 27647
		private IXUILabel m_Value;

		// Token: 0x04006C00 RID: 27648
		private IXUIButton m_Go;

		// Token: 0x04006C01 RID: 27649
		private int m_index;
	}
}
