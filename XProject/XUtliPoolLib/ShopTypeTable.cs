using System;

namespace XUtliPoolLib
{

	public class ShopTypeTable : CVSReader
	{

		public ShopTypeTable.RowData GetByShopID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ShopTypeTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ShopID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		public ShopTypeTable.RowData GetBySystemId(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ShopTypeTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SystemId == key;
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
			ShopTypeTable.RowData rowData = new ShopTypeTable.RowData();
			base.Read<uint>(reader, ref rowData.ShopID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.ShopIcon, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.ShopLevel, CVSReader.uintParse);
			this.columnno = 2;
			rowData.RefreshCost.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.ReadArray<uint>(reader, ref rowData.ShopCycle, CVSReader.uintParse);
			this.columnno = 4;
			rowData.ShopOpen.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.ShopName, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.SystemId, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.IsHasTab, CVSReader.intParse);
			this.columnno = 8;
			rowData.RefreshCount.Read(reader, this.m_DataHandler);
			this.columnno = 9;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ShopTypeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ShopTypeTable.RowData[] Table = null;

		public class RowData
		{

			public uint ShopID;

			public string ShopIcon;

			public uint ShopLevel;

			public SeqListRef<uint> RefreshCost;

			public uint[] ShopCycle;

			public SeqListRef<uint> ShopOpen;

			public string ShopName;

			public uint SystemId;

			public int IsHasTab;

			public SeqRef<uint> RefreshCount;
		}
	}
}
