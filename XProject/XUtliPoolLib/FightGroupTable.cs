using System;

namespace XUtliPoolLib
{

	public class FightGroupTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			FightGroupTable.RowData rowData = new FightGroupTable.RowData();
			base.Read<string>(reader, ref rowData.group, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.enemy, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.role, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.neutral, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.hostility, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.enemygod, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.rolegod, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.other, CVSReader.stringParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FightGroupTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FightGroupTable.RowData[] Table = null;

		public class RowData
		{

			public string group;

			public string enemy;

			public string role;

			public string neutral;

			public string hostility;

			public string enemygod;

			public string rolegod;

			public string other;
		}
	}
}
