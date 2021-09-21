using System;

namespace XUtliPoolLib
{
	// Token: 0x02000221 RID: 545
	public class MilitaryRankReward : CVSReader
	{
		// Token: 0x06000C37 RID: 3127 RVA: 0x000402B0 File Offset: 0x0003E4B0
		protected override void ReadLine(XBinaryReader reader)
		{
			MilitaryRankReward.RowData rowData = new MilitaryRankReward.RowData();
			rowData.Rank.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C38 RID: 3128 RVA: 0x00040310 File Offset: 0x0003E510
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new MilitaryRankReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400076F RID: 1903
		public MilitaryRankReward.RowData[] Table = null;

		// Token: 0x020003B0 RID: 944
		public class RowData
		{
			// Token: 0x04001085 RID: 4229
			public SeqRef<uint> Rank;

			// Token: 0x04001086 RID: 4230
			public SeqListRef<uint> Reward;
		}
	}
}
