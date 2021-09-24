using System;

namespace XUtliPoolLib
{

	public class FlowerSendNoticeTable : CVSReader
	{

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

		public FlowerSendNoticeTable.RowData[] Table = null;

		public class RowData
		{

			public int ItemID;

			public int Num;

			public string ThanksWords;
		}
	}
}
