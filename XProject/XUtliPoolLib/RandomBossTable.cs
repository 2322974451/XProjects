using System;

namespace XUtliPoolLib
{
	// Token: 0x0200015E RID: 350
	public class RandomBossTable : CVSReader
	{
		// Token: 0x060007D5 RID: 2005 RVA: 0x00027BA8 File Offset: 0x00025DA8
		protected override void ReadLine(XBinaryReader reader)
		{
			RandomBossTable.RowData rowData = new RandomBossTable.RowData();
			base.Read<int>(reader, ref rowData.RandomID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.EntityID, CVSReader.intParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x00027C08 File Offset: 0x00025E08
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new RandomBossTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003AA RID: 938
		public RandomBossTable.RowData[] Table = null;

		// Token: 0x0200035D RID: 861
		public class RowData
		{
			// Token: 0x04000D77 RID: 3447
			public int RandomID;

			// Token: 0x04000D78 RID: 3448
			public int EntityID;
		}
	}
}
