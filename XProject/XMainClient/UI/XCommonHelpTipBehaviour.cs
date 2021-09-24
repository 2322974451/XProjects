using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XCommonHelpTipBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Title = (base.transform.Find("Title").GetComponent("XUILabel") as IXUILabel);
			this.m_ScrollView = (base.transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_Content = (base.transform.Find("ScrollView/Content").GetComponent("XUILabel") as IXUILabel);
			this.m_Close = (base.transform.Find("Btn").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUILabel m_Title;

		public IXUIScrollView m_ScrollView;

		public IXUILabel m_Content;

		public IXUIButton m_Close;
	}
}
