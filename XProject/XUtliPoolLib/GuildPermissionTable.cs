using System;

namespace XUtliPoolLib
{

	public class GuildPermissionTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			GuildPermissionTable.RowData rowData = new GuildPermissionTable.RowData();
			base.Read<string>(reader, ref rowData.GuildID, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.GPOS_LEADER, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.GPOS_VICELEADER, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.GPOS_OFFICER, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.GPOS_ELITEMEMBER, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.GPOS_MEMBER, CVSReader.intParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildPermissionTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildPermissionTable.RowData[] Table = null;

		public class RowData
		{

			public string GuildID;

			public int GPOS_LEADER;

			public int GPOS_VICELEADER;

			public int GPOS_OFFICER;

			public int GPOS_ELITEMEMBER;

			public int GPOS_MEMBER;
		}
	}
}
