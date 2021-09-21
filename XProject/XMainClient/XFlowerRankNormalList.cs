using System;

namespace XMainClient
{
	// Token: 0x02000D7A RID: 3450
	public class XFlowerRankNormalList : XBaseRankList
	{
		// Token: 0x0600BCA8 RID: 48296 RVA: 0x0026E3E0 File Offset: 0x0026C5E0
		public XFlowerRankNormalList()
		{
			this.type = XRankType.FlowerTodayRank;
		}

		// Token: 0x0600BCA9 RID: 48297 RVA: 0x0026E3F4 File Offset: 0x0026C5F4
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XFlowerRankNormalInfo();
		}
	}
}
