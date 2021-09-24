using System;

namespace XUtliPoolLib
{

	public class TerritoryBattle : CVSReader
	{

		public TerritoryBattle.RowData GetByID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			TerritoryBattle.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ID == key;
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
			TerritoryBattle.RowData rowData = new TerritoryBattle.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.territoryname, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.territorylevel, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.territorylevelname, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.territoryIcon, CVSReader.stringParse);
			this.columnno = 4;
			base.ReadArray<uint>(reader, ref rowData.territoryLeagues, CVSReader.uintParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new TerritoryBattle.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public TerritoryBattle.RowData[] Table = null;

		public class RowData
		{

			public uint ID;

			public string territoryname;

			public uint territorylevel;

			public string territorylevelname;

			public string territoryIcon;

			public uint[] territoryLeagues;
		}
	}
}
