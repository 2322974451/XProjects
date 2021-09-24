using System;

namespace XUtliPoolLib
{

	public class OperatingActivity : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			OperatingActivity.RowData rowData = new OperatingActivity.RowData();
			base.Read<uint>(reader, ref rowData.OrderId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SysEnum, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.SysID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.TabName, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.TabIcon, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<bool>(reader, ref rowData.IsPandoraTab, CVSReader.boolParse);
			this.columnno = 5;
			base.ReadArray<string>(reader, ref rowData.OpenTime, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new OperatingActivity.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public OperatingActivity.RowData[] Table = null;

		public class RowData
		{

			public uint OrderId;

			public string SysEnum;

			public uint SysID;

			public string TabName;

			public string TabIcon;

			public bool IsPandoraTab;

			public string[] OpenTime;

			public uint Level;
		}
	}
}
