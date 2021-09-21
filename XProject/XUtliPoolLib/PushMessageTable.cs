using System;

namespace XUtliPoolLib
{
	// Token: 0x02000153 RID: 339
	public class PushMessageTable : CVSReader
	{
		// Token: 0x060007AB RID: 1963 RVA: 0x00026E68 File Offset: 0x00025068
		protected override void ReadLine(XBinaryReader reader)
		{
			PushMessageTable.RowData rowData = new PushMessageTable.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Title, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Content, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.IsCommonGlobal, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadArray<uint>(reader, ref rowData.Time, CVSReader.uintParse);
			this.columnno = 6;
			base.ReadArray<uint>(reader, ref rowData.WeekDay, CVSReader.uintParse);
			this.columnno = 8;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x00026F30 File Offset: 0x00025130
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PushMessageTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400039F RID: 927
		public PushMessageTable.RowData[] Table = null;

		// Token: 0x02000352 RID: 850
		public class RowData
		{
			// Token: 0x04000D4C RID: 3404
			public uint Type;

			// Token: 0x04000D4D RID: 3405
			public string Title;

			// Token: 0x04000D4E RID: 3406
			public string Content;

			// Token: 0x04000D4F RID: 3407
			public uint IsCommonGlobal;

			// Token: 0x04000D50 RID: 3408
			public uint[] Time;

			// Token: 0x04000D51 RID: 3409
			public uint[] WeekDay;
		}
	}
}
