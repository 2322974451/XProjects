using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000D67 RID: 3431
	public class XRiftRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BC80 RID: 48256 RVA: 0x0026DD08 File Offset: 0x0026BF08
		public override void ProcessData(RankData data)
		{
			this.formatname = XBaseRankInfo.GetUnderLineName(this.name);
			this.rank = data.Rank;
			bool flag = data.riftRankData != null;
			if (flag)
			{
				this.passtime = data.riftRankData.passTime;
				this.floor = data.riftRankData.riftFloor;
			}
		}

		// Token: 0x04004C78 RID: 19576
		public uint passtime;

		// Token: 0x04004C79 RID: 19577
		public uint floor;
	}
}
