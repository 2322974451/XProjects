using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class WeddingEnterApplyBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_ToggleEnter = (base.transform.FindChild("Bg/ToggleEnter").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_ToggleApply = (base.transform.FindChild("Bg/ToggleApply").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_ToggleEnter.ID = 0UL;
			this.m_ToggleApply.ID = 1UL;
			this.m_ScrollView = (base.transform.FindChild("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_EmptyList = (base.transform.FindChild("Bg/Empty").GetComponent("XUILabel") as IXUILabel);
			this.m_EmptyList2 = (base.transform.FindChild("Bg/Empty2").GetComponent("XUILabel") as IXUILabel);
			this.m_GoApplyTab = (base.transform.FindChild("Bg/GoApply").GetComponent("XUIButton") as IXUIButton);
			this.m_Title = (base.transform.FindChild("Bg/Title").GetComponent("XUILabel") as IXUILabel);
			this.m_ClosedSpr = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUICheckBox m_ToggleEnter;

		public IXUICheckBox m_ToggleApply;

		public IXUIScrollView m_ScrollView;

		public IXUIWrapContent m_WrapContent;

		public IXUILabel m_EmptyList;

		public IXUILabel m_EmptyList2;

		public IXUIButton m_GoApplyTab;

		public IXUIButton m_ClosedSpr;

		public IXUILabel m_Title;
	}
}
