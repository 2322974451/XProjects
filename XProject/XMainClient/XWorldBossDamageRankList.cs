using System;

namespace XMainClient
{

	public class XWorldBossDamageRankList : XBaseRankList
	{

		public XWorldBossDamageRankList()
		{
			this.type = XRankType.WorldBossDamageRank;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XWorldBossDamageRankInfo();
		}
	}
}
