using System;

namespace XMainClient
{
	// Token: 0x02000D6A RID: 3434
	public class XWorldBossGuildRankList : XBaseRankList
	{
		// Token: 0x0600BC86 RID: 48262 RVA: 0x0026DDB6 File Offset: 0x0026BFB6
		public XWorldBossGuildRankList()
		{
			this.type = XRankType.WorldBossGuildRank;
		}

		// Token: 0x0600BC87 RID: 48263 RVA: 0x0026DDC8 File Offset: 0x0026BFC8
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XWorldBossGuildRankInfo();
		}
	}
}
