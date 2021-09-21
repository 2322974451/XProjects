using System;

namespace XUtliPoolLib
{
	// Token: 0x02000183 RID: 387
	public class XChapter : CVSReader
	{
		// Token: 0x06000862 RID: 2146 RVA: 0x0002C338 File Offset: 0x0002A538
		public XChapter.RowData GetByChapterID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			XChapter.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ChapterID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x0002C3A4 File Offset: 0x0002A5A4
		protected override void ReadLine(XBinaryReader reader)
		{
			XChapter.RowData rowData = new XChapter.RowData();
			base.Read<int>(reader, ref rowData.ChapterID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Comment, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Pic, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.PreChapter, CVSReader.intParse);
			this.columnno = 7;
			rowData.Drop.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			rowData.Difficult.Read(reader, this.m_DataHandler);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.BossID, CVSReader.intParse);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x0002C4A0 File Offset: 0x0002A6A0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new XChapter.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003CF RID: 975
		public XChapter.RowData[] Table = null;

		// Token: 0x02000382 RID: 898
		public class RowData
		{
			// Token: 0x04000F0A RID: 3850
			public int ChapterID;

			// Token: 0x04000F0B RID: 3851
			public string Comment;

			// Token: 0x04000F0C RID: 3852
			public int Type;

			// Token: 0x04000F0D RID: 3853
			public string Pic;

			// Token: 0x04000F0E RID: 3854
			public int PreChapter;

			// Token: 0x04000F0F RID: 3855
			public SeqListRef<int> Drop;

			// Token: 0x04000F10 RID: 3856
			public SeqRef<int> Difficult;

			// Token: 0x04000F11 RID: 3857
			public int BossID;
		}
	}
}
