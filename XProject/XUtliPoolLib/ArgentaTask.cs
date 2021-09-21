using System;

namespace XUtliPoolLib
{
	// Token: 0x02000224 RID: 548
	public class ArgentaTask : CVSReader
	{
		// Token: 0x06000C41 RID: 3137 RVA: 0x000405FC File Offset: 0x0003E7FC
		protected override void ReadLine(XBinaryReader reader)
		{
			ArgentaTask.RowData rowData = new ArgentaTask.RowData();
			rowData.LevelRange.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.TaskID, CVSReader.uintParse);
			this.columnno = 1;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C42 RID: 3138 RVA: 0x00040674 File Offset: 0x0003E874
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ArgentaTask.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000772 RID: 1906
		public ArgentaTask.RowData[] Table = null;

		// Token: 0x020003B3 RID: 947
		public class RowData
		{
			// Token: 0x04001095 RID: 4245
			public SeqRef<uint> LevelRange;

			// Token: 0x04001096 RID: 4246
			public uint TaskID;

			// Token: 0x04001097 RID: 4247
			public SeqListRef<uint> Reward;
		}
	}
}
