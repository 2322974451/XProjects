using System;

namespace XMainClient
{
	// Token: 0x02000D52 RID: 3410
	public class XTeamTowerRankList : XBaseRankList
	{
		// Token: 0x0600BC51 RID: 48209 RVA: 0x0026D550 File Offset: 0x0026B750
		public XTeamTowerRankList()
		{
			this.type = XRankType.TeamTowerRank;
		}

		// Token: 0x0600BC52 RID: 48210 RVA: 0x0026D564 File Offset: 0x0026B764
		public override XBaseRankInfo CreateNewInfo()
		{
			return new XTeamTowerRankInfo();
		}
	}
}
