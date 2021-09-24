using System;

namespace XUtliPoolLib
{

	public class BigMeleeRankReward : CVSReader
	{

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

		public BigMeleeRankReward.RowData[] Table = null;

		public class RowData
		{

			public SeqRef<int> levelrange;

			public SeqRef<int> rank;

			public SeqListRef<int> reward;
		}
	}
}
