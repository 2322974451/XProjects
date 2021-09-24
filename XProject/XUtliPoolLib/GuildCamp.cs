using System;

namespace XUtliPoolLib
{

	public class GuildCamp : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			GuildCamp.RowData rowData = new GuildCamp.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Condition, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.RankDes, CVSReader.stringParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildCamp.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildCamp.RowData[] Table = null;

		public class RowData
		{

			public int ID;

			public string Name;

			public string Description;

			public string Condition;

			public int Type;

			public string RankDes;
		}
	}
}
