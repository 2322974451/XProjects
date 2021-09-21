using System;

namespace XUtliPoolLib
{
	// Token: 0x0200024D RID: 589
	public class DragonGuildLivenessTable : CVSReader
	{
		// Token: 0x06000CD9 RID: 3289 RVA: 0x0004390C File Offset: 0x00041B0C
		protected override void ReadLine(XBinaryReader reader)
		{
			DragonGuildLivenessTable.RowData rowData = new DragonGuildLivenessTable.RowData();
			base.Read<uint>(reader, ref rowData.liveness, CVSReader.uintParse);
			this.columnno = 0;
			rowData.level.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.viewabledrop.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.index, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.boxPic, CVSReader.stringParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CDA RID: 3290 RVA: 0x000439B8 File Offset: 0x00041BB8
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DragonGuildLivenessTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400079B RID: 1947
		public DragonGuildLivenessTable.RowData[] Table = null;

		// Token: 0x020003DC RID: 988
		public class RowData
		{
			// Token: 0x04001161 RID: 4449
			public uint liveness;

			// Token: 0x04001162 RID: 4450
			public SeqRef<uint> level;

			// Token: 0x04001163 RID: 4451
			public SeqListRef<uint> viewabledrop;

			// Token: 0x04001164 RID: 4452
			public uint index;

			// Token: 0x04001165 RID: 4453
			public string boxPic;
		}
	}
}
