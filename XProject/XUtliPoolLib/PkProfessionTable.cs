using System;

namespace XUtliPoolLib
{
	// Token: 0x02000148 RID: 328
	public class PkProfessionTable : CVSReader
	{
		// Token: 0x06000784 RID: 1924 RVA: 0x00025FB8 File Offset: 0x000241B8
		protected override void ReadLine(XBinaryReader reader)
		{
			PkProfessionTable.RowData rowData = new PkProfessionTable.RowData();
			base.ReadArray<byte>(reader, ref rowData.SceneType, CVSReader.byteParse);
			this.columnno = 13;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x00025FFC File Offset: 0x000241FC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PkProfessionTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000394 RID: 916
		public PkProfessionTable.RowData[] Table = null;

		// Token: 0x02000347 RID: 839
		public class RowData
		{
			// Token: 0x04000D05 RID: 3333
			public byte[] SceneType;
		}
	}
}
