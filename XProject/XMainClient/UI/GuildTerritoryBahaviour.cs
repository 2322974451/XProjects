using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class GuildTerritoryBahaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this._close_btn = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_lblGuildName = (base.transform.Find("Winner/Guild").GetComponent("XUILabel") as IXUILabel);
			this.m_lblTime = (base.transform.Find("Time/Guild").GetComponent("XUILabel") as IXUILabel);
			this.m_sprIcon = (base.transform.Find("Sprite").GetComponent("XUISprite") as IXUISprite);
			this.m_wrap = (base.transform.Find("ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_scroll = (base.transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
		}

		public IXUIButton _close_btn;

		public IXUILabel m_lblGuildName;

		public IXUILabel m_lblTime;

		public IXUISprite m_sprIcon;

		public IXUIScrollView m_scroll;

		public IXUIWrapContent m_wrap;
	}
}
