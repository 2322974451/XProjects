using System;

namespace XMainClient
{
	// Token: 0x02000E1E RID: 3614
	public class ChatItemInfo
	{
		// Token: 0x04005346 RID: 21318
		public string itemInfoStr = "";

		// Token: 0x04005347 RID: 21319
		public byte[] speakData;

		// Token: 0x04005348 RID: 21320
		public string speakUrl;

		// Token: 0x04005349 RID: 21321
		public bool isVoiceLocalPath = false;

		// Token: 0x0400534A RID: 21322
		public bool isLeft = false;

		// Token: 0x0400534B RID: 21323
		public int cachedPlayerID;

		// Token: 0x0400534C RID: 21324
		public string cachedPlayerName;

		// Token: 0x0400534D RID: 21325
		public int cachedTeamId;

		// Token: 0x0400534E RID: 21326
		public bool cachedIsFriend = false;
	}
}
