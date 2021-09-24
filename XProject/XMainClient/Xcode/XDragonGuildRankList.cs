using System;

namespace XMainClient
{

	public class XDragonGuildRankList : XBaseRankList
	{

		public XDragonGuildRankList()
		{
			this.type = XRankType.DragonGuildRank;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XDragonGuildRankInfo();
		}
	}
}
