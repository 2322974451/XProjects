using System;

namespace XUtliPoolLib
{
	// Token: 0x02000163 RID: 355
	public class RecommendFightNum : CVSReader
	{
		// Token: 0x060007E7 RID: 2023 RVA: 0x00028148 File Offset: 0x00026348
		protected override void ReadLine(XBinaryReader reader)
		{
			RecommendFightNum.RowData rowData = new RecommendFightNum.RowData();
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.SystemID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.Total, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.Point, CVSReader.uintParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x000281DC File Offset: 0x000263DC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new RecommendFightNum.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003AF RID: 943
		public RecommendFightNum.RowData[] Table = null;

		// Token: 0x02000362 RID: 866
		public class RowData
		{
			// Token: 0x04000D8B RID: 3467
			public uint Level;

			// Token: 0x04000D8C RID: 3468
			public uint SystemID;

			// Token: 0x04000D8D RID: 3469
			public uint Total;

			// Token: 0x04000D8E RID: 3470
			public uint Point;
		}
	}
}
