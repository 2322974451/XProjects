using System;

namespace XUtliPoolLib
{
	// Token: 0x020000B4 RID: 180
	public class AuctionTypeList : CVSReader
	{
		// Token: 0x06000543 RID: 1347 RVA: 0x0001749C File Offset: 0x0001569C
		protected override void ReadLine(XBinaryReader reader)
		{
			AuctionTypeList.RowData rowData = new AuctionTypeList.RowData();
			base.Read<int>(reader, ref rowData.id, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.pretype, CVSReader.intParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x00017514 File Offset: 0x00015714
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new AuctionTypeList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002DA RID: 730
		public AuctionTypeList.RowData[] Table = null;

		// Token: 0x020002B2 RID: 690
		public class RowData
		{
			// Token: 0x04000907 RID: 2311
			public int id;

			// Token: 0x04000908 RID: 2312
			public string name;

			// Token: 0x04000909 RID: 2313
			public int pretype;
		}
	}
}
