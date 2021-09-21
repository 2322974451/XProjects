using System;

namespace XUtliPoolLib
{
	// Token: 0x020000C2 RID: 194
	public class CardStoreTable : CVSReader
	{
		// Token: 0x06000579 RID: 1401 RVA: 0x00018C94 File Offset: 0x00016E94
		protected override void ReadLine(XBinaryReader reader)
		{
			CardStoreTable.RowData rowData = new CardStoreTable.RowData();
			base.Read<string>(reader, ref rowData.words, CVSReader.stringParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x00018CD8 File Offset: 0x00016ED8
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CardStoreTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002E8 RID: 744
		public CardStoreTable.RowData[] Table = null;

		// Token: 0x020002C0 RID: 704
		public class RowData
		{
			// Token: 0x0400097A RID: 2426
			public string words;
		}
	}
}
