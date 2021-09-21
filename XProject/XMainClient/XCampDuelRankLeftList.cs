using System;

namespace XMainClient
{
	// Token: 0x02000D5D RID: 3421
	public class XCampDuelRankLeftList : XBaseRankList
	{
		// Token: 0x0600BC6A RID: 48234 RVA: 0x0026D9BB File Offset: 0x0026BBBB
		public XCampDuelRankLeftList()
		{
			this.type = XRankType.CampDuelRankLeft;
		}

		// Token: 0x0600BC6B RID: 48235 RVA: 0x0026D9D0 File Offset: 0x0026BBD0
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XCampDuelRankInfo();
		}
	}
}
