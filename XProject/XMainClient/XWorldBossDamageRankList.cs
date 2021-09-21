using System;

namespace XMainClient
{
	// Token: 0x02000D6E RID: 3438
	public class XWorldBossDamageRankList : XBaseRankList
	{
		// Token: 0x0600BC8E RID: 48270 RVA: 0x0026DE9D File Offset: 0x0026C09D
		public XWorldBossDamageRankList()
		{
			this.type = XRankType.WorldBossDamageRank;
		}

		// Token: 0x0600BC8F RID: 48271 RVA: 0x0026DEB0 File Offset: 0x0026C0B0
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XWorldBossDamageRankInfo();
		}
	}
}
