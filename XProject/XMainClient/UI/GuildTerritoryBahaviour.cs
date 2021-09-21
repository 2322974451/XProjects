using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001768 RID: 5992
	internal class GuildTerritoryBahaviour : DlgBehaviourBase
	{
		// Token: 0x0600F753 RID: 63315 RVA: 0x00384418 File Offset: 0x00382618
		private void Awake()
		{
			this._close_btn = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_lblGuildName = (base.transform.Find("Winner/Guild").GetComponent("XUILabel") as IXUILabel);
			this.m_lblTime = (base.transform.Find("Time/Guild").GetComponent("XUILabel") as IXUILabel);
			this.m_sprIcon = (base.transform.Find("Sprite").GetComponent("XUISprite") as IXUISprite);
			this.m_wrap = (base.transform.Find("ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_scroll = (base.transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
		}

		// Token: 0x04006BA6 RID: 27558
		public IXUIButton _close_btn;

		// Token: 0x04006BA7 RID: 27559
		public IXUILabel m_lblGuildName;

		// Token: 0x04006BA8 RID: 27560
		public IXUILabel m_lblTime;

		// Token: 0x04006BA9 RID: 27561
		public IXUISprite m_sprIcon;

		// Token: 0x04006BAA RID: 27562
		public IXUIScrollView m_scroll;

		// Token: 0x04006BAB RID: 27563
		public IXUIWrapContent m_wrap;
	}
}
