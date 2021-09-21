using System;

namespace XUtliPoolLib
{
	// Token: 0x02000274 RID: 628
	public class FestivityLovePersonReward : CVSReader
	{
		// Token: 0x06000D5E RID: 3422 RVA: 0x00046948 File Offset: 0x00044B48
		protected override void ReadLine(XBinaryReader reader)
		{
			FestivityLovePersonReward.RowData rowData = new FestivityLovePersonReward.RowData();
			base.Read<uint>(reader, ref rowData.LoveScore, CVSReader.uintParse);
			this.columnno = 0;
			rowData.LoveReward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D5F RID: 3423 RVA: 0x000469A8 File Offset: 0x00044BA8
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FestivityLovePersonReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007C2 RID: 1986
		public FestivityLovePersonReward.RowData[] Table = null;

		// Token: 0x02000403 RID: 1027
		public class RowData
		{
			// Token: 0x04001251 RID: 4689
			public uint LoveScore;

			// Token: 0x04001252 RID: 4690
			public SeqListRef<uint> LoveReward;
		}
	}
}
