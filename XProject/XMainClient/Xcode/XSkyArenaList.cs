using System;

namespace XMainClient
{

	public class XSkyArenaList : XBaseRankList
	{

		public XSkyArenaList()
		{
			this.type = XRankType.SkyArenaRank;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XSkyArenaRankInfo();
		}
	}
}
