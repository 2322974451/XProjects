using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class PairsPetInviteBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_closeBtn = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ignoreBtn = (base.transform.FindChild("Bg/BtnNo").GetComponent("XUIButton") as IXUIButton);
			this.m_tempRejectBtn = (base.transform.FindChild("Bg/BtnOk").GetComponent("XUIButton") as IXUIButton);
			this.m_wrapContent = (base.transform.FindChild("Bg/List/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		public IXUIButton m_closeBtn;

		public IXUIButton m_ignoreBtn;

		public IXUIButton m_tempRejectBtn;

		public IXUIWrapContent m_wrapContent;
	}
}
