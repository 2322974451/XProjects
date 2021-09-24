using System;

namespace XUtliPoolLib
{

	public class PayCardTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			PayCardTable.RowData rowData = new PayCardTable.RowData();
			base.Read<string>(reader, ref rowData.ParamID, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Price, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Diamond, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.DayAward, CVSReader.intParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.ServiceCode, CVSReader.stringParse);
			this.columnno = 9;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PayCardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PayCardTable.RowData[] Table = null;

		public class RowData
		{

			public string ParamID;

			public int Price;

			public int Diamond;

			public int Type;

			public int DayAward;

			public string Name;

			public string Icon;

			public string ServiceCode;
		}
	}
}
