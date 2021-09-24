using System;

namespace XMainClient
{

	public class XBigMeleeRankList : XBaseRankList
	{

		public XBigMeleeRankList()
		{
			this.type = XRankType.BigMeleeRank;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XBigMeleeRankInfo();
		}
	}
}
