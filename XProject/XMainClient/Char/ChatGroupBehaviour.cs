using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class ChatGroupBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_wrap = (base.transform.FindChild("Bg/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_sprClose = (base.transform.Find("Bg/Close").GetComponent("XUISprite") as IXUISprite);
			this.m_add = (base.transform.FindChild("Bg/tabs/tab1/template/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_rm = (base.transform.FindChild("Bg/tabs/tab2/template/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
		}

		public IXUISprite m_sprClose;

		public IXUIWrapContent m_wrap;

		public IXUICheckBox m_add;

		public IXUICheckBox m_rm;
	}
}
