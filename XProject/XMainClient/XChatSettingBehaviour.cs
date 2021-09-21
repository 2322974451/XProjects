using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000E19 RID: 3609
	internal class XChatSettingBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C22F RID: 49711 RVA: 0x0029B84C File Offset: 0x00299A4C
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

		// Token: 0x040052FE RID: 21246
		public IXUICheckBox m_WorldChat;

		// Token: 0x040052FF RID: 21247
		public IXUICheckBox m_GuildChat;

		// Token: 0x04005300 RID: 21248
		public IXUICheckBox m_FriendsChat;

		// Token: 0x04005301 RID: 21249
		public IXUICheckBox m_TeamChat;

		// Token: 0x04005302 RID: 21250
		public IXUICheckBox m_SystemChat;

		// Token: 0x04005303 RID: 21251
		public IXUIButton m_BackClick;

		// Token: 0x04005304 RID: 21252
		public IXUIButton m_Close;
	}
}
