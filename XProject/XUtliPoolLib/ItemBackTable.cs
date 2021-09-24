using System;

namespace XUtliPoolLib
{

	public class ItemBackTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			ItemBackTable.RowData rowData = new ItemBackTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SystemName, CVSReader.stringParse);
			this.columnno = 2;
			rowData.ItemGold.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.ItemDragonCoin.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.count, CVSReader.intParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.FindBackDays, CVSReader.intParse);
			this.columnno = 10;
			base.Read<bool>(reader, ref rowData.IsWeekBack, CVSReader.boolParse);
			this.columnno = 11;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ItemBackTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ItemBackTable.RowData[] Table = null;

		public class RowData
		{

			public int ID;

			public string SystemName;

			public SeqListRef<int> ItemGold;

			public SeqListRef<int> ItemDragonCoin;

			public int count;

			public string Desc;

			public int FindBackDays;

			public bool IsWeekBack;
		}
	}
}
