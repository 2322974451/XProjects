using System;

namespace XMainClient
{

	public class XFlowerRankActivityList : XBaseRankList
	{

		public XFlowerRankActivityList()
		{
			this.type = XRankType.FlowerActivityRank;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XFlowerRankActivityInfo();
		}
	}
}
