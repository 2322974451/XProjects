using System;

namespace XUtliPoolLib
{
	// Token: 0x020000F6 RID: 246
	public class FlowerWeekRankReward : CVSReader
	{
		// Token: 0x06000652 RID: 1618 RVA: 0x0001E9C8 File Offset: 0x0001CBC8
		protected override void ReadLine(XBinaryReader reader)
		{
			FlowerWeekRankReward.RowData rowData = new FlowerWeekRankReward.RowData();
			rowData.Rank.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x0001EA28 File Offset: 0x0001CC28
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FlowerWeekRankReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000342 RID: 834
		public FlowerWeekRankReward.RowData[] Table = null;

		// Token: 0x020002F5 RID: 757
		public class RowData
		{
			// Token: 0x04000AE7 RID: 2791
			public SeqRef<int> Rank;

			// Token: 0x04000AE8 RID: 2792
			public SeqListRef<int> Reward;
		}
	}
}
