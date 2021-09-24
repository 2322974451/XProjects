using System;

namespace XMainClient
{

	public class XWorldBossGuildRoleRankList : XBaseRankList
	{

		public XWorldBossGuildRoleRankList()
		{
			this.type = XRankType.WorldBossGuildRoleRank;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XWorldBossGuildRoleRankInfo();
		}
	}
}
