using System;

namespace XUtliPoolLib
{

	public class FlowerWeekRankReward : CVSReader
	{

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

		public FlowerWeekRankReward.RowData[] Table = null;

		public class RowData
		{

			public SeqRef<int> Rank;

			public SeqListRef<int> Reward;
		}
	}
}
