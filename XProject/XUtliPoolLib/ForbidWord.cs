using System;

namespace XUtliPoolLib
{

	public class ForbidWord : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			ForbidWord.RowData rowData = new ForbidWord.RowData();
			base.Read<string>(reader, ref rowData.forbidword, CVSReader.stringParse);
			this.columnno = 0;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ForbidWord.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ForbidWord.RowData[] Table = null;

		public class RowData
		{

			public string forbidword;
		}
	}
}
