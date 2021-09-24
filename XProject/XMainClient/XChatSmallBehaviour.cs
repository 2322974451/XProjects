using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XChatSmallBehaviour : DlgBehaviourBase
	{

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

		public static uint m_MaxShowMsg = 10U;

		public IXUISprite m_BgSprite;

		public IXUISprite m_RedPoint;

		public IXUISprite m_BgSpriteMini;

		public IXUISprite m_BgSpriteMain;

		public IXUISprite m_OpenWindow;

		public IXUISprite m_OpenWindowMini;

		public IXUILabelSymbol m_MiniText;

		public IXUISprite m_MiniTemplate;

		public IXUILabel m_AudioName;

		public IXUILabel m_AudioTime;

		public IXUILabel m_AudioContent;

		public IXUISprite m_MiniAudioTemplate;

		public XUIPool m_ChatPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIScrollView m_ScrollView;

		public List<XSmallChatInfo> ChatUIInfoList = new List<XSmallChatInfo>();

		public IXUITweenTool m_TweenTool;

		public IXUITweenTool m_BgTweenTool;

		public IXUISprite m_MainPanel;

		public IXUIPanel m_panel;

		public IXUIPanel m_contentPanel;

		public IXUISprite m_sprMailRed;

		public IXUIProgress m_Exp;

		public IXUILabel m_ExpValue;
	}
}
