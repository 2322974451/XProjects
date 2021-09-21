using System;

namespace XUtliPoolLib
{
	// Token: 0x0200016A RID: 362
	public class SkillCombo : CVSReader
	{
		// Token: 0x06000805 RID: 2053 RVA: 0x00029650 File Offset: 0x00027850
		protected override void ReadLine(XBinaryReader reader)
		{
			SkillCombo.RowData rowData = new SkillCombo.RowData();
			base.Read<string>(reader, ref rowData.skillname, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.nextskill0, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.nextskill1, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.nextskill2, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.nextskill3, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.nextskill4, CVSReader.stringParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x00029718 File Offset: 0x00027918
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SkillCombo.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003B6 RID: 950
		public SkillCombo.RowData[] Table = null;

		// Token: 0x02000369 RID: 873
		public class RowData
		{
			// Token: 0x04000E10 RID: 3600
			public string skillname;

			// Token: 0x04000E11 RID: 3601
			public string nextskill0;

			// Token: 0x04000E12 RID: 3602
			public string nextskill1;

			// Token: 0x04000E13 RID: 3603
			public string nextskill2;

			// Token: 0x04000E14 RID: 3604
			public string nextskill3;

			// Token: 0x04000E15 RID: 3605
			public string nextskill4;
		}
	}
}
