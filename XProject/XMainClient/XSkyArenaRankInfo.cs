using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000D61 RID: 3425
	public class XSkyArenaRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BC73 RID: 48243 RVA: 0x0026DB08 File Offset: 0x0026BD08
		public override void ProcessData(RankData data)
		{
			this.rank = data.Rank;
			bool flag = data.skycity == null;
			if (!flag)
			{
				this.id = data.skycity.roleid;
				this.name = data.skycity.rolename;
				this.floor = data.skycity.floor;
				this.kill = data.skycity.killer;
				this.profession = data.skycity.job;
			}
		}

		// Token: 0x04004C72 RID: 19570
		public uint profession;

		// Token: 0x04004C73 RID: 19571
		public uint kill;

		// Token: 0x04004C74 RID: 19572
		public uint floor;
	}
}
