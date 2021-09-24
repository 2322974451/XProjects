using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class GuildFiexdRedPackageBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.transform.FindChild("Bg/RightView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/RightView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_Empty = base.transform.FindChild("Bg/Empty");
			this.m_HelpBtn = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUIScrollView m_ScrollView;

		public IXUIButton m_Close;

		public IXUIWrapContent m_WrapContent;

		public IXUIButton m_HelpBtn;

		public Transform m_Empty;
	}
}
