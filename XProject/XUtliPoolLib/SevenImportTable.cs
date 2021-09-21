using System;

namespace XUtliPoolLib
{
	// Token: 0x02000167 RID: 359
	public class SevenImportTable : CVSReader
	{
		// Token: 0x060007F7 RID: 2039 RVA: 0x00028F70 File Offset: 0x00027170
		public SevenImportTable.RowData GetByID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			SevenImportTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x00028FDC File Offset: 0x000271DC
		protected override void ReadLine(XBinaryReader reader)
		{
			SevenImportTable.RowData rowData = new SevenImportTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.SharedTexture, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.SharedIcon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.DialogSharedTexture, CVSReader.stringParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x00029088 File Offset: 0x00027288
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SevenImportTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003B3 RID: 947
		public SevenImportTable.RowData[] Table = null;

		// Token: 0x02000366 RID: 870
		public class RowData
		{
			// Token: 0x04000DF0 RID: 3568
			public int ID;

			// Token: 0x04000DF1 RID: 3569
			public int ItemID;

			// Token: 0x04000DF2 RID: 3570
			public string SharedTexture;

			// Token: 0x04000DF3 RID: 3571
			public string SharedIcon;

			// Token: 0x04000DF4 RID: 3572
			public string DialogSharedTexture;
		}
	}
}
