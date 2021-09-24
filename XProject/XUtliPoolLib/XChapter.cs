using System;

namespace XUtliPoolLib
{

	public class XChapter : CVSReader
	{

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

		public XChapter.RowData[] Table = null;

		public class RowData
		{

			public int ChapterID;

			public string Comment;

			public int Type;

			public string Pic;

			public int PreChapter;

			public SeqListRef<int> Drop;

			public SeqRef<int> Difficult;

			public int BossID;
		}
	}
}
