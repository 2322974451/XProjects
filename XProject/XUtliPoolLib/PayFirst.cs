using System;

namespace XUtliPoolLib
{

	public class PayFirst : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			PayFirst.RowData rowData = new PayFirst.RowData();
			base.Read<int>(reader, ref rowData.Money, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Award, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.SystemID, CVSReader.intParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PayFirst.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PayFirst.RowData[] Table = null;

		public class RowData
		{

			public int Money;

			public int Award;

			public int SystemID;
		}
	}
}
