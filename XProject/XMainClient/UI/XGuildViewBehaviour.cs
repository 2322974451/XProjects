using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XGuildViewBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnApply = (base.transform.FindChild("Bg/BtnApply").GetComponent("XUIButton") as IXUIButton);
			this.m_Annoucement = (base.transform.FindChild("Bg/Bg3/Announcement").GetComponent("XUILabel") as IXUILabel);
			this.m_Annoucement.SetText("");
			this.m_BasicInfoDisplay.Init(base.transform.FindChild("Bg/BasicInfo/Content"), true);
			this.m_ScrollView = (base.transform.FindChild("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		public IXUIButton m_Close = null;

		public IXUIButton m_BtnApply;

		public IXUILabel m_Annoucement;

		public IXUIWrapContent m_WrapContent;

		public IXUIScrollView m_ScrollView;

		public XGuildBasicInfoDisplay m_BasicInfoDisplay = new XGuildBasicInfoDisplay();
	}
}
