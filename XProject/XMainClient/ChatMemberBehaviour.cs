using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class ChatMemberBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_scroll = (base.transform.FindChild("Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_wrap = (base.transform.FindChild("Bg/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_sprClose = (base.transform.Find("Bg/Close").GetComponent("XUISprite") as IXUISprite);
		}

		public IXUISprite m_sprClose;

		public IXUIWrapContent m_wrap;

		public IXUIScrollView m_scroll;
	}
}
