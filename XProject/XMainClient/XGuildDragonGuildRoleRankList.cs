using System;

namespace XMainClient
{
	// Token: 0x02000D71 RID: 3441
	public class XGuildDragonGuildRoleRankList : XBaseRankList
	{
		// Token: 0x0600BC95 RID: 48277 RVA: 0x0026DFBC File Offset: 0x0026C1BC
		public XGuildDragonGuildRoleRankList()
		{
			this.type = XRankType.GuildBossRoleRank;
		}

		// Token: 0x0600BC96 RID: 48278 RVA: 0x0026DFD0 File Offset: 0x0026C1D0
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XGuildDragonGuildRoleRankInfo();
		}
	}
}
