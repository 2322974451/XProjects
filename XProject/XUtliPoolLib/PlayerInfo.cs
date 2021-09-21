using System;

namespace XUtliPoolLib
{
	// Token: 0x02000097 RID: 151
	public class PlayerInfo
	{
		// Token: 0x040002B4 RID: 692
		public int apiId;

		// Token: 0x040002B5 RID: 693
		public PlayerInfo.Data data;

		// Token: 0x020002A3 RID: 675
		public struct Data
		{
			// Token: 0x0400089B RID: 2203
			public string nickName;

			// Token: 0x0400089C RID: 2204
			public string openId;

			// Token: 0x0400089D RID: 2205
			public string gender;

			// Token: 0x0400089E RID: 2206
			public string pictureSmall;

			// Token: 0x0400089F RID: 2207
			public string pictureMiddle;

			// Token: 0x040008A0 RID: 2208
			public string pictureLarge;

			// Token: 0x040008A1 RID: 2209
			public string provice;

			// Token: 0x040008A2 RID: 2210
			public string city;
		}
	}
}
