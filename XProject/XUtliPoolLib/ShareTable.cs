using System;

namespace XUtliPoolLib
{

	public class ShareTable : CVSReader
	{

		public ShareTable.RowData GetByCondition(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ShareTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].Condition == key;
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
			ShareTable.RowData rowData = new ShareTable.RowData();
			base.Read<int>(reader, ref rowData.Condition, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Title, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Link, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.type, CVSReader.uintParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ShareTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ShareTable.RowData[] Table = null;

		public class RowData
		{

			public int Condition;

			public string Desc;

			public string Title;

			public string Icon;

			public string Link;

			public uint type;
		}
	}
}
