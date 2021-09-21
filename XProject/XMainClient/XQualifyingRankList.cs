using System;

namespace XMainClient
{
	// Token: 0x02000D66 RID: 3430
	public class XQualifyingRankList : XBaseRankList
	{
		// Token: 0x0600BC7E RID: 48254 RVA: 0x0026DCDD File Offset: 0x0026BEDD
		public XQualifyingRankList()
		{
			this.type = XRankType.QualifyingRank;
		}

		// Token: 0x0600BC7F RID: 48255 RVA: 0x0026DCF0 File Offset: 0x0026BEF0
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XQualifyingRankInfo();
		}
	}
}
