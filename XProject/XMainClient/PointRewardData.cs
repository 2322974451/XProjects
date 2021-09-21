using System;

namespace XMainClient
{
	// Token: 0x02000A29 RID: 2601
	internal struct PointRewardData
	{
		// Token: 0x06009ECF RID: 40655 RVA: 0x001A2EB4 File Offset: 0x001A10B4
		public void Init()
		{
			this.id = 0U;
			this.point = 0;
			this.rewardItem = new XBetterDictionary<int, int>(0);
		}

		// Token: 0x04003886 RID: 14470
		public uint id;

		// Token: 0x04003887 RID: 14471
		public int point;

		// Token: 0x04003888 RID: 14472
		public XBetterDictionary<int, int> rewardItem;
	}
}
