using System;

namespace XUtliPoolLib
{
	// Token: 0x020000BA RID: 186
	public class BuyDragonCoin : CVSReader
	{
		// Token: 0x0600055C RID: 1372 RVA: 0x000182E0 File Offset: 0x000164E0
		protected override void ReadLine(XBinaryReader reader)
		{
			BuyDragonCoin.RowData rowData = new BuyDragonCoin.RowData();
			base.Read<long>(reader, ref rowData.DragonCoin, CVSReader.longParse);
			this.columnno = 1;
			base.ReadArray<int>(reader, ref rowData.DiamondCost, CVSReader.intParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x00018340 File Offset: 0x00016540
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new BuyDragonCoin.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002E0 RID: 736
		public BuyDragonCoin.RowData[] Table = null;

		// Token: 0x020002B8 RID: 696
		public class RowData
		{
			// Token: 0x04000955 RID: 2389
			public long DragonCoin;

			// Token: 0x04000956 RID: 2390
			public int[] DiamondCost;
		}
	}
}
