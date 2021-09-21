using System;

namespace XUtliPoolLib
{
	// Token: 0x02000112 RID: 274
	public class GuildPermissionTable : CVSReader
	{
		// Token: 0x060006BC RID: 1724 RVA: 0x00020ED8 File Offset: 0x0001F0D8
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

		// Token: 0x060006BD RID: 1725 RVA: 0x00020FA0 File Offset: 0x0001F1A0
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

		// Token: 0x0400035E RID: 862
		public GuildPermissionTable.RowData[] Table = null;

		// Token: 0x02000311 RID: 785
		public class RowData
		{
			// Token: 0x04000B7A RID: 2938
			public string GuildID;

			// Token: 0x04000B7B RID: 2939
			public int GPOS_LEADER;

			// Token: 0x04000B7C RID: 2940
			public int GPOS_VICELEADER;

			// Token: 0x04000B7D RID: 2941
			public int GPOS_OFFICER;

			// Token: 0x04000B7E RID: 2942
			public int GPOS_ELITEMEMBER;

			// Token: 0x04000B7F RID: 2943
			public int GPOS_MEMBER;
		}
	}
}
