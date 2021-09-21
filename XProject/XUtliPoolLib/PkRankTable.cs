using System;

namespace XUtliPoolLib
{
	// Token: 0x02000149 RID: 329
	public class PkRankTable : CVSReader
	{
		// Token: 0x06000787 RID: 1927 RVA: 0x0002603C File Offset: 0x0002423C
		protected override void ReadLine(XBinaryReader reader)
		{
			PkRankTable.RowData rowData = new PkRankTable.RowData();
			rowData.rank.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x0002609C File Offset: 0x0002429C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PkRankTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000395 RID: 917
		public PkRankTable.RowData[] Table = null;

		// Token: 0x02000348 RID: 840
		public class RowData
		{
			// Token: 0x04000D06 RID: 3334
			public SeqRef<uint> rank;

			// Token: 0x04000D07 RID: 3335
			public SeqListRef<uint> reward;
		}
	}
}
