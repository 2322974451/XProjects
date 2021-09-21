using System;

namespace XUtliPoolLib
{
	// Token: 0x0200026D RID: 621
	public class GuildZiCai : CVSReader
	{
		// Token: 0x06000D47 RID: 3399 RVA: 0x00046170 File Offset: 0x00044370
		protected override void ReadLine(XBinaryReader reader)
		{
			GuildZiCai.RowData rowData = new GuildZiCai.RowData();
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 0;
			rowData.rolerewards.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.guildrewards.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.ShowTips, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.senior, CVSReader.uintParse);
			this.columnno = 4;
			rowData.roleextrarewards.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D48 RID: 3400 RVA: 0x00046238 File Offset: 0x00044438
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildZiCai.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007BB RID: 1979
		public GuildZiCai.RowData[] Table = null;

		// Token: 0x020003FC RID: 1020
		public class RowData
		{
			// Token: 0x04001229 RID: 4649
			public uint itemid;

			// Token: 0x0400122A RID: 4650
			public SeqListRef<uint> rolerewards;

			// Token: 0x0400122B RID: 4651
			public SeqListRef<uint> guildrewards;

			// Token: 0x0400122C RID: 4652
			public string ShowTips;

			// Token: 0x0400122D RID: 4653
			public uint senior;

			// Token: 0x0400122E RID: 4654
			public SeqRef<uint> roleextrarewards;
		}
	}
}
