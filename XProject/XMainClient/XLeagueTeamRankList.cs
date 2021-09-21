using System;

namespace XMainClient
{
	// Token: 0x02000D80 RID: 3456
	public class XLeagueTeamRankList : XBaseRankList
	{
		// Token: 0x0600BCB5 RID: 48309 RVA: 0x0026E7B0 File Offset: 0x0026C9B0
		public XLeagueTeamRankList()
		{
			this.type = XRankType.LeagueTeamRank;
		}

		// Token: 0x0600BCB6 RID: 48310 RVA: 0x0026E7C4 File Offset: 0x0026C9C4
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XLeagueTeamRankInfo();
		}

		// Token: 0x0600BCB7 RID: 48311 RVA: 0x0026E7DC File Offset: 0x0026C9DC
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
