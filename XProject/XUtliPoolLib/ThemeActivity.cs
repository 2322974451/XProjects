using System;

namespace XUtliPoolLib
{

	public class ThemeActivity : CVSReader
	{

		public ThemeActivity.RowData GetBySysID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ThemeActivity.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SysID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			ThemeActivity.RowData rowData = new ThemeActivity.RowData();
			base.Read<uint>(reader, ref rowData.SysID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.TabName, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.TabIcon, CVSReader.stringParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ThemeActivity.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ThemeActivity.RowData[] Table = null;

		public class RowData
		{

			public uint SysID;

			public string TabName;

			public string TabIcon;
		}
	}
}
