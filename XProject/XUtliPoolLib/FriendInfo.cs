using System;

namespace XUtliPoolLib
{
	// Token: 0x02000096 RID: 150
	public class FriendInfo
	{
		// Token: 0x040002B2 RID: 690
		public int apiId;

		// Token: 0x040002B3 RID: 691
		public FriendInfo.Data[] data;

		// Token: 0x020002A2 RID: 674
		public struct Data
		{
			// Token: 0x04000893 RID: 2195
			public string nickName;

			// Token: 0x04000894 RID: 2196
			public string openId;

			// Token: 0x04000895 RID: 2197
			public string gender;

			// Token: 0x04000896 RID: 2198
			public string pictureSmall;

			// Token: 0x04000897 RID: 2199
			public string pictureMiddle;

			// Token: 0x04000898 RID: 2200
			public string pictureLarge;

			// Token: 0x04000899 RID: 2201
			public string provice;

			// Token: 0x0400089A RID: 2202
			public string city;
		}
	}
}
