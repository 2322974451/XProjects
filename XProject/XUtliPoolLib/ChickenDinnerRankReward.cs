using System;

namespace XUtliPoolLib
{
	// Token: 0x0200025C RID: 604
	public class ChickenDinnerRankReward : CVSReader
	{
		// Token: 0x06000D0F RID: 3343 RVA: 0x00044EA8 File Offset: 0x000430A8
		protected override void ReadLine(XBinaryReader reader)
		{
			ChickenDinnerRankReward.RowData rowData = new ChickenDinnerRankReward.RowData();
			rowData.rank.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D10 RID: 3344 RVA: 0x00044F08 File Offset: 0x00043108
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ChickenDinnerRankReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007AA RID: 1962
		public ChickenDinnerRankReward.RowData[] Table = null;

		// Token: 0x020003EB RID: 1003
		public class RowData
		{
			// Token: 0x040011CD RID: 4557
			public SeqRef<int> rank;

			// Token: 0x040011CE RID: 4558
			public SeqListRef<int> reward;
		}
	}
}
