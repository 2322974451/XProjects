using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C01 RID: 3073
	internal class GiftboxBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600AEC0 RID: 44736 RVA: 0x0020EA48 File Offset: 0x0020CC48
		private void Awake()
		{
			this.m_checkbox1 = (base.transform.Find("item1/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_checkbox2 = (base.transform.Find("item2/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_tip0 = base.transform.Find("Bg/Tip2").gameObject;
			this.m_tip1 = base.transform.Find("Bg/Tip1").gameObject;
			this.m_btnClose = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_wrap = (base.transform.Find("scrollview/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_scroll = (base.transform.Find("scrollview").GetComponent("XUIScrollView") as IXUIScrollView);
		}

		// Token: 0x0400426A RID: 17002
		public IXUICheckBox m_checkbox1;

		// Token: 0x0400426B RID: 17003
		public IXUICheckBox m_checkbox2;

		// Token: 0x0400426C RID: 17004
		public IXUIButton m_btnClose;

		// Token: 0x0400426D RID: 17005
		public IXUIWrapContent m_wrap;

		// Token: 0x0400426E RID: 17006
		public IXUIScrollView m_scroll;

		// Token: 0x0400426F RID: 17007
		public GameObject m_tip0;

		// Token: 0x04004270 RID: 17008
		public GameObject m_tip1;
	}
}
