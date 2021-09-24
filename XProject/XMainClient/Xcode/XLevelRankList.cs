using System;
using XUtliPoolLib;

namespace XMainClient
{

	public class XLevelRankList : XBaseRankList
	{

		public XLevelRankList()
		{
			this.type = XRankType.LevelRank;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XLevelRankInfo();
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
				this.myRankInfo.value = (ulong)XCharacterDocument.GetCharacterAttr().Level;
				myRankInfo = this.myRankInfo;
			}
			return myRankInfo;
		}
	}
}
