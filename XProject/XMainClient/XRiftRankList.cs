using System;

namespace XMainClient
{

	public class XRiftRankList : XBaseRankList
	{

		public XRiftRankList()
		{
			this.type = XRankType.RiftRank;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XRiftRankInfo();
		}
	}
}
