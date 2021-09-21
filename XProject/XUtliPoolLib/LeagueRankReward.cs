using System;

namespace XUtliPoolLib
{
	// Token: 0x02000125 RID: 293
	public class LeagueRankReward : CVSReader
	{
		// Token: 0x06000707 RID: 1799 RVA: 0x00023060 File Offset: 0x00021260
		protected override void ReadLine(XBinaryReader reader)
		{
			LeagueRankReward.RowData rowData = new LeagueRankReward.RowData();
			rowData.rank.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x000230C0 File Offset: 0x000212C0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new LeagueRankReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000371 RID: 881
		public LeagueRankReward.RowData[] Table = null;

		// Token: 0x02000324 RID: 804
		public class RowData
		{
			// Token: 0x04000C1D RID: 3101
			public SeqRef<uint> rank;

			// Token: 0x04000C1E RID: 3102
			public SeqListRef<uint> reward;
		}
	}
}
