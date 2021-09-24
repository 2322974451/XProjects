using System;

namespace XUtliPoolLib
{

	public class CardStoreTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			CardStoreTable.RowData rowData = new CardStoreTable.RowData();
			base.Read<string>(reader, ref rowData.words, CVSReader.stringParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

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

		public CardStoreTable.RowData[] Table = null;

		public class RowData
		{

			public string words;
		}
	}
}
