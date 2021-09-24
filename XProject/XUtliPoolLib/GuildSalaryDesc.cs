using System;

namespace XUtliPoolLib
{

	public class GuildSalaryDesc : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			GuildSalaryDesc.RowData rowData = new GuildSalaryDesc.RowData();
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Go, CVSReader.intParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.GoLabel, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildSalaryDesc.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildSalaryDesc.RowData[] Table = null;

		public class RowData
		{

			public int Type;

			public string Desc;

			public int Go;

			public string GoLabel;
		}
	}
}
