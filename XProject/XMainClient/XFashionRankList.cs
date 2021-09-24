using System;
using XUtliPoolLib;

namespace XMainClient
{

	public class XFashionRankList : XBaseRankList
	{

		public XFashionRankList()
		{
			this.type = XRankType.FashionRank;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XPPTRankInfo();
		}

		public override XBaseRankInfo GetLatestMyRankInfo()
		{
			bool flag = this.myRankInfo == null || this.myRankInfo.rank != XRankDocument.INVALID_RANK;
			XBaseRankInfo myRankInfo;
			if (flag)
			{
				myRankInfo = this.myRankInfo;
			}
			else
			{
				this.myRankInfo.name = XSingleton<XEntityMgr>.singleton.Player.Name;
				this.myRankInfo.value = 0UL;
				myRankInfo = this.myRankInfo;
			}
			return myRankInfo;
		}
	}
}
