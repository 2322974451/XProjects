using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D4F RID: 3407
	public class XTeamTowerRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BC49 RID: 48201 RVA: 0x0026D274 File Offset: 0x0026B474
		public override void ProcessData(RankData data)
		{
			this.memberCount = (uint)data.RoleIds.Count;
			bool flag = this.memberCount > 0U;
			if (flag)
			{
				this.name = data.RoleNames[0];
				this.id = data.RoleIds[0];
				this.formatname = XTitleDocument.GetTitleWithFormat((data.titleIDs.Count > 0) ? data.titleIDs[0] : 0U, XBaseRankInfo.GetUnderLineName(this.name));
			}
			bool flag2 = this.memberCount > 1U;
			if (flag2)
			{
				this.name1 = data.RoleNames[1];
				this.id1 = data.RoleIds[1];
				this.formatname1 = XTitleDocument.GetTitleWithFormat((data.titleIDs.Count > 1) ? data.titleIDs[1] : 0U, XBaseRankInfo.GetUnderLineName(this.name1));
			}
			this.rank = data.Rank;
			this.value = (ulong)data.towerThroughTime;
			this.diff = data.towerHardLevel;
			this.levelCount = data.towerFloor;
			this.m_Time = XSingleton<UiUtility>.singleton.TimeFormatString((int)this.value, 2, 3, 4, false, true);
			this.startType = data.starttype;
		}

		// Token: 0x0600BC4A RID: 48202 RVA: 0x0026D3B8 File Offset: 0x0026B5B8
		public override string GetValue()
		{
			return this.m_Time;
		}

		// Token: 0x04004C5C RID: 19548
		public ulong id1;

		// Token: 0x04004C5D RID: 19549
		public string name1;

		// Token: 0x04004C5E RID: 19550
		public string formatname1;

		// Token: 0x04004C5F RID: 19551
		public uint diff;

		// Token: 0x04004C60 RID: 19552
		public uint levelCount;

		// Token: 0x04004C61 RID: 19553
		public uint memberCount;

		// Token: 0x04004C62 RID: 19554
		private string m_Time;
	}
}
