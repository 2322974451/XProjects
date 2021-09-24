using System;

namespace XUtliPoolLib
{

	public class PokerTournamentReward : CVSReader
	{

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

		public PokerTournamentReward.RowData[] Table = null;

		public class RowData
		{

			public SeqRef<uint> Rank;

			public SeqListRef<uint> Reward;
		}
	}
}
