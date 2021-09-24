using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XGuildMembersBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.transform.FindChild("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			Transform transform = base.transform.FindChild("Bg/Titles");
			DlgHandlerBase.EnsureCreate<XTitleBar>(ref this.m_TitleBar, transform.gameObject, null, true);
		}

		public IXUIButton m_Close = null;

		public IXUIWrapContent m_WrapContent;

		public IXUIScrollView m_ScrollView;

		public XTitleBar m_TitleBar;
	}
}
