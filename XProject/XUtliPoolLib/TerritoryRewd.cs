using System;

namespace XUtliPoolLib
{
	// Token: 0x0200025D RID: 605
	public class TerritoryRewd : CVSReader
	{
		// Token: 0x06000D12 RID: 3346 RVA: 0x00044F48 File Offset: 0x00043148
		protected override void ReadLine(XBinaryReader reader)
		{
			TerritoryRewd.RowData rowData = new TerritoryRewd.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Point, CVSReader.intParse);
			this.columnno = 1;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x00044FC0 File Offset: 0x000431C0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new TerritoryRewd.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007AB RID: 1963
		public TerritoryRewd.RowData[] Table = null;

		// Token: 0x020003EC RID: 1004
		public class RowData
		{
			// Token: 0x040011CF RID: 4559
			public int ID;

			// Token: 0x040011D0 RID: 4560
			public int Point;

			// Token: 0x040011D1 RID: 4561
			public SeqListRef<uint> Reward;
		}
	}
}
