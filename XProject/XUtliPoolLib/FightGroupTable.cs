using System;

namespace XUtliPoolLib
{
	// Token: 0x020000EF RID: 239
	public class FightGroupTable : CVSReader
	{
		// Token: 0x0600063B RID: 1595 RVA: 0x0001E278 File Offset: 0x0001C478
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

		// Token: 0x0600063C RID: 1596 RVA: 0x0001E374 File Offset: 0x0001C574
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

		// Token: 0x0400033B RID: 827
		public FightGroupTable.RowData[] Table = null;

		// Token: 0x020002EE RID: 750
		public class RowData
		{
			// Token: 0x04000AC4 RID: 2756
			public string group;

			// Token: 0x04000AC5 RID: 2757
			public string enemy;

			// Token: 0x04000AC6 RID: 2758
			public string role;

			// Token: 0x04000AC7 RID: 2759
			public string neutral;

			// Token: 0x04000AC8 RID: 2760
			public string hostility;

			// Token: 0x04000AC9 RID: 2761
			public string enemygod;

			// Token: 0x04000ACA RID: 2762
			public string rolegod;

			// Token: 0x04000ACB RID: 2763
			public string other;
		}
	}
}
