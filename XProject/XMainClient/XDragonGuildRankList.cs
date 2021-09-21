using System;

namespace XMainClient
{
	// Token: 0x02000D74 RID: 3444
	public class XDragonGuildRankList : XBaseRankList
	{
		// Token: 0x0600BC9C RID: 48284 RVA: 0x0026E179 File Offset: 0x0026C379
		public XDragonGuildRankList()
		{
			this.type = XRankType.DragonGuildRank;
		}

		// Token: 0x0600BC9D RID: 48285 RVA: 0x0026E18C File Offset: 0x0026C38C
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XDragonGuildRankInfo();
		}
	}
}
