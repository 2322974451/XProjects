using System;

namespace XUtliPoolLib
{

	public class AncientTimesTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			AncientTimesTable.RowData rowData = new AncientTimesTable.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			rowData.nPoints.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.Items.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Title, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new AncientTimesTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public AncientTimesTable.RowData[] Table = null;

		public class RowData
		{

			public uint ID;

			public SeqRef<uint> nPoints;

			public SeqListRef<uint> Items;

			public string Title;
		}
	}
}
