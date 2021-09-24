using System;

namespace XMainClient
{

	public class XGuildRankList : XBaseRankList
	{

		public XGuildRankList()
		{
			this.type = XRankType.GuildRank;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XGuildRankInfo();
		}
	}
}
