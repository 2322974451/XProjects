using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class GuildArenaRankBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_NA = base.transform.FindChild("Bg/NA");
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.transform.FindChild("Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		public IXUIButton m_Close;

		public IXUIScrollView m_ScrollView;

		public IXUIWrapContent m_WrapContent;

		public Transform m_NA;
	}
}
