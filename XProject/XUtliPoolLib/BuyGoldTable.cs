using System;

namespace XUtliPoolLib
{
	// Token: 0x020000BC RID: 188
	public class BuyGoldTable : CVSReader
	{
		// Token: 0x06000562 RID: 1378 RVA: 0x00018454 File Offset: 0x00016654
		protected override void ReadLine(XBinaryReader reader)
		{
			BuyGoldTable.RowData rowData = new BuyGoldTable.RowData();
			base.Read<long>(reader, ref rowData.Gold, CVSReader.longParse);
			this.columnno = 1;
			base.ReadArray<int>(reader, ref rowData.DragonCoinCost, CVSReader.intParse);
			this.columnno = 2;
			base.ReadArray<int>(reader, ref rowData.DiamondCost, CVSReader.intParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x000184CC File Offset: 0x000166CC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new BuyGoldTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002E2 RID: 738
		public BuyGoldTable.RowData[] Table = null;

		// Token: 0x020002BA RID: 698
		public class RowData
		{
			// Token: 0x0400095B RID: 2395
			public long Gold;

			// Token: 0x0400095C RID: 2396
			public int[] DragonCoinCost;

			// Token: 0x0400095D RID: 2397
			public int[] DiamondCost;
		}
	}
}
