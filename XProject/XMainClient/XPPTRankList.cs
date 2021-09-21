using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D59 RID: 3417
	public class XPPTRankList : XBaseRankList
	{
		// Token: 0x0600BC61 RID: 48225 RVA: 0x0026D85B File Offset: 0x0026BA5B
		public XPPTRankList()
		{
			this.type = XRankType.PPTRank;
		}

		// Token: 0x0600BC62 RID: 48226 RVA: 0x0026D86C File Offset: 0x0026BA6C
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XPPTRankInfo();
		}

		// Token: 0x0600BC63 RID: 48227 RVA: 0x0026D884 File Offset: 0x0026BA84
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
