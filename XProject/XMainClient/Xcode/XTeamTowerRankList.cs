using System;

namespace XMainClient
{

	public class XTeamTowerRankList : XBaseRankList
	{

		public XTeamTowerRankList()
		{
			this.type = XRankType.TeamTowerRank;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XTeamTowerRankInfo();
		}
	}
}
