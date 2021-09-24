using System;

namespace XUtliPoolLib
{

	public class RechargeTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			RechargeTable.RowData rowData = new RechargeTable.RowData();
			base.Read<string>(reader, ref rowData.ParamID, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Price, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Diamond, CVSReader.intParse);
			this.columnno = 2;
			rowData.RoleLevels.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			rowData.LoginDays.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.SystemID, CVSReader.intParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.ServiceCode, CVSReader.stringParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new RechargeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public RechargeTable.RowData[] Table = null;

		public class RowData
		{

			public string ParamID;

			public int Price;

			public int Diamond;

			public SeqListRef<int> RoleLevels;

			public SeqListRef<int> LoginDays;

			public int SystemID;

			public string Name;

			public string ServiceCode;
		}
	}
}
