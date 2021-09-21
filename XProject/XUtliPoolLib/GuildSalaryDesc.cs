using System;

namespace XUtliPoolLib
{
	// Token: 0x02000116 RID: 278
	public class GuildSalaryDesc : CVSReader
	{
		// Token: 0x060006CA RID: 1738 RVA: 0x000212E4 File Offset: 0x0001F4E4
		protected override void ReadLine(XBinaryReader reader)
		{
			GuildSalaryDesc.RowData rowData = new GuildSalaryDesc.RowData();
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Go, CVSReader.intParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.GoLabel, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x00021378 File Offset: 0x0001F578
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildSalaryDesc.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000362 RID: 866
		public GuildSalaryDesc.RowData[] Table = null;

		// Token: 0x02000315 RID: 789
		public class RowData
		{
			// Token: 0x04000B89 RID: 2953
			public int Type;

			// Token: 0x04000B8A RID: 2954
			public string Desc;

			// Token: 0x04000B8B RID: 2955
			public int Go;

			// Token: 0x04000B8C RID: 2956
			public string GoLabel;
		}
	}
}
