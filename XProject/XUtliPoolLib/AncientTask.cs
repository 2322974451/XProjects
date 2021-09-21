using System;

namespace XUtliPoolLib
{
	// Token: 0x02000249 RID: 585
	public class AncientTask : CVSReader
	{
		// Token: 0x06000CCB RID: 3275 RVA: 0x000434B4 File Offset: 0x000416B4
		protected override void ReadLine(XBinaryReader reader)
		{
			AncientTask.RowData rowData = new AncientTask.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.title, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.content, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.time, CVSReader.stringParse);
			this.columnno = 3;
			rowData.rewards.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CCC RID: 3276 RVA: 0x00043560 File Offset: 0x00041760
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new AncientTask.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000797 RID: 1943
		public AncientTask.RowData[] Table = null;

		// Token: 0x020003D8 RID: 984
		public class RowData
		{
			// Token: 0x0400114F RID: 4431
			public uint ID;

			// Token: 0x04001150 RID: 4432
			public string title;

			// Token: 0x04001151 RID: 4433
			public string content;

			// Token: 0x04001152 RID: 4434
			public string time;

			// Token: 0x04001153 RID: 4435
			public SeqListRef<uint> rewards;
		}
	}
}
