using System;

namespace XUtliPoolLib
{
	// Token: 0x02000131 RID: 305
	public class OperationRecord : CVSReader
	{
		// Token: 0x06000736 RID: 1846 RVA: 0x00024260 File Offset: 0x00022460
		protected override void ReadLine(XBinaryReader reader)
		{
			OperationRecord.RowData rowData = new OperationRecord.RowData();
			base.Read<string>(reader, ref rowData.WindowName, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.RecordID, CVSReader.uintParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x000242C0 File Offset: 0x000224C0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new OperationRecord.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400037D RID: 893
		public OperationRecord.RowData[] Table = null;

		// Token: 0x02000330 RID: 816
		public class RowData
		{
			// Token: 0x04000C6A RID: 3178
			public string WindowName;

			// Token: 0x04000C6B RID: 3179
			public uint RecordID;
		}
	}
}
