using System;

namespace XUtliPoolLib
{

	public class CardsFireProperty : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			CardsFireProperty.RowData rowData = new CardsFireProperty.RowData();
			base.Read<uint>(reader, ref rowData.GroupId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.FireCounts, CVSReader.uintParse);
			this.columnno = 1;
			rowData.Promote.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.BreakLevel, CVSReader.uintParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CardsFireProperty.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public CardsFireProperty.RowData[] Table = null;

		public class RowData
		{

			public uint GroupId;

			public uint FireCounts;

			public SeqListRef<uint> Promote;

			public uint BreakLevel;
		}
	}
}
