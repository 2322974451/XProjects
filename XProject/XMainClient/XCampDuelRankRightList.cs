using System;

namespace XMainClient
{
	// Token: 0x02000D5E RID: 3422
	public class XCampDuelRankRightList : XBaseRankList
	{
		// Token: 0x0600BC6C RID: 48236 RVA: 0x0026D9E7 File Offset: 0x0026BBE7
		public XCampDuelRankRightList()
		{
			this.type = XRankType.CampDuelRankRight;
		}

		// Token: 0x0600BC6D RID: 48237 RVA: 0x0026D9FC File Offset: 0x0026BBFC
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XCampDuelRankInfo();
		}
	}
}
