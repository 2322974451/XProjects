using System;

namespace XUtliPoolLib
{
	// Token: 0x02000115 RID: 277
	public class GuildRelaxGameList : CVSReader
	{
		// Token: 0x060006C6 RID: 1734 RVA: 0x000211C0 File Offset: 0x0001F3C0
		public GuildRelaxGameList.RowData GetByModuleID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildRelaxGameList.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ModuleID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x0002122C File Offset: 0x0001F42C
		protected override void ReadLine(XBinaryReader reader)
		{
			GuildRelaxGameList.RowData rowData = new GuildRelaxGameList.RowData();
			base.Read<string>(reader, ref rowData.GameBg, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.GameName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.ModuleID, CVSReader.intParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x000212A4 File Offset: 0x0001F4A4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildRelaxGameList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000361 RID: 865
		public GuildRelaxGameList.RowData[] Table = null;

		// Token: 0x02000314 RID: 788
		public class RowData
		{
			// Token: 0x04000B86 RID: 2950
			public string GameBg;

			// Token: 0x04000B87 RID: 2951
			public string GameName;

			// Token: 0x04000B88 RID: 2952
			public int ModuleID;
		}
	}
}
