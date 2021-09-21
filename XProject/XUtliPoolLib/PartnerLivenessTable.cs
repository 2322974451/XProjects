using System;

namespace XUtliPoolLib
{
	// Token: 0x02000135 RID: 309
	public class PartnerLivenessTable : CVSReader
	{
		// Token: 0x06000743 RID: 1859 RVA: 0x000247F8 File Offset: 0x000229F8
		protected override void ReadLine(XBinaryReader reader)
		{
			PartnerLivenessTable.RowData rowData = new PartnerLivenessTable.RowData();
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

		// Token: 0x06000744 RID: 1860 RVA: 0x000248A4 File Offset: 0x00022AA4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PartnerLivenessTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000381 RID: 897
		public PartnerLivenessTable.RowData[] Table = null;

		// Token: 0x02000334 RID: 820
		public class RowData
		{
			// Token: 0x04000C8C RID: 3212
			public uint liveness;

			// Token: 0x04000C8D RID: 3213
			public SeqRef<uint> level;

			// Token: 0x04000C8E RID: 3214
			public SeqListRef<uint> viewabledrop;

			// Token: 0x04000C8F RID: 3215
			public uint index;

			// Token: 0x04000C90 RID: 3216
			public string boxPic;
		}
	}
}
