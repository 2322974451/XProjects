using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D57 RID: 3415
	public class XLevelRankList : XBaseRankList
	{
		// Token: 0x0600BC5C RID: 48220 RVA: 0x0026D73B File Offset: 0x0026B93B
		public XLevelRankList()
		{
			this.type = XRankType.LevelRank;
		}

		// Token: 0x0600BC5D RID: 48221 RVA: 0x0026D74C File Offset: 0x0026B94C
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XLevelRankInfo();
		}

		// Token: 0x0600BC5E RID: 48222 RVA: 0x0026D764 File Offset: 0x0026B964
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
