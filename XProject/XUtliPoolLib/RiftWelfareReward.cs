using System;

namespace XUtliPoolLib
{
	// Token: 0x02000268 RID: 616
	public class RiftWelfareReward : CVSReader
	{
		// Token: 0x06000D38 RID: 3384 RVA: 0x00045C9C File Offset: 0x00043E9C
		protected override void ReadLine(XBinaryReader reader)
		{
			RiftWelfareReward.RowData rowData = new RiftWelfareReward.RowData();
			base.Read<int>(reader, ref rowData.levelrange, CVSReader.intParse);
			this.columnno = 0;
			rowData.floor.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D39 RID: 3385 RVA: 0x00045D14 File Offset: 0x00043F14
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new RiftWelfareReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007B6 RID: 1974
		public RiftWelfareReward.RowData[] Table = null;

		// Token: 0x020003F7 RID: 1015
		public class RowData
		{
			// Token: 0x0400120E RID: 4622
			public int levelrange;

			// Token: 0x0400120F RID: 4623
			public SeqRef<int> floor;

			// Token: 0x04001210 RID: 4624
			public SeqListRef<uint> reward;
		}
	}
}
