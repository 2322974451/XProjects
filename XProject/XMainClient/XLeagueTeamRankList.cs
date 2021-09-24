using System;

namespace XMainClient
{

	public class XLeagueTeamRankList : XBaseRankList
	{

		public XLeagueTeamRankList()
		{
			this.type = XRankType.LeagueTeamRank;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XLeagueTeamRankInfo();
		}

		public override XBaseRankInfo GetLatestMyRankInfo()
		{
			bool flag = this.myRankInfo == null || this.myRankInfo.rank != XRankDocument.INVALID_RANK;
			XBaseRankInfo myRankInfo;
			if (flag)
			{
				myRankInfo = this.myRankInfo;
			}
			else
			{
				bool flag2 = this.myRankInfo == null;
				if (flag2)
				{
					this.myRankInfo = this.CreateNewInfo();
				}
				this.myRankInfo.rank = XRankDocument.INVALID_RANK;
				myRankInfo = this.myRankInfo;
			}
			return myRankInfo;
		}
	}
}
