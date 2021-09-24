using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XChatSettingBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_WorldChat = (base.transform.FindChild("Bg/WorldChannel").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_GuildChat = (base.transform.FindChild("Bg/GuildChannel").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_FriendsChat = (base.transform.FindChild("Bg/FriendChannel").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_TeamChat = (base.transform.FindChild("Bg/TeamChannel").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_SystemChat = (base.transform.FindChild("Bg/SystemChannel").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_BackClick = (base.transform.FindChild("Bg/backclick").GetComponent("XUIButton") as IXUIButton);
			this.m_WorldChat.ID = 1UL;
			this.m_GuildChat.ID = 2UL;
			this.m_FriendsChat.ID = 3UL;
			this.m_TeamChat.ID = 7UL;
			this.m_SystemChat.ID = 4UL;
		}

		public IXUICheckBox m_WorldChat;

		public IXUICheckBox m_GuildChat;

		public IXUICheckBox m_FriendsChat;

		public IXUICheckBox m_TeamChat;

		public IXUICheckBox m_SystemChat;

		public IXUIButton m_BackClick;

		public IXUIButton m_Close;
	}
}
