using System;

namespace XUtliPoolLib
{

	public class MilitaryRankReward : CVSReader
	{

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

		public MilitaryRankReward.RowData[] Table = null;

		public class RowData
		{

			public SeqRef<uint> Rank;

			public SeqListRef<uint> Reward;
		}
	}
}
