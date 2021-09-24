using System;

namespace XUtliPoolLib
{

	public class ItemBuffTable : CVSReader
	{

		public ItemBuffTable.RowData GetByItemId(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ItemBuffTable.RowData result;
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

		protected override void ReadLine(XBinaryReader reader)
		{
			ItemBuffTable.RowData rowData = new ItemBuffTable.RowData();
			base.Read<uint>(reader, ref rowData.ItemId, CVSReader.uintParse);
			this.columnno = 0;
			rowData.Buffs.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ItemBuffTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ItemBuffTable.RowData[] Table = null;

		public class RowData
		{

			public uint ItemId;

			public SeqListRef<uint> Buffs;

			public string Name;
		}
	}
}
