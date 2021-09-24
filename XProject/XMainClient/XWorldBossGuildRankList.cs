using System;

namespace XMainClient
{

	public class XWorldBossGuildRankList : XBaseRankList
	{

		public XWorldBossGuildRankList()
		{
			this.type = XRankType.WorldBossGuildRank;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XWorldBossGuildRankInfo();
		}
	}
}
