using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000A27 RID: 2599
	public class RankRewardData
	{
		// Token: 0x06009EC4 RID: 40644 RVA: 0x001A29BD File Offset: 0x001A0BBD
		public RankRewardData()
		{
			this.rewardID = new List<int>();
			this.rewardCount = new List<int>();
		}

		// Token: 0x04003879 RID: 14457
		public uint id;

		// Token: 0x0400387A RID: 14458
		public int rankMIN;

		// Token: 0x0400387B RID: 14459
		public int rankMAX;

		// Token: 0x0400387C RID: 14460
		public List<int> rewardID;

		// Token: 0x0400387D RID: 14461
		public List<int> rewardCount;
	}
}
