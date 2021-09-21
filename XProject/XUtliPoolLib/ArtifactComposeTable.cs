using System;

namespace XUtliPoolLib
{
	// Token: 0x020000AF RID: 175
	public class ArtifactComposeTable : CVSReader
	{
		// Token: 0x06000532 RID: 1330 RVA: 0x00016DAC File Offset: 0x00014FAC
		protected override void ReadLine(XBinaryReader reader)
		{
			ArtifactComposeTable.RowData rowData = new ArtifactComposeTable.RowData();
			base.Read<uint>(reader, ref rowData.ArtifactLevel, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.ArtifactQuality, CVSReader.uintParse);
			this.columnno = 1;
			rowData.ArtifactNum2DropID.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x00016E24 File Offset: 0x00015024
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ArtifactComposeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002D5 RID: 725
		public ArtifactComposeTable.RowData[] Table = null;

		// Token: 0x020002AD RID: 685
		public class RowData
		{
			// Token: 0x040008E0 RID: 2272
			public uint ArtifactLevel;

			// Token: 0x040008E1 RID: 2273
			public uint ArtifactQuality;

			// Token: 0x040008E2 RID: 2274
			public SeqListRef<uint> ArtifactNum2DropID;
		}
	}
}
