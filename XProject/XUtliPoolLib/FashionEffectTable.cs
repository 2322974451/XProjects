using System;

namespace XUtliPoolLib
{

	public class FashionEffectTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			FashionEffectTable.RowData rowData = new FashionEffectTable.RowData();
			base.Read<uint>(reader, ref rowData.Quality, CVSReader.uintParse);
			this.columnno = 0;
			rowData.Effect2.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.Effect3.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			rowData.Effect4.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			rowData.Effect5.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.Effect6.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			rowData.Effect7.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			base.Read<bool>(reader, ref rowData.IsThreeSuit, CVSReader.boolParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FashionEffectTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FashionEffectTable.RowData[] Table = null;

		public class RowData
		{

			public uint Quality;

			public SeqListRef<uint> Effect2;

			public SeqListRef<uint> Effect3;

			public SeqListRef<uint> Effect4;

			public SeqListRef<uint> Effect5;

			public SeqListRef<uint> Effect6;

			public SeqListRef<uint> Effect7;

			public bool IsThreeSuit;
		}
	}
}
