using System;

namespace XUtliPoolLib
{
	// Token: 0x0200017E RID: 382
	public class TerritoryBattle : CVSReader
	{
		// Token: 0x06000851 RID: 2129 RVA: 0x0002BC2C File Offset: 0x00029E2C
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

		// Token: 0x06000852 RID: 2130 RVA: 0x0002BC98 File Offset: 0x00029E98
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

		// Token: 0x06000853 RID: 2131 RVA: 0x0002BD60 File Offset: 0x00029F60
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

		// Token: 0x040003CA RID: 970
		public TerritoryBattle.RowData[] Table = null;

		// Token: 0x0200037D RID: 893
		public class RowData
		{
			// Token: 0x04000EE2 RID: 3810
			public uint ID;

			// Token: 0x04000EE3 RID: 3811
			public string territoryname;

			// Token: 0x04000EE4 RID: 3812
			public uint territorylevel;

			// Token: 0x04000EE5 RID: 3813
			public string territorylevelname;

			// Token: 0x04000EE6 RID: 3814
			public string territoryIcon;

			// Token: 0x04000EE7 RID: 3815
			public uint[] territoryLeagues;
		}
	}
}
