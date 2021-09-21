using System;
using KKSG;

namespace XMainClient.UI
{
	// Token: 0x0200187D RID: 6269
	internal interface IRankSource
	{
		// Token: 0x06010504 RID: 66820
		void ReqRankData(RankeType type, bool inFight);

		// Token: 0x06010505 RID: 66821
		XBaseRankList GetRankList(RankeType type);
	}
}
