using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class RequestBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.transform.Find("Bg/List").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.Find("Bg/List/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_ClearBtn = (base.transform.Find("Bg/ClearBtn").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUIButton m_Close;

		public IXUIScrollView m_ScrollView;

		public IXUIWrapContent m_WrapContent;

		public IXUIButton m_ClearBtn;
	}
}
