using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XChatInputBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_BlackBg = (base.transform.Find("BlackBg").GetComponent("XUISprite") as IXUISprite);
			this.m_TextInput = (base.transform.Find("Bg/TextInput").GetComponent("XUIInput") as IXUIInput);
			this.m_sprInput = (base.transform.Find("Bg/TextInput").GetComponent("XUISprite") as IXUISprite);
			this.m_ShowLabel = (base.transform.Find("Bg/TextInput/ChatText").GetComponent("XUILabel") as IXUILabel);
			this.m_SendBtn = (base.transform.Find("Bg/Send").GetComponent("XUIButton") as IXUIButton);
			this.m_btnChatpic = (base.transform.Find("Bg/chatpic").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUISprite m_BlackBg;

		public IXUIInput m_TextInput;

		public IXUILabel m_ShowLabel;

		public IXUIButton m_SendBtn;

		public IXUIButton m_btnChatpic;

		public IXUISprite m_sprInput;
	}
}
