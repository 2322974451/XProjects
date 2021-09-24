using System;

namespace XUtliPoolLib
{

	public class Career : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			Career.RowData rowData = new Career.RowData();
			base.Read<int>(reader, ref rowData.SortId, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.TabName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new Career.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public Career.RowData[] Table = null;

		public class RowData
		{

			public int SortId;

			public string TabName;

			public int ID;
		}
	}
}
