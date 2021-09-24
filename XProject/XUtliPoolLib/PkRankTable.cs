using System;

namespace XUtliPoolLib
{

	public class PkRankTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			PkRankTable.RowData rowData = new PkRankTable.RowData();
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
				this.Table = new PkRankTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PkRankTable.RowData[] Table = null;

		public class RowData
		{

			public SeqRef<uint> rank;

			public SeqListRef<uint> reward;
		}
	}
}
