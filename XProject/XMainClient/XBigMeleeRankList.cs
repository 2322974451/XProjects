using System;

namespace XMainClient
{
	// Token: 0x02000D60 RID: 3424
	public class XBigMeleeRankList : XBaseRankList
	{
		// Token: 0x0600BC71 RID: 48241 RVA: 0x0026DADE File Offset: 0x0026BCDE
		public XBigMeleeRankList()
		{
			this.type = XRankType.BigMeleeRank;
		}

		// Token: 0x0600BC72 RID: 48242 RVA: 0x0026DAF0 File Offset: 0x0026BCF0
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XBigMeleeRankInfo();
		}
	}
}
