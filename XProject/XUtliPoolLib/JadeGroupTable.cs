using System;

namespace XUtliPoolLib
{
	// Token: 0x02000272 RID: 626
	public class JadeGroupTable : CVSReader
	{
		// Token: 0x06000D58 RID: 3416 RVA: 0x000467F0 File Offset: 0x000449F0
		protected override void ReadLine(XBinaryReader reader)
		{
			JadeGroupTable.RowData rowData = new JadeGroupTable.RowData();
			base.Read<uint>(reader, ref rowData.JadeID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.GroupID, CVSReader.uintParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D59 RID: 3417 RVA: 0x00046850 File Offset: 0x00044A50
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new JadeGroupTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007C0 RID: 1984
		public JadeGroupTable.RowData[] Table = null;

		// Token: 0x02000401 RID: 1025
		public class RowData
		{
			// Token: 0x0400124C RID: 4684
			public uint JadeID;

			// Token: 0x0400124D RID: 4685
			public uint GroupID;
		}
	}
}
