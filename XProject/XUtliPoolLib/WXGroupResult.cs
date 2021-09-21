using System;

namespace XUtliPoolLib
{
	// Token: 0x0200009C RID: 156
	public class WXGroupResult
	{
		// Token: 0x040002C6 RID: 710
		public int apiId;

		// Token: 0x040002C7 RID: 711
		public WXGroupResult.Data data;

		// Token: 0x020002A5 RID: 677
		public struct Data
		{
			// Token: 0x040008A7 RID: 2215
			public int errorCode;

			// Token: 0x040008A8 RID: 2216
			public string flag;
		}
	}
}
