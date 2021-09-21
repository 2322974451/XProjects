using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000D7F RID: 3455
	public class XLeagueTeamRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BCB3 RID: 48307 RVA: 0x0026E6F0 File Offset: 0x0026C8F0
		public override void ProcessData(RankData data)
		{
			this.time = data.time;
			bool flag = data.leagueinfo != null;
			if (flag)
			{
				this.leagueTeamID = data.leagueinfo.league_teamid;
				this.serverID = data.leagueinfo.serverid;
				this.serverName = data.leagueinfo.servername;
				this.teamName = data.leagueinfo.teamname;
				this.point = data.leagueinfo.point;
				this.winNum = data.leagueinfo.winnum;
				this.winRate = data.leagueinfo.winrate;
				this.maxContineWins = data.leagueinfo.continuewin;
			}
			this.rank = data.Rank;
		}

		// Token: 0x04004C92 RID: 19602
		public ulong leagueTeamID;

		// Token: 0x04004C93 RID: 19603
		public uint serverID;

		// Token: 0x04004C94 RID: 19604
		public string serverName;

		// Token: 0x04004C95 RID: 19605
		public string teamName;

		// Token: 0x04004C96 RID: 19606
		public uint point;

		// Token: 0x04004C97 RID: 19607
		public uint winNum;

		// Token: 0x04004C98 RID: 19608
		public float winRate;

		// Token: 0x04004C99 RID: 19609
		public uint time;

		// Token: 0x04004C9A RID: 19610
		public uint maxContineWins;
	}
}
