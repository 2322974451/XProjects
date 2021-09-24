using System;

namespace XUtliPoolLib
{

	public class DragonGuildIntroduce : CVSReader
	{

		public DragonGuildIntroduce.RowData GetByHelpName(string key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			DragonGuildIntroduce.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].HelpName == key;
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
			DragonGuildIntroduce.RowData rowData = new DragonGuildIntroduce.RowData();
			base.Read<string>(reader, ref rowData.HelpName, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Logo, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Title, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DragonGuildIntroduce.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public DragonGuildIntroduce.RowData[] Table = null;

		public class RowData
		{

			public string HelpName;

			public string Logo;

			public string Title;

			public string Desc;
		}
	}
}
