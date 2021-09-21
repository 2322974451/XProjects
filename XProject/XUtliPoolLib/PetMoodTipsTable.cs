using System;

namespace XUtliPoolLib
{
	// Token: 0x02000143 RID: 323
	public class PetMoodTipsTable : CVSReader
	{
		// Token: 0x06000773 RID: 1907 RVA: 0x00025AA8 File Offset: 0x00023CA8
		protected override void ReadLine(XBinaryReader reader)
		{
			PetMoodTipsTable.RowData rowData = new PetMoodTipsTable.RowData();
			base.Read<int>(reader, ref rowData.value, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.tip, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.tips, CVSReader.stringParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x00025B3C File Offset: 0x00023D3C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PetMoodTipsTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400038F RID: 911
		public PetMoodTipsTable.RowData[] Table = null;

		// Token: 0x02000342 RID: 834
		public class RowData
		{
			// Token: 0x04000CF0 RID: 3312
			public int value;

			// Token: 0x04000CF1 RID: 3313
			public string tip;

			// Token: 0x04000CF2 RID: 3314
			public string icon;

			// Token: 0x04000CF3 RID: 3315
			public string tips;
		}
	}
}
