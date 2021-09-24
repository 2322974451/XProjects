using System;
using XUtliPoolLib;

namespace XMainClient
{

	public class XSpriteRankList : XBaseRankList
	{

		public XSpriteRankList()
		{
			this.type = XRankType.SpriteRank;
		}

		public override XBaseRankInfo CreateNewInfo()
		{
			return new XSpriteRankInfo();
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
