using System;

namespace XUtliPoolLib
{

	public class PayWelfareTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			PayWelfareTable.RowData rowData = new PayWelfareTable.RowData();
			base.Read<int>(reader, ref rowData.SysID, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.TabName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.TabIcon, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PayWelfareTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PayWelfareTable.RowData[] Table = null;

		public class RowData
		{

			public int SysID;

			public string TabName;

			public string TabIcon;
		}
	}
}
