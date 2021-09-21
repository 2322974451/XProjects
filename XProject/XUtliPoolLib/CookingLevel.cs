using System;

namespace XUtliPoolLib
{
	// Token: 0x020000CA RID: 202
	public class CookingLevel : CVSReader
	{
		// Token: 0x06000593 RID: 1427 RVA: 0x0001969C File Offset: 0x0001789C
		protected override void ReadLine(XBinaryReader reader)
		{
			CookingLevel.RowData rowData = new CookingLevel.RowData();
			base.Read<uint>(reader, ref rowData.CookLevel, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Experiences, CVSReader.uintParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x000196FC File Offset: 0x000178FC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CookingLevel.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002F0 RID: 752
		public CookingLevel.RowData[] Table = null;

		// Token: 0x020002C8 RID: 712
		public class RowData
		{
			// Token: 0x040009B3 RID: 2483
			public uint CookLevel;

			// Token: 0x040009B4 RID: 2484
			public uint Experiences;
		}
	}
}
