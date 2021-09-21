using System;

namespace XMainClient
{
	// Token: 0x02000D53 RID: 3411
	public class XGuildBossRankList : XBaseRankList
	{
		// Token: 0x0600BC53 RID: 48211 RVA: 0x0026D57B File Offset: 0x0026B77B
		public XGuildBossRankList()
		{
			this.type = XRankType.GuildBossRank;
		}

		// Token: 0x0600BC54 RID: 48212 RVA: 0x0026D58C File Offset: 0x0026B78C
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XGuildBossRankInfo();
		}
	}
}
