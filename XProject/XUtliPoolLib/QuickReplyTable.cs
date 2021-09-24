using System;

namespace XUtliPoolLib
{

	public class QuickReplyTable : CVSReader
	{

		public QuickReplyTable.RowData GetByID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			QuickReplyTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ID == key;
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
			QuickReplyTable.RowData rowData = new QuickReplyTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Content, CVSReader.stringParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new QuickReplyTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public QuickReplyTable.RowData[] Table = null;

		public class RowData
		{

			public int ID;

			public int Type;

			public string Content;
		}
	}
}
