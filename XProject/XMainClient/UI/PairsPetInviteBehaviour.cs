using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020017F6 RID: 6134
	internal class PairsPetInviteBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600FE62 RID: 65122 RVA: 0x003BD0B0 File Offset: 0x003BB2B0
		private void Awake()
		{
			this.m_closeBtn = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ignoreBtn = (base.transform.FindChild("Bg/BtnNo").GetComponent("XUIButton") as IXUIButton);
			this.m_tempRejectBtn = (base.transform.FindChild("Bg/BtnOk").GetComponent("XUIButton") as IXUIButton);
			this.m_wrapContent = (base.transform.FindChild("Bg/List/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		// Token: 0x04007061 RID: 28769
		public IXUIButton m_closeBtn;

		// Token: 0x04007062 RID: 28770
		public IXUIButton m_ignoreBtn;

		// Token: 0x04007063 RID: 28771
		public IXUIButton m_tempRejectBtn;

		// Token: 0x04007064 RID: 28772
		public IXUIWrapContent m_wrapContent;
	}
}
