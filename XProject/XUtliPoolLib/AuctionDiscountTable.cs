using System;

namespace XUtliPoolLib
{
	// Token: 0x020000B3 RID: 179
	public class AuctionDiscountTable : CVSReader
	{
		// Token: 0x06000540 RID: 1344 RVA: 0x000173E4 File Offset: 0x000155E4
		protected override void ReadLine(XBinaryReader reader)
		{
			AuctionDiscountTable.RowData rowData = new AuctionDiscountTable.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Group, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<float>(reader, ref rowData.Discount, CVSReader.floatParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x0001745C File Offset: 0x0001565C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new AuctionDiscountTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002D9 RID: 729
		public AuctionDiscountTable.RowData[] Table = null;

		// Token: 0x020002B1 RID: 689
		public class RowData
		{
			// Token: 0x04000904 RID: 2308
			public uint Type;

			// Token: 0x04000905 RID: 2309
			public uint Group;

			// Token: 0x04000906 RID: 2310
			public float Discount;
		}
	}
}
