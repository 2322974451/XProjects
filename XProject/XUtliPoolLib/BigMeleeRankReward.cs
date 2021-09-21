using System;

namespace XUtliPoolLib
{
	// Token: 0x0200023F RID: 575
	public class BigMeleeRankReward : CVSReader
	{
		// Token: 0x06000CA5 RID: 3237 RVA: 0x00042818 File Offset: 0x00040A18
		protected override void ReadLine(XBinaryReader reader)
		{
			BigMeleeRankReward.RowData rowData = new BigMeleeRankReward.RowData();
			rowData.levelrange.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			rowData.rank.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CA6 RID: 3238 RVA: 0x00042890 File Offset: 0x00040A90
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new BigMeleeRankReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400078D RID: 1933
		public BigMeleeRankReward.RowData[] Table = null;

		// Token: 0x020003CE RID: 974
		public class RowData
		{
			// Token: 0x04001122 RID: 4386
			public SeqRef<int> levelrange;

			// Token: 0x04001123 RID: 4387
			public SeqRef<int> rank;

			// Token: 0x04001124 RID: 4388
			public SeqListRef<int> reward;
		}
	}
}
