using System;

namespace XUtliPoolLib
{
	// Token: 0x02000265 RID: 613
	public class RiftRankReward : CVSReader
	{
		// Token: 0x06000D2F RID: 3375 RVA: 0x000459BC File Offset: 0x00043BBC
		protected override void ReadLine(XBinaryReader reader)
		{
			RiftRankReward.RowData rowData = new RiftRankReward.RowData();
			base.Read<int>(reader, ref rowData.levelrange, CVSReader.intParse);
			this.columnno = 0;
			rowData.rank.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D30 RID: 3376 RVA: 0x00045A34 File Offset: 0x00043C34
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new RiftRankReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007B3 RID: 1971
		public RiftRankReward.RowData[] Table = null;

		// Token: 0x020003F4 RID: 1012
		public class RowData
		{
			// Token: 0x040011FE RID: 4606
			public int levelrange;

			// Token: 0x040011FF RID: 4607
			public SeqRef<uint> rank;

			// Token: 0x04001200 RID: 4608
			public SeqListRef<uint> reward;
		}
	}
}
