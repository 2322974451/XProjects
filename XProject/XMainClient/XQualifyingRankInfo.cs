using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000D65 RID: 3429
	public class XQualifyingRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BC7C RID: 48252 RVA: 0x0026DC64 File Offset: 0x0026BE64
		public override void ProcessData(RankData data)
		{
			this.name = data.RoleName;
			this.formatname = XBaseRankInfo.GetUnderLineName(this.name);
			this.id = data.RoleId;
			this.rank = data.Rank;
			this.profession = data.profession;
			this.rankScore = data.pkpoint;
			bool flag = data.pkextradata != null;
			if (flag)
			{
				this.totalNum = data.pkextradata.joincount;
			}
		}

		// Token: 0x04004C75 RID: 19573
		public uint rankScore;

		// Token: 0x04004C76 RID: 19574
		public uint profession;

		// Token: 0x04004C77 RID: 19575
		public uint totalNum;
	}
}
