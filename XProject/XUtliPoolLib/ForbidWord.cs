using System;

namespace XUtliPoolLib
{
	// Token: 0x020000F7 RID: 247
	public class ForbidWord : CVSReader
	{
		// Token: 0x06000655 RID: 1621 RVA: 0x0001EA68 File Offset: 0x0001CC68
		protected override void ReadLine(XBinaryReader reader)
		{
			ForbidWord.RowData rowData = new ForbidWord.RowData();
			base.Read<string>(reader, ref rowData.forbidword, CVSReader.stringParse);
			this.columnno = 0;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x0001EAAC File Offset: 0x0001CCAC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ForbidWord.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000343 RID: 835
		public ForbidWord.RowData[] Table = null;

		// Token: 0x020002F6 RID: 758
		public class RowData
		{
			// Token: 0x04000AE9 RID: 2793
			public string forbidword;
		}
	}
}
