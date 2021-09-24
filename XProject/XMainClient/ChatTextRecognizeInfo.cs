using System;

namespace XMainClient
{

	public class ChatTextRecognizeInfo
	{

		public ChatTextRecognizeInfo(ChatInfo chatInfo, ChatItemInfo chatItemInfo)
		{
			this.chatInfo = chatInfo;
			this.chatItemInfo = chatItemInfo;
		}

		public void Clear()
		{
			this.chatInfo = null;
			this.chatItemInfo = null;
		}

		public ChatInfo chatInfo;

		public ChatItemInfo chatItemInfo;
	}
}
