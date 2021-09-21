using System;

namespace XMainClient
{
	// Token: 0x02000D6F RID: 3439
	public class XGuildDragonGuildRankList : XBaseRankList
	{
		// Token: 0x0600BC90 RID: 48272 RVA: 0x0026D57B File Offset: 0x0026B77B
		public XGuildDragonGuildRankList()
		{
			this.type = XRankType.GuildBossRank;
		}

		// Token: 0x0600BC91 RID: 48273 RVA: 0x0026DEC8 File Offset: 0x0026C0C8
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XGuildDragonGuildRankInfo();
		}
	}
}
