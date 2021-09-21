using System;

namespace XUtliPoolLib
{
	// Token: 0x0200014D RID: 333
	public class PokerTournamentReward : CVSReader
	{
		// Token: 0x06000797 RID: 1943 RVA: 0x000266A0 File Offset: 0x000248A0
		protected override void ReadLine(XBinaryReader reader)
		{
			PokerTournamentReward.RowData rowData = new PokerTournamentReward.RowData();
			rowData.Rank.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x00026700 File Offset: 0x00024900
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PokerTournamentReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000399 RID: 921
		public PokerTournamentReward.RowData[] Table = null;

		// Token: 0x0200034C RID: 844
		public class RowData
		{
			// Token: 0x04000D21 RID: 3361
			public SeqRef<uint> Rank;

			// Token: 0x04000D22 RID: 3362
			public SeqListRef<uint> Reward;
		}
	}
}
