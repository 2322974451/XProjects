using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000CC7 RID: 3271
	internal class XChatInputBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B791 RID: 46993 RVA: 0x00249EE0 File Offset: 0x002480E0
		private void Awake()
		{
			this.m_BlackBg = (base.transform.Find("BlackBg").GetComponent("XUISprite") as IXUISprite);
			this.m_TextInput = (base.transform.Find("Bg/TextInput").GetComponent("XUIInput") as IXUIInput);
			this.m_sprInput = (base.transform.Find("Bg/TextInput").GetComponent("XUISprite") as IXUISprite);
			this.m_ShowLabel = (base.transform.Find("Bg/TextInput/ChatText").GetComponent("XUILabel") as IXUILabel);
			this.m_SendBtn = (base.transform.Find("Bg/Send").GetComponent("XUIButton") as IXUIButton);
			this.m_btnChatpic = (base.transform.Find("Bg/chatpic").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x04004839 RID: 18489
		public IXUISprite m_BlackBg;

		// Token: 0x0400483A RID: 18490
		public IXUIInput m_TextInput;

		// Token: 0x0400483B RID: 18491
		public IXUILabel m_ShowLabel;

		// Token: 0x0400483C RID: 18492
		public IXUIButton m_SendBtn;

		// Token: 0x0400483D RID: 18493
		public IXUIButton m_btnChatpic;

		// Token: 0x0400483E RID: 18494
		public IXUISprite m_sprInput;
	}
}
