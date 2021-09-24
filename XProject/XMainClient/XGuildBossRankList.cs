using System;

namespace XMainClient
{

	public class XGuildBossRankList : XBaseRankList
	{

		public XGuildBossRankList()
		{
			this.type = XRankType.GuildBossRank;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XGuildBossRankInfo();
		}
	}
}
