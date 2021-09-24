using System;

namespace XMainClient
{

	public class XChickenDinnerRankList : XBaseRankList
	{

		public XChickenDinnerRankList()
		{
			this.type = XRankType.ChickenDinnerRank;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			this.myRankInfo = new XChickenDinnerRankInfo();
			(this.myRankInfo as XChickenDinnerRankInfo).InitMyData();
			this.myRankInfo.rank = XRankDocument.INVALID_RANK;
			return this.myRankInfo;
		}
	}
}
