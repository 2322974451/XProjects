using System;

namespace XUtliPoolLib
{

	public class Guildintroduce : CVSReader
	{

		public Guildintroduce.RowData GetByHelpName(string key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			Guildintroduce.RowData result;
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
			Guildintroduce.RowData rowData = new Guildintroduce.RowData();
			base.Read<string>(reader, ref rowData.HelpName, CVSReader.stringParse);
			this.columnno = 0;
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
				this.Table = new Guildintroduce.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public Guildintroduce.RowData[] Table = null;

		public class RowData
		{

			public string HelpName;

			public string Title;

			public string Desc;
		}
	}
}
