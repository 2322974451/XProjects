using System;

namespace XMainClient
{

	public class XCampDuelRankLeftList : XBaseRankList
	{

		public XCampDuelRankLeftList()
		{
			this.type = XRankType.CampDuelRankLeft;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XCampDuelRankInfo();
		}
	}
}
