using System;

namespace XUtliPoolLib
{

	public class ActivityTable : CVSReader
	{

		public ActivityTable.RowData GetBysortid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ActivityTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].sortid == key;
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
			ActivityTable.RowData rowData = new ActivityTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.value, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.description, CVSReader.stringParse);
			this.columnno = 7;
			rowData.item.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.sortid, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.random, CVSReader.uintParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.title, CVSReader.stringParse);
			this.columnno = 11;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ActivityTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ActivityTable.RowData[] Table = null;

		public class RowData
		{

			public uint id;

			public uint value;

			public string name;

			public string icon;

			public string description;

			public SeqListRef<int> item;

			public uint sortid;

			public uint random;

			public string title;
		}
	}
}
