using System;

namespace XUtliPoolLib
{
	// Token: 0x0200009B RID: 155
	public class WXGroupInfo
	{
		// Token: 0x040002C4 RID: 708
		public int apiId;

		// Token: 0x040002C5 RID: 709
		public WXGroupInfo.Data data;

		// Token: 0x020002A4 RID: 676
		public struct Data
		{
			// Token: 0x040008A3 RID: 2211
			public string flag;

			// Token: 0x040008A4 RID: 2212
			public int errorCode;

			// Token: 0x040008A5 RID: 2213
			public string count;

			// Token: 0x040008A6 RID: 2214
			public string openIdList;
		}
	}
}
