using System;

namespace XMainClient
{
	// Token: 0x02000D64 RID: 3428
	public class XChickenDinnerRankList : XBaseRankList
	{
		// Token: 0x0600BC7A RID: 48250 RVA: 0x0026DC0C File Offset: 0x0026BE0C
		public XChickenDinnerRankList()
		{
			this.type = XRankType.ChickenDinnerRank;
		}

		// Token: 0x0600BC7B RID: 48251 RVA: 0x0026DC20 File Offset: 0x0026BE20
		public override XBaseRankInfo CreateNewInfo()
		{
			this.myRankInfo = new XChickenDinnerRankInfo();
			(this.myRankInfo as XChickenDinnerRankInfo).InitMyData();
			this.myRankInfo.rank = XRankDocument.INVALID_RANK;
			return this.myRankInfo;
		}
	}
}
