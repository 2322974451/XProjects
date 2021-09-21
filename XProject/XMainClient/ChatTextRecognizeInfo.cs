using System;

namespace XMainClient
{
	// Token: 0x02000E2B RID: 3627
	public class ChatTextRecognizeInfo
	{
		// Token: 0x0600C2F9 RID: 49913 RVA: 0x0029FB1A File Offset: 0x0029DD1A
		public ChatTextRecognizeInfo(ChatInfo chatInfo, ChatItemInfo chatItemInfo)
		{
			this.chatInfo = chatInfo;
			this.chatItemInfo = chatItemInfo;
		}

		// Token: 0x0600C2FA RID: 49914 RVA: 0x0029FB32 File Offset: 0x0029DD32
		public void Clear()
		{
			this.chatInfo = null;
			this.chatItemInfo = null;
		}

		// Token: 0x040053C8 RID: 21448
		public ChatInfo chatInfo;

		// Token: 0x040053C9 RID: 21449
		public ChatItemInfo chatItemInfo;
	}
}
