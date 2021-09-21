using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000D5A RID: 3418
	public class XPetRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BC64 RID: 48228 RVA: 0x0026D8F4 File Offset: 0x0026BAF4
		public override void ProcessData(RankData data)
		{
			this.name = data.RoleName;
			this.formatname = XBaseRankInfo.GetUnderLineName(this.name);
			this.id = data.RoleId;
			this.rank = data.Rank;
			this.value = (ulong)data.powerpoint;
			this.petID = data.petid;
			this.petUID = data.petuid;
		}

		// Token: 0x04004C6D RID: 19565
		public uint petID;

		// Token: 0x04004C6E RID: 19566
		public ulong petUID;
	}
}
