using System;

namespace XUtliPoolLib
{

	public class FashionCharm : CVSReader
	{

		public FashionCharm.RowData GetBySuitID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FashionCharm.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SuitID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			FashionCharm.RowData rowData = new FashionCharm.RowData();
			base.Read<uint>(reader, ref rowData.SuitID, CVSReader.uintParse);
			this.columnno = 0;
			rowData.Effect1.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.Effect2.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			rowData.Effect3.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			rowData.Effect4.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.Effect5.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			rowData.Effect6.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			rowData.Effect7.Read(reader, this.m_DataHandler);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 8;
			base.ReadArray<uint>(reader, ref rowData.SuitParam, CVSReader.uintParse);
			this.columnno = 9;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FashionCharm.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FashionCharm.RowData[] Table = null;

		public class RowData
		{

			public uint SuitID;

			public SeqListRef<uint> Effect1;

			public SeqListRef<uint> Effect2;

			public SeqListRef<uint> Effect3;

			public SeqListRef<uint> Effect4;

			public SeqListRef<uint> Effect5;

			public SeqListRef<uint> Effect6;

			public SeqListRef<uint> Effect7;

			public uint Level;

			public uint[] SuitParam;
		}
	}
}
