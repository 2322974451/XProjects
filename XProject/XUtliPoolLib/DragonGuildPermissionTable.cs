using System;

namespace XUtliPoolLib
{

	public class DragonGuildPermissionTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			DragonGuildPermissionTable.RowData rowData = new DragonGuildPermissionTable.RowData();
			base.Read<string>(reader, ref rowData.DragonGuildID, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.DGPOS_LEADER, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.DGPOS_VIVELEADER, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.DGPOS_MEMBER, CVSReader.intParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DragonGuildPermissionTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public DragonGuildPermissionTable.RowData[] Table = null;

		public class RowData
		{

			public string DragonGuildID;

			public int DGPOS_LEADER;

			public int DGPOS_VIVELEADER;

			public int DGPOS_MEMBER;
		}
	}
}
