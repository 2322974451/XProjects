using System;

namespace XUtliPoolLib
{
	// Token: 0x02000110 RID: 272
	public class GuildMineralBufflist : CVSReader
	{
		// Token: 0x060006B5 RID: 1717 RVA: 0x00020C90 File Offset: 0x0001EE90
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

		// Token: 0x060006B6 RID: 1718 RVA: 0x00020CFC File Offset: 0x0001EEFC
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

		// Token: 0x060006B7 RID: 1719 RVA: 0x00020D90 File Offset: 0x0001EF90
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

		// Token: 0x0400035C RID: 860
		public GuildMineralBufflist.RowData[] Table = null;

		// Token: 0x0200030F RID: 783
		public class RowData
		{
			// Token: 0x04000B70 RID: 2928
			public uint BuffID;

			// Token: 0x04000B71 RID: 2929
			public string ratestring;

			// Token: 0x04000B72 RID: 2930
			public string icon;

			// Token: 0x04000B73 RID: 2931
			public uint Quality;
		}
	}
}
