using System;

namespace XUtliPoolLib
{

	public class FashionSuitTable : CVSReader
	{

		public FashionSuitTable.RowData GetBySuitID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FashionSuitTable.RowData result;
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
			FashionSuitTable.RowData rowData = new FashionSuitTable.RowData();
			base.Read<int>(reader, ref rowData.SuitID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SuitName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.SuitQuality, CVSReader.intParse);
			this.columnno = 2;
			base.ReadArray<uint>(reader, ref rowData.FashionID, CVSReader.uintParse);
			this.columnno = 4;
			rowData.Effect2.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			rowData.Effect3.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			rowData.Effect4.Read(reader, this.m_DataHandler);
			this.columnno = 7;
			rowData.Effect5.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			rowData.Effect6.Read(reader, this.m_DataHandler);
			this.columnno = 9;
			rowData.Effect7.Read(reader, this.m_DataHandler);
			this.columnno = 10;
			rowData.All1.Read(reader, this.m_DataHandler);
			this.columnno = 11;
			rowData.All2.Read(reader, this.m_DataHandler);
			this.columnno = 12;
			rowData.All3.Read(reader, this.m_DataHandler);
			this.columnno = 13;
			rowData.All4.Read(reader, this.m_DataHandler);
			this.columnno = 14;
			base.Read<bool>(reader, ref rowData.NoSale, CVSReader.boolParse);
			this.columnno = 21;
			base.Read<int>(reader, ref rowData.ShowLevel, CVSReader.intParse);
			this.columnno = 22;
			base.Read<int>(reader, ref rowData.OverAll, CVSReader.intParse);
			this.columnno = 23;
			base.Read<int>(reader, ref rowData.CraftedItemQuality, CVSReader.intParse);
			this.columnno = 24;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FashionSuitTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FashionSuitTable.RowData[] Table = null;

		public class RowData
		{

			public int SuitID;

			public string SuitName;

			public int SuitQuality;

			public uint[] FashionID;

			public SeqListRef<uint> Effect2;

			public SeqListRef<uint> Effect3;

			public SeqListRef<uint> Effect4;

			public SeqListRef<uint> Effect5;

			public SeqListRef<uint> Effect6;

			public SeqListRef<uint> Effect7;

			public SeqListRef<uint> All1;

			public SeqListRef<uint> All2;

			public SeqListRef<uint> All3;

			public SeqListRef<uint> All4;

			public bool NoSale;

			public int ShowLevel;

			public int OverAll;

			public int CraftedItemQuality;
		}
	}
}
