using System;

namespace XMainClient
{
	// Token: 0x02000D7C RID: 3452
	public class XFlowerRankActivityList : XBaseRankList
	{
		// Token: 0x0600BCAC RID: 48300 RVA: 0x0026E530 File Offset: 0x0026C730
		public XFlowerRankActivityList()
		{
			this.type = XRankType.FlowerActivityRank;
		}

		// Token: 0x0600BCAD RID: 48301 RVA: 0x0026E544 File Offset: 0x0026C744
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XFlowerRankActivityInfo();
		}
	}
}
