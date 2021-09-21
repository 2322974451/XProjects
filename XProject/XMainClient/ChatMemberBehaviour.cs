using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000A2D RID: 2605
	internal class ChatMemberBehaviour : DlgBehaviourBase
	{
		// Token: 0x06009EF8 RID: 40696 RVA: 0x001A4608 File Offset: 0x001A2808
		private void Awake()
		{
			this.m_scroll = (base.transform.FindChild("Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_wrap = (base.transform.FindChild("Bg/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_sprClose = (base.transform.Find("Bg/Close").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x040038AA RID: 14506
		public IXUISprite m_sprClose;

		// Token: 0x040038AB RID: 14507
		public IXUIWrapContent m_wrap;

		// Token: 0x040038AC RID: 14508
		public IXUIScrollView m_scroll;
	}
}
