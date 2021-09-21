using System;

namespace XUtliPoolLib
{
	// Token: 0x020000BB RID: 187
	public class BuyFatigueTable : CVSReader
	{
		// Token: 0x0600055F RID: 1375 RVA: 0x00018380 File Offset: 0x00016580
		protected override void ReadLine(XBinaryReader reader)
		{
			BuyFatigueTable.RowData rowData = new BuyFatigueTable.RowData();
			base.Read<int>(reader, ref rowData.FatigueID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Value, CVSReader.intParse);
			this.columnno = 1;
			base.ReadArray<int>(reader, ref rowData.DragonCoinCost, CVSReader.intParse);
			this.columnno = 2;
			base.ReadArray<int>(reader, ref rowData.DiamondCost, CVSReader.intParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x00018414 File Offset: 0x00016614
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new BuyFatigueTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002E1 RID: 737
		public BuyFatigueTable.RowData[] Table = null;

		// Token: 0x020002B9 RID: 697
		public class RowData
		{
			// Token: 0x04000957 RID: 2391
			public int FatigueID;

			// Token: 0x04000958 RID: 2392
			public int Value;

			// Token: 0x04000959 RID: 2393
			public int[] DragonCoinCost;

			// Token: 0x0400095A RID: 2394
			public int[] DiamondCost;
		}
	}
}
