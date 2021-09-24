using System;

namespace XUtliPoolLib
{

	public class PetMoodTipsTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			PetMoodTipsTable.RowData rowData = new PetMoodTipsTable.RowData();
			base.Read<int>(reader, ref rowData.value, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.tip, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.tips, CVSReader.stringParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PetMoodTipsTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PetMoodTipsTable.RowData[] Table = null;

		public class RowData
		{

			public int value;

			public string tip;

			public string icon;

			public string tips;
		}
	}
}
