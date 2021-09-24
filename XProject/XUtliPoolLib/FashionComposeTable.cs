using System;

namespace XUtliPoolLib
{

	public class FashionComposeTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			FashionComposeTable.RowData rowData = new FashionComposeTable.RowData();
			base.Read<int>(reader, ref rowData.FashionID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.FashionLevel, CVSReader.intParse);
			this.columnno = 1;
			rowData.Attributes.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FashionComposeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FashionComposeTable.RowData[] Table = null;

		public class RowData
		{

			public int FashionID;

			public int FashionLevel;

			public SeqListRef<uint> Attributes;
		}
	}
}
