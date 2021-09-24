using System;

namespace XUtliPoolLib
{

	public class FlowerRankRewardTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			FlowerRankRewardTable.RowData rowData = new FlowerRankRewardTable.RowData();
			rowData.rank.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.yesterday, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.history, CVSReader.uintParse);
			this.columnno = 3;
			rowData.activity.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FlowerRankRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FlowerRankRewardTable.RowData[] Table = null;

		public class RowData
		{

			public SeqRef<int> rank;

			public SeqListRef<int> reward;

			public uint yesterday;

			public uint history;

			public SeqListRef<int> activity;
		}
	}
}
