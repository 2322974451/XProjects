using System;

namespace XUtliPoolLib
{
	// Token: 0x02000147 RID: 327
	public class PkPointTable : CVSReader
	{
		// Token: 0x06000781 RID: 1921 RVA: 0x00025F00 File Offset: 0x00024100
		protected override void ReadLine(XBinaryReader reader)
		{
			PkPointTable.RowData rowData = new PkPointTable.RowData();
			base.Read<uint>(reader, ref rowData.point, CVSReader.uintParse);
			this.columnno = 0;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.IconIndex, CVSReader.intParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x00025F78 File Offset: 0x00024178
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PkPointTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000393 RID: 915
		public PkPointTable.RowData[] Table = null;

		// Token: 0x02000346 RID: 838
		public class RowData
		{
			// Token: 0x04000D02 RID: 3330
			public uint point;

			// Token: 0x04000D03 RID: 3331
			public SeqListRef<uint> reward;

			// Token: 0x04000D04 RID: 3332
			public int IconIndex;
		}
	}
}
