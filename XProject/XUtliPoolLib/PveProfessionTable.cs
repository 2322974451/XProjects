using System;

namespace XUtliPoolLib
{
	// Token: 0x02000157 RID: 343
	public class PveProfessionTable : CVSReader
	{
		// Token: 0x060007BA RID: 1978 RVA: 0x00027350 File Offset: 0x00025550
		protected override void ReadLine(XBinaryReader reader)
		{
			PveProfessionTable.RowData rowData = new PveProfessionTable.RowData();
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<short>(reader, ref rowData.ProfessionID, CVSReader.shortParse);
			this.columnno = 14;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x000273B0 File Offset: 0x000255B0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PveProfessionTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003A3 RID: 931
		public PveProfessionTable.RowData[] Table = null;

		// Token: 0x02000356 RID: 854
		public class RowData
		{
			// Token: 0x04000D5D RID: 3421
			public uint SceneID;

			// Token: 0x04000D5E RID: 3422
			public short ProfessionID;
		}
	}
}
