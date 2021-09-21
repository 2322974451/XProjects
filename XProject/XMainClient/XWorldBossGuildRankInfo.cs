using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000D69 RID: 3433
	public class XWorldBossGuildRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BC84 RID: 48260 RVA: 0x0026DD8F File Offset: 0x0026BF8F
		public override void ProcessData(RankData data)
		{
			this.name = data.RoleName;
			this.rank = data.Rank;
			this.damage = data.damage;
		}

		// Token: 0x04004C7A RID: 19578
		public float damage;
	}
}
