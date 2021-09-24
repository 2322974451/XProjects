using System;

namespace XUtliPoolLib
{

	public class TerritoryRewd : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			TerritoryRewd.RowData rowData = new TerritoryRewd.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Point, CVSReader.intParse);
			this.columnno = 1;
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
				this.Table = new TerritoryRewd.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public TerritoryRewd.RowData[] Table = null;

		public class RowData
		{

			public int ID;

			public int Point;

			public SeqListRef<uint> Reward;
		}
	}
}
