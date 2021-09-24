using System;

namespace XUtliPoolLib
{

	public class SkillCombo : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			SkillCombo.RowData rowData = new SkillCombo.RowData();
			base.Read<string>(reader, ref rowData.skillname, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.nextskill0, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.nextskill1, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.nextskill2, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.nextskill3, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.nextskill4, CVSReader.stringParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SkillCombo.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public SkillCombo.RowData[] Table = null;

		public class RowData
		{

			public string skillname;

			public string nextskill0;

			public string nextskill1;

			public string nextskill2;

			public string nextskill3;

			public string nextskill4;
		}
	}
}
