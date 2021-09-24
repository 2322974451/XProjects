using System;

namespace XUtliPoolLib
{

	public class FpGoToLevelUp : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			FpGoToLevelUp.RowData rowData = new FpGoToLevelUp.RowData();
			base.Read<uint>(reader, ref rowData.Id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.SystemId, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Tips, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.IconName, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.StarNum, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.IsRecommond, CVSReader.uintParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FpGoToLevelUp.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FpGoToLevelUp.RowData[] Table = null;

		public class RowData
		{

			public uint Id;

			public string Name;

			public uint SystemId;

			public string Tips;

			public string IconName;

			public uint StarNum;

			public uint IsRecommond;
		}
	}
}
