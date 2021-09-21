using System;

namespace XUtliPoolLib
{
	// Token: 0x020000F5 RID: 245
	public class FlowerSendNoticeTable : CVSReader
	{
		// Token: 0x0600064F RID: 1615 RVA: 0x0001E910 File Offset: 0x0001CB10
		protected override void ReadLine(XBinaryReader reader)
		{
			FlowerSendNoticeTable.RowData rowData = new FlowerSendNoticeTable.RowData();
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Num, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.ThanksWords, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0001E988 File Offset: 0x0001CB88
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FlowerSendNoticeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000341 RID: 833
		public FlowerSendNoticeTable.RowData[] Table = null;

		// Token: 0x020002F4 RID: 756
		public class RowData
		{
			// Token: 0x04000AE4 RID: 2788
			public int ItemID;

			// Token: 0x04000AE5 RID: 2789
			public int Num;

			// Token: 0x04000AE6 RID: 2790
			public string ThanksWords;
		}
	}
}
