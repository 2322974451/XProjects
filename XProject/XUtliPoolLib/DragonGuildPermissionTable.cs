using System;

namespace XUtliPoolLib
{
	// Token: 0x020000DC RID: 220
	public class DragonGuildPermissionTable : CVSReader
	{
		// Token: 0x060005F4 RID: 1524 RVA: 0x0001C184 File Offset: 0x0001A384
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

		// Token: 0x060005F5 RID: 1525 RVA: 0x0001C218 File Offset: 0x0001A418
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

		// Token: 0x04000328 RID: 808
		public DragonGuildPermissionTable.RowData[] Table = null;

		// Token: 0x020002DB RID: 731
		public class RowData
		{
			// Token: 0x04000A16 RID: 2582
			public string DragonGuildID;

			// Token: 0x04000A17 RID: 2583
			public int DGPOS_LEADER;

			// Token: 0x04000A18 RID: 2584
			public int DGPOS_VIVELEADER;

			// Token: 0x04000A19 RID: 2585
			public int DGPOS_MEMBER;
		}
	}
}
