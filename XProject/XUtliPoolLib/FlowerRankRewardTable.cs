using System;

namespace XUtliPoolLib
{
	// Token: 0x020000F4 RID: 244
	public class FlowerRankRewardTable : CVSReader
	{
		// Token: 0x0600064C RID: 1612 RVA: 0x0001E824 File Offset: 0x0001CA24
		protected override void ReadLine(XBinaryReader reader)
		{
			FlowerRankRewardTable.RowData rowData = new FlowerRankRewardTable.RowData();
			rowData.rank.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.yesterday, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.history, CVSReader.uintParse);
			this.columnno = 3;
			rowData.activity.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x0001E8D0 File Offset: 0x0001CAD0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FlowerRankRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000340 RID: 832
		public FlowerRankRewardTable.RowData[] Table = null;

		// Token: 0x020002F3 RID: 755
		public class RowData
		{
			// Token: 0x04000ADF RID: 2783
			public SeqRef<int> rank;

			// Token: 0x04000AE0 RID: 2784
			public SeqListRef<int> reward;

			// Token: 0x04000AE1 RID: 2785
			public uint yesterday;

			// Token: 0x04000AE2 RID: 2786
			public uint history;

			// Token: 0x04000AE3 RID: 2787
			public SeqListRef<int> activity;
		}
	}
}
