using System;

namespace XUtliPoolLib
{
	// Token: 0x0200013D RID: 317
	public class PayWelfareTable : CVSReader
	{
		// Token: 0x0600075E RID: 1886 RVA: 0x00025348 File Offset: 0x00023548
		protected override void ReadLine(XBinaryReader reader)
		{
			PayWelfareTable.RowData rowData = new PayWelfareTable.RowData();
			base.Read<int>(reader, ref rowData.SysID, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.TabName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.TabIcon, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x000253C0 File Offset: 0x000235C0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PayWelfareTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000389 RID: 905
		public PayWelfareTable.RowData[] Table = null;

		// Token: 0x0200033C RID: 828
		public class RowData
		{
			// Token: 0x04000CCD RID: 3277
			public int SysID;

			// Token: 0x04000CCE RID: 3278
			public string TabName;

			// Token: 0x04000CCF RID: 3279
			public string TabIcon;
		}
	}
}
