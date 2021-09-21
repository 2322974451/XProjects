using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000BB0 RID: 2992
	internal class RollDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600AB7D RID: 43901 RVA: 0x001F4D18 File Offset: 0x001F2F18
		private void Awake()
		{
			this.m_ItemTpl = base.transform.Find("Bg/ItemTpl/Item").gameObject;
			this.m_TimeBar = (base.transform.Find("Bg/Bar").GetComponent("XUISlider") as IXUISlider);
			this.m_Level = (base.transform.Find("Bg/ItemTpl/Level").GetComponent("XUILabel") as IXUILabel);
			this.m_Prof = (base.transform.Find("Bg/ItemTpl/Prof").GetComponent("XUILabel") as IXUILabel);
			this.m_YesButton = (base.transform.Find("Bg/Yes").GetComponent("XUIButton") as IXUIButton);
			this.m_CancelButton = (base.transform.Find("Bg/Cancel").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x0400403B RID: 16443
		public GameObject m_ItemTpl;

		// Token: 0x0400403C RID: 16444
		public IXUISlider m_TimeBar;

		// Token: 0x0400403D RID: 16445
		public IXUILabel m_Level;

		// Token: 0x0400403E RID: 16446
		public IXUILabel m_Prof;

		// Token: 0x0400403F RID: 16447
		public IXUIButton m_YesButton;

		// Token: 0x04004040 RID: 16448
		public IXUIButton m_CancelButton;
	}
}
