using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000D6D RID: 3437
	public class XWorldBossDamageRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BC8C RID: 48268 RVA: 0x0026DE3C File Offset: 0x0026C03C
		public override void ProcessData(RankData data)
		{
			this.name = data.RoleName;
			this.formatname = XTitleDocument.GetTitleWithFormat(data.titleID, data.RoleName);
			this.id = data.RoleId;
			this.rank = data.Rank;
			this.damage = data.damage;
			this.profession = data.profession;
		}

		// Token: 0x04004C7C RID: 19580
		public float damage;

		// Token: 0x04004C7D RID: 19581
		public uint profession;
	}
}
