using System;

namespace XUtliPoolLib
{
	// Token: 0x0200015C RID: 348
	public class QuickReplyTable : CVSReader
	{
		// Token: 0x060007CE RID: 1998 RVA: 0x0002797C File Offset: 0x00025B7C
		public QuickReplyTable.RowData GetByID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			QuickReplyTable.RowData result;
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

		// Token: 0x060007CF RID: 1999 RVA: 0x000279E8 File Offset: 0x00025BE8
		protected override void ReadLine(XBinaryReader reader)
		{
			QuickReplyTable.RowData rowData = new QuickReplyTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Content, CVSReader.stringParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x00027A60 File Offset: 0x00025C60
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new QuickReplyTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003A8 RID: 936
		public QuickReplyTable.RowData[] Table = null;

		// Token: 0x0200035B RID: 859
		public class RowData
		{
			// Token: 0x04000D6E RID: 3438
			public int ID;

			// Token: 0x04000D6F RID: 3439
			public int Type;

			// Token: 0x04000D70 RID: 3440
			public string Content;
		}
	}
}
