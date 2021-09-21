using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000D6B RID: 3435
	public class XWorldBossGuildRoleRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BC88 RID: 48264 RVA: 0x0026DDDF File Offset: 0x0026BFDF
		public override void ProcessData(RankData data)
		{
			this.name = data.RoleName;
			this.rank = data.Rank;
			this.damage = data.damage;
			this.id = data.RoleId;
		}

		// Token: 0x04004C7B RID: 19579
		public float damage;
	}
}
