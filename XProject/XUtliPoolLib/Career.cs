using System;

namespace XUtliPoolLib
{
	// Token: 0x0200021C RID: 540
	public class Career : CVSReader
	{
		// Token: 0x06000C23 RID: 3107 RVA: 0x0003FC20 File Offset: 0x0003DE20
		protected override void ReadLine(XBinaryReader reader)
		{
			Career.RowData rowData = new Career.RowData();
			base.Read<int>(reader, ref rowData.SortId, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.TabName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C24 RID: 3108 RVA: 0x0003FC98 File Offset: 0x0003DE98
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new Career.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400076A RID: 1898
		public Career.RowData[] Table = null;

		// Token: 0x020003AB RID: 939
		public class RowData
		{
			// Token: 0x04001070 RID: 4208
			public int SortId;

			// Token: 0x04001071 RID: 4209
			public string TabName;

			// Token: 0x04001072 RID: 4210
			public int ID;
		}
	}
}
