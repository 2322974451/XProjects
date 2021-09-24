using System;

namespace XUtliPoolLib
{

	public class ItemComposeTable : CVSReader
	{

		public ItemComposeTable.RowData GetByID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ItemComposeTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchID(key);
			}
			return result;
		}

		private ItemComposeTable.RowData BinarySearchID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			ItemComposeTable.RowData rowData;
			ItemComposeTable.RowData rowData2;
			ItemComposeTable.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.ID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.ID == key;
				if (flag2)
				{
					goto Block_2;
				}
				bool flag3 = num2 - num <= 1;
				if (flag3)
				{
					goto Block_3;
				}
				int num3 = num + (num2 - num) / 2;
				rowData3 = this.Table[num3];
				bool flag4 = rowData3.ID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.ID.CompareTo(key) < 0;
					if (!flag5)
					{
						goto IL_B1;
					}
					num = num3;
				}
				if (num >= num2)
				{
					goto Block_6;
				}
			}
			return rowData;
			Block_2:
			return rowData2;
			Block_3:
			return null;
			IL_B1:
			return rowData3;
			Block_6:
			return null;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			ItemComposeTable.RowData rowData = new ItemComposeTable.RowData();
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 0;
			rowData.SrcItem1.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.SrcItem2.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			rowData.SrcItem3.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.Coin, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.Level, CVSReader.intParse);
			this.columnno = 6;
			base.Read<bool>(reader, ref rowData.IsBind, CVSReader.boolParse);
			this.columnno = 7;
			rowData.SrcItem4.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 9;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ItemComposeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ItemComposeTable.RowData[] Table = null;

		public class RowData
		{

			public int ItemID;

			public SeqRef<int> SrcItem1;

			public SeqRef<int> SrcItem2;

			public SeqRef<int> SrcItem3;

			public int ID;

			public int Coin;

			public int Level;

			public bool IsBind;

			public SeqRef<int> SrcItem4;

			public int Type;
		}
	}
}
