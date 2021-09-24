using System;

namespace XMainClient
{

	public class XGuildDragonGuildRankList : XBaseRankList
	{

		public XGuildDragonGuildRankList()
		{
			this.type = XRankType.GuildBossRank;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XGuildDragonGuildRankInfo();
		}
	}
}
