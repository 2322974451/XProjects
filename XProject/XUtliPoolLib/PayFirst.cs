using System;

namespace XUtliPoolLib
{
	// Token: 0x0200013A RID: 314
	public class PayFirst : CVSReader
	{
		// Token: 0x06000754 RID: 1876 RVA: 0x00024DA8 File Offset: 0x00022FA8
		protected override void ReadLine(XBinaryReader reader)
		{
			PayFirst.RowData rowData = new PayFirst.RowData();
			base.Read<int>(reader, ref rowData.Money, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Award, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.SystemID, CVSReader.intParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x00024E20 File Offset: 0x00023020
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PayFirst.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000386 RID: 902
		public PayFirst.RowData[] Table = null;

		// Token: 0x02000339 RID: 825
		public class RowData
		{
			// Token: 0x04000CA7 RID: 3239
			public int Money;

			// Token: 0x04000CA8 RID: 3240
			public int Award;

			// Token: 0x04000CA9 RID: 3241
			public int SystemID;
		}
	}
}
