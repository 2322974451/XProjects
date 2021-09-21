using System;

namespace XUtliPoolLib
{
	// Token: 0x020000EA RID: 234
	public class FashionComposeTable : CVSReader
	{
		// Token: 0x06000628 RID: 1576 RVA: 0x0001DA5C File Offset: 0x0001BC5C
		protected override void ReadLine(XBinaryReader reader)
		{
			FashionComposeTable.RowData rowData = new FashionComposeTable.RowData();
			base.Read<int>(reader, ref rowData.FashionID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.FashionLevel, CVSReader.intParse);
			this.columnno = 1;
			rowData.Attributes.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x0001DAD4 File Offset: 0x0001BCD4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FashionComposeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000336 RID: 822
		public FashionComposeTable.RowData[] Table = null;

		// Token: 0x020002E9 RID: 745
		public class RowData
		{
			// Token: 0x04000A9C RID: 2716
			public int FashionID;

			// Token: 0x04000A9D RID: 2717
			public int FashionLevel;

			// Token: 0x04000A9E RID: 2718
			public SeqListRef<uint> Attributes;
		}
	}
}
