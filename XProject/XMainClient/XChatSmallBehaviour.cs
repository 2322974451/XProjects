using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E17 RID: 3607
	internal class XChatSmallBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C22A RID: 49706 RVA: 0x0029B424 File Offset: 0x00299624
		private void Awake()
		{
			this.m_BgSprite = (base.transform.FindChild("Alphaboard/Bg/Back").GetComponent("XUISprite") as IXUISprite);
			this.m_sprMailRed = (base.transform.FindChild("Alphaboard/Bg/mailredpoint").GetComponent("XUISprite") as IXUISprite);
			this.m_ScrollView = (base.transform.FindChild("Alphaboard/Bg/ChatContent").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_RedPoint = (base.transform.FindChild("Alphaboard/Bg/redpoint").GetComponent("XUISprite") as IXUISprite);
			this.m_BgSpriteMini = (base.transform.FindChild("Alphaboard/Bg2").GetComponent("XUISprite") as IXUISprite);
			this.m_BgSpriteMain = (base.transform.FindChild("Alphaboard/Bg").GetComponent("XUISprite") as IXUISprite);
			this.m_OpenWindow = (base.transform.FindChild("Alphaboard/Bg/go").GetComponent("XUISprite") as IXUISprite);
			this.m_OpenWindowMini = (base.transform.FindChild("Alphaboard/Bg2/go").GetComponent("XUISprite") as IXUISprite);
			this.m_MiniText = (base.transform.FindChild("Alphaboard/Bg2/ChatContent/template/content").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_MiniTemplate = (base.transform.FindChild("Alphaboard/Bg2/ChatContent/template").GetComponent("XUISprite") as IXUISprite);
			this.m_AudioName = (base.transform.FindChild("Alphaboard/Bg2/ChatContent/templateaudio/name").GetComponent("XUILabel") as IXUILabel);
			this.m_AudioTime = (base.transform.FindChild("Alphaboard/Bg2/ChatContent/templateaudio/time").GetComponent("XUILabel") as IXUILabel);
			this.m_AudioContent = (base.transform.FindChild("Alphaboard/Bg2/ChatContent/templateaudio/content").GetComponent("XUILabel") as IXUILabel);
			this.m_MiniAudioTemplate = (base.transform.FindChild("Alphaboard/Bg2/ChatContent/templateaudio").GetComponent("XUISprite") as IXUISprite);
			this.m_contentPanel = (base.transform.FindChild("Alphaboard/Bg/ChatContent").GetComponent("XUIPanel") as IXUIPanel);
			this.m_ChatPool.SetupPool(base.transform.FindChild("Alphaboard/Bg/ChatContent").gameObject, base.transform.FindChild("Alphaboard/Bg/ChatContent/template").gameObject, 4U, false);
			this.m_TweenTool = (base.transform.Find("Alphaboard/Bg").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_BgTweenTool = (base.transform.Find("Alphaboard").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_MainPanel = (base.transform.Find("Alphaboard").GetComponent("XUISprite") as IXUISprite);
			this.m_panel = (base.transform.GetComponent("XUIPanel") as IXUIPanel);
			this.m_Exp = (base.transform.Find("Alphaboard/Bg/Exp").GetComponent("XUIProgress") as IXUIProgress);
			this.m_ExpValue = (this.m_Exp.gameObject.transform.Find("content").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x040052E2 RID: 21218
		public static uint m_MaxShowMsg = 10U;

		// Token: 0x040052E3 RID: 21219
		public IXUISprite m_BgSprite;

		// Token: 0x040052E4 RID: 21220
		public IXUISprite m_RedPoint;

		// Token: 0x040052E5 RID: 21221
		public IXUISprite m_BgSpriteMini;

		// Token: 0x040052E6 RID: 21222
		public IXUISprite m_BgSpriteMain;

		// Token: 0x040052E7 RID: 21223
		public IXUISprite m_OpenWindow;

		// Token: 0x040052E8 RID: 21224
		public IXUISprite m_OpenWindowMini;

		// Token: 0x040052E9 RID: 21225
		public IXUILabelSymbol m_MiniText;

		// Token: 0x040052EA RID: 21226
		public IXUISprite m_MiniTemplate;

		// Token: 0x040052EB RID: 21227
		public IXUILabel m_AudioName;

		// Token: 0x040052EC RID: 21228
		public IXUILabel m_AudioTime;

		// Token: 0x040052ED RID: 21229
		public IXUILabel m_AudioContent;

		// Token: 0x040052EE RID: 21230
		public IXUISprite m_MiniAudioTemplate;

		// Token: 0x040052EF RID: 21231
		public XUIPool m_ChatPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040052F0 RID: 21232
		public IXUIScrollView m_ScrollView;

		// Token: 0x040052F1 RID: 21233
		public List<XSmallChatInfo> ChatUIInfoList = new List<XSmallChatInfo>();

		// Token: 0x040052F2 RID: 21234
		public IXUITweenTool m_TweenTool;

		// Token: 0x040052F3 RID: 21235
		public IXUITweenTool m_BgTweenTool;

		// Token: 0x040052F4 RID: 21236
		public IXUISprite m_MainPanel;

		// Token: 0x040052F5 RID: 21237
		public IXUIPanel m_panel;

		// Token: 0x040052F6 RID: 21238
		public IXUIPanel m_contentPanel;

		// Token: 0x040052F7 RID: 21239
		public IXUISprite m_sprMailRed;

		// Token: 0x040052F8 RID: 21240
		public IXUIProgress m_Exp;

		// Token: 0x040052F9 RID: 21241
		public IXUILabel m_ExpValue;
	}
}
