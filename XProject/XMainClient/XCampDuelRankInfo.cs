using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000D5C RID: 3420
	public class XCampDuelRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BC68 RID: 48232 RVA: 0x0026D987 File Offset: 0x0026BB87
		public override void ProcessData(RankData data)
		{
			this.id = data.RoleId;
			this.value = (ulong)data.powerpoint;
			this.name = data.RoleName;
			this.rank = data.Rank;
		}
	}
}
