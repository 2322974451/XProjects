using System;

namespace XMainClient
{

	public class XQualifyingRankList : XBaseRankList
	{

		public XQualifyingRankList()
		{
			this.type = XRankType.QualifyingRank;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XQualifyingRankInfo();
		}
	}
}
