using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D55 RID: 3413
	public class XFashionRankList : XBaseRankList
	{
		// Token: 0x0600BC57 RID: 48215 RVA: 0x0026D623 File Offset: 0x0026B823
		public XFashionRankList()
		{
			this.type = XRankType.FashionRank;
		}

		// Token: 0x0600BC58 RID: 48216 RVA: 0x0026D638 File Offset: 0x0026B838
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XPPTRankInfo();
		}

		// Token: 0x0600BC59 RID: 48217 RVA: 0x0026D650 File Offset: 0x0026B850
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
