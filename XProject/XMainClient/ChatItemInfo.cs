using System;

namespace XMainClient
{

	public class ChatItemInfo
	{

		public string itemInfoStr = "";

		public byte[] speakData;

		public string speakUrl;

		public bool isVoiceLocalPath = false;

		public bool isLeft = false;

		public int cachedPlayerID;

		public string cachedPlayerName;

		public int cachedTeamId;

		public bool cachedIsFriend = false;
	}
}
