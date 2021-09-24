using System;

namespace XUtliPoolLib
{

	public class ChickenDinnerRankReward : CVSReader
	{

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

		public ChickenDinnerRankReward.RowData[] Table = null;

		public class RowData
		{

			public SeqRef<int> rank;

			public SeqListRef<int> reward;
		}
	}
}
