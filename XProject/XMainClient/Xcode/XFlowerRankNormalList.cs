using System;

namespace XMainClient
{

	public class XFlowerRankNormalList : XBaseRankList
	{

		public XFlowerRankNormalList()
		{
			this.type = XRankType.FlowerTodayRank;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XFlowerRankNormalInfo();
		}
	}
}
