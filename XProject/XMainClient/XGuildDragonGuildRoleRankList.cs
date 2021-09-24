using System;

namespace XMainClient
{

	public class XGuildDragonGuildRoleRankList : XBaseRankList
	{

		public XGuildDragonGuildRoleRankList()
		{
			this.type = XRankType.GuildBossRoleRank;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XGuildDragonGuildRoleRankInfo();
		}
	}
}
