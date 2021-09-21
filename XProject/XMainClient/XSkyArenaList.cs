using System;

namespace XMainClient
{
	// Token: 0x02000D62 RID: 3426
	public class XSkyArenaList : XBaseRankList
	{
		// Token: 0x0600BC75 RID: 48245 RVA: 0x0026DB86 File Offset: 0x0026BD86
		public XSkyArenaList()
		{
			this.type = XRankType.SkyArenaRank;
		}

		// Token: 0x0600BC76 RID: 48246 RVA: 0x0026DB98 File Offset: 0x0026BD98
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XSkyArenaRankInfo();
		}
	}
}
