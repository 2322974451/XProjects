using System;

namespace XMainClient
{
	// Token: 0x02000D6C RID: 3436
	public class XWorldBossGuildRoleRankList : XBaseRankList
	{
		// Token: 0x0600BC8A RID: 48266 RVA: 0x0026DE12 File Offset: 0x0026C012
		public XWorldBossGuildRoleRankList()
		{
			this.type = XRankType.WorldBossGuildRoleRank;
		}

		// Token: 0x0600BC8B RID: 48267 RVA: 0x0026DE24 File Offset: 0x0026C024
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XWorldBossGuildRoleRankInfo();
		}
	}
}
