using System;
using XUtliPoolLib;

namespace XMainClient
{

	public class XPPTRankList : XBaseRankList
	{

		public XPPTRankList()
		{
			this.type = XRankType.PPTRank;
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
				this.myRankInfo.value = (ulong)XCharacterDocument.GetCharacterPPT();
				myRankInfo = this.myRankInfo;
			}
			return myRankInfo;
		}
	}
}
