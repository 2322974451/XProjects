using System;

namespace XUtliPoolLib
{

	public class GuildRelaxGameList : CVSReader
	{

		public GuildRelaxGameList.RowData GetByModuleID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildRelaxGameList.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ModuleID == key;
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
			GuildRelaxGameList.RowData rowData = new GuildRelaxGameList.RowData();
			base.Read<string>(reader, ref rowData.GameBg, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.GameName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.ModuleID, CVSReader.intParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildRelaxGameList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildRelaxGameList.RowData[] Table = null;

		public class RowData
		{

			public string GameBg;

			public string GameName;

			public int ModuleID;
		}
	}
}
