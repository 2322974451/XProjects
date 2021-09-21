using System;

namespace XUtliPoolLib
{
	// Token: 0x02000108 RID: 264
	public class GuildCamp : CVSReader
	{
		// Token: 0x06000696 RID: 1686 RVA: 0x00020114 File Offset: 0x0001E314
		protected override void ReadLine(XBinaryReader reader)
		{
			GuildCamp.RowData rowData = new GuildCamp.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Condition, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.RankDes, CVSReader.stringParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x000201DC File Offset: 0x0001E3DC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildCamp.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000354 RID: 852
		public GuildCamp.RowData[] Table = null;

		// Token: 0x02000307 RID: 775
		public class RowData
		{
			// Token: 0x04000B40 RID: 2880
			public int ID;

			// Token: 0x04000B41 RID: 2881
			public string Name;

			// Token: 0x04000B42 RID: 2882
			public string Description;

			// Token: 0x04000B43 RID: 2883
			public string Condition;

			// Token: 0x04000B44 RID: 2884
			public int Type;

			// Token: 0x04000B45 RID: 2885
			public string RankDes;
		}
	}
}
