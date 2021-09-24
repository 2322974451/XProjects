using System;
using KKSG;

namespace XMainClient
{

	public class XLeagueTeamRankInfo : XBaseRankInfo
	{

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

		public ulong leagueTeamID;

		public uint serverID;

		public string serverName;

		public string teamName;

		public uint point;

		public uint winNum;

		public float winRate;

		public uint time;

		public uint maxContineWins;
	}
}
