using System;

namespace XUtliPoolLib
{
	// Token: 0x02000273 RID: 627
	public class FestivityLoveTable : CVSReader
	{
		// Token: 0x06000D5B RID: 3419 RVA: 0x00046890 File Offset: 0x00044A90
		protected override void ReadLine(XBinaryReader reader)
		{
			FestivityLoveTable.RowData rowData = new FestivityLoveTable.RowData();
			base.Read<uint>(reader, ref rowData.LoveScore, CVSReader.uintParse);
			this.columnno = 0;
			rowData.LoveGift.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.GiftIcon, CVSReader.stringParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D5C RID: 3420 RVA: 0x00046908 File Offset: 0x00044B08
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FestivityLoveTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007C1 RID: 1985
		public FestivityLoveTable.RowData[] Table = null;

		// Token: 0x02000402 RID: 1026
		public class RowData
		{
			// Token: 0x0400124E RID: 4686
			public uint LoveScore;

			// Token: 0x0400124F RID: 4687
			public SeqListRef<uint> LoveGift;

			// Token: 0x04001250 RID: 4688
			public string GiftIcon;
		}
	}
}
