using System;

namespace XUtliPoolLib
{

	public class CompeteDragonRankRewardTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			CompeteDragonRankRewardTable.RowData rowData = new CompeteDragonRankRewardTable.RowData();
			base.Read<uint>(reader, ref rowData.rank, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.desigation, CVSReader.uintParse);
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
				this.Table = new CompeteDragonRankRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public CompeteDragonRankRewardTable.RowData[] Table = null;

		public class RowData
		{

			public uint rank;

			public uint desigation;

			public SeqListRef<int> reward;
		}
	}
}
