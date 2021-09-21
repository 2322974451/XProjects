using System;

namespace XUtliPoolLib
{
	// Token: 0x0200025B RID: 603
	public class DailyTaskLuck : CVSReader
	{
		// Token: 0x06000D0C RID: 3340 RVA: 0x00044DBC File Offset: 0x00042FBC
		protected override void ReadLine(XBinaryReader reader)
		{
			DailyTaskLuck.RowData rowData = new DailyTaskLuck.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			rowData.prob.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.getProb, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.backflowProb, CVSReader.uintParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D0D RID: 3341 RVA: 0x00044E68 File Offset: 0x00043068
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DailyTaskLuck.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007A9 RID: 1961
		public DailyTaskLuck.RowData[] Table = null;

		// Token: 0x020003EA RID: 1002
		public class RowData
		{
			// Token: 0x040011C8 RID: 4552
			public uint id;

			// Token: 0x040011C9 RID: 4553
			public string name;

			// Token: 0x040011CA RID: 4554
			public SeqListRef<uint> prob;

			// Token: 0x040011CB RID: 4555
			public uint getProb;

			// Token: 0x040011CC RID: 4556
			public uint backflowProb;
		}
	}
}
