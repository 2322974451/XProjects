using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x0200175C RID: 5980
	internal class RequestBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F706 RID: 63238 RVA: 0x00382844 File Offset: 0x00380A44
		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.transform.Find("Bg/List").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.Find("Bg/List/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_ClearBtn = (base.transform.Find("Bg/ClearBtn").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x04006B6A RID: 27498
		public IXUIButton m_Close;

		// Token: 0x04006B6B RID: 27499
		public IXUIScrollView m_ScrollView;

		// Token: 0x04006B6C RID: 27500
		public IXUIWrapContent m_WrapContent;

		// Token: 0x04006B6D RID: 27501
		public IXUIButton m_ClearBtn;
	}
}
