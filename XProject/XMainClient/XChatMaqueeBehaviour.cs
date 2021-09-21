using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000E18 RID: 3608
	internal class XChatMaqueeBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C22D RID: 49709 RVA: 0x0029B7A8 File Offset: 0x002999A8
		private void Awake()
		{
			this.m_MaqueeTextSymbol = (base.transform.FindChild("Bg/content").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_MaqueeText = (base.transform.FindChild("Bg/content").GetComponent("XUILabel") as IXUILabel);
			this.m_MaqueeBoard = (base.transform.FindChild("Notice").GetComponent("XUISprite") as IXUISprite);
			this.m_MaqueeTween = (base.transform.FindChild("Notice").GetComponent("XUIPlayTween") as IXUITweenTool);
		}

		// Token: 0x040052FA RID: 21242
		public IXUILabel m_MaqueeText;

		// Token: 0x040052FB RID: 21243
		public IXUILabelSymbol m_MaqueeTextSymbol;

		// Token: 0x040052FC RID: 21244
		public IXUISprite m_MaqueeBoard;

		// Token: 0x040052FD RID: 21245
		public IXUITweenTool m_MaqueeTween;
	}
}
