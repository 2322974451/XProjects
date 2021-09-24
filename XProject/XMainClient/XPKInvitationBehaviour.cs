using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XPKInvitationBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.transform.FindChild("Bg/List").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/List/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_WrapContent.SetVisible(false);
			this.m_IgnoreAll = (base.transform.FindChild("Bg/Submmit").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUIButton m_Close;

		public IXUIScrollView m_ScrollView;

		public IXUIWrapContent m_WrapContent;

		public IXUIButton m_IgnoreAll;

		public IXUIButton m_Help;
	}
}
