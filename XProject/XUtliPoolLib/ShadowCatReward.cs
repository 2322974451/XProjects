using System;

namespace XUtliPoolLib
{
	// Token: 0x02000276 RID: 630
	public class ShadowCatReward : CVSReader
	{
		// Token: 0x06000D64 RID: 3428 RVA: 0x00046ABC File Offset: 0x00044CBC
		protected override void ReadLine(XBinaryReader reader)
		{
			ShadowCatReward.RowData rowData = new ShadowCatReward.RowData();
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D65 RID: 3429 RVA: 0x00046B00 File Offset: 0x00044D00
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ShadowCatReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007C4 RID: 1988
		public ShadowCatReward.RowData[] Table = null;

		// Token: 0x02000405 RID: 1029
		public class RowData
		{
			// Token: 0x04001257 RID: 4695
			public SeqListRef<uint> Reward;
		}
	}
}
