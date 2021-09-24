using System;

namespace XMainClient
{

	public class XCampDuelRankRightList : XBaseRankList
	{

		public XCampDuelRankRightList()
		{
			this.type = XRankType.CampDuelRankRight;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XCampDuelRankInfo();
		}
	}
}
