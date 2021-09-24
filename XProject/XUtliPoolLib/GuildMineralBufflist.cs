using System;

namespace XUtliPoolLib
{

	public class GuildMineralBufflist : CVSReader
	{

		public GuildMineralBufflist.RowData GetByBuffID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildMineralBufflist.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].BuffID == key;
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
			GuildMineralBufflist.RowData rowData = new GuildMineralBufflist.RowData();
			base.Read<uint>(reader, ref rowData.BuffID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.ratestring, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.Quality, CVSReader.uintParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildMineralBufflist.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildMineralBufflist.RowData[] Table = null;

		public class RowData
		{

			public uint BuffID;

			public string ratestring;

			public string icon;

			public uint Quality;
		}
	}
}
