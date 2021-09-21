using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D7E RID: 3454
	public class XSpriteRankList : XBaseRankList
	{
		// Token: 0x0600BCB0 RID: 48304 RVA: 0x0026E5C3 File Offset: 0x0026C7C3
		public XSpriteRankList()
		{
			this.type = XRankType.SpriteRank;
		}

		// Token: 0x0600BCB1 RID: 48305 RVA: 0x0026E5D8 File Offset: 0x0026C7D8
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XSpriteRankInfo();
		}

		// Token: 0x0600BCB2 RID: 48306 RVA: 0x0026E5F0 File Offset: 0x0026C7F0
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
				this.myRankInfo.formatname = XTitleDocument.GetTitleWithFormat(XSingleton<XAttributeMgr>.singleton.XPlayerData.TitleID, this.myRankInfo.name);
				uint num = 0U;
				XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
				for (int i = 0; i < specificDocument.SpriteList.Count; i++)
				{
					bool flag2 = specificDocument.isSpriteFight(specificDocument.SpriteList[i].uid);
					if (flag2)
					{
						num += specificDocument.SpriteList[i].PowerPoint;
					}
				}
				this.myRankInfo.value = (ulong)num;
				myRankInfo = this.myRankInfo;
			}
			return myRankInfo;
		}
	}
}
