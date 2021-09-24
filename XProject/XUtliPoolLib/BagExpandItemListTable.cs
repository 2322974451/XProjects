using System;

namespace XUtliPoolLib
{

	public class BagExpandItemListTable : CVSReader
	{

		public BagExpandItemListTable.RowData GetByItemId(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			BagExpandItemListTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ItemId == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		public BagExpandItemListTable.RowData GetByType(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			BagExpandItemListTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].Type == key;
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
			BagExpandItemListTable.RowData rowData = new BagExpandItemListTable.RowData();
			base.Read<uint>(reader, ref rowData.ItemId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 1;
			rowData.NeedAndOpen.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new BagExpandItemListTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public BagExpandItemListTable.RowData[] Table = null;

		public class RowData
		{

			public uint ItemId;

			public uint Type;

			public SeqListRef<uint> NeedAndOpen;
		}
	}
}
