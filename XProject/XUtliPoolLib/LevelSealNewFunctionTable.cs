using System;

namespace XUtliPoolLib
{

	public class LevelSealNewFunctionTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			LevelSealNewFunctionTable.RowData rowData = new LevelSealNewFunctionTable.RowData();
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.OpenLevel, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Tag, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.IconName, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new LevelSealNewFunctionTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public LevelSealNewFunctionTable.RowData[] Table = null;

		public class RowData
		{

			public int Type;

			public int OpenLevel;

			public string Tag;

			public string IconName;
		}
	}
}
