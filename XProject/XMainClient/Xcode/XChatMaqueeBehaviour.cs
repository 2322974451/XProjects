using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XChatMaqueeBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_MaqueeTextSymbol = (base.transform.FindChild("Bg/content").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_MaqueeText = (base.transform.FindChild("Bg/content").GetComponent("XUILabel") as IXUILabel);
			this.m_MaqueeBoard = (base.transform.FindChild("Notice").GetComponent("XUISprite") as IXUISprite);
			this.m_MaqueeTween = (base.transform.FindChild("Notice").GetComponent("XUIPlayTween") as IXUITweenTool);
		}

		public IXUILabel m_MaqueeText;

		public IXUILabelSymbol m_MaqueeTextSymbol;

		public IXUISprite m_MaqueeBoard;

		public IXUITweenTool m_MaqueeTween;
	}
}
