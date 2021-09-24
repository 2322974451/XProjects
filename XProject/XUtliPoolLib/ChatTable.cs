using System;

namespace XUtliPoolLib
{

	public class ChatTable : CVSReader
	{

		public ChatTable.RowData GetByid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ChatTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].id == key;
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
			ChatTable.RowData rowData = new ChatTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.length, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.sprName, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.miniSpr, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 8;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ChatTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ChatTable.RowData[] Table = null;

		public class RowData
		{

			public uint id;

			public uint level;

			public uint length;

			public string sprName;

			public string miniSpr;

			public string name;
		}
	}
}
