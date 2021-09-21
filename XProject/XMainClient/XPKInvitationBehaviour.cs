using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C83 RID: 3203
	internal class XPKInvitationBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B505 RID: 46341 RVA: 0x00239494 File Offset: 0x00237694
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.transform.FindChild("Bg/List").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/List/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_WrapContent.SetVisible(false);
			this.m_IgnoreAll = (base.transform.FindChild("Bg/Submmit").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x04004691 RID: 18065
		public IXUIButton m_Close;

		// Token: 0x04004692 RID: 18066
		public IXUIScrollView m_ScrollView;

		// Token: 0x04004693 RID: 18067
		public IXUIWrapContent m_WrapContent;

		// Token: 0x04004694 RID: 18068
		public IXUIButton m_IgnoreAll;

		// Token: 0x04004695 RID: 18069
		public IXUIButton m_Help;
	}
}
