using System;

namespace XUtliPoolLib
{
	// Token: 0x0200023E RID: 574
	public class BigMeleePointReward : CVSReader
	{
		// Token: 0x06000CA2 RID: 3234 RVA: 0x00042760 File Offset: 0x00040960
		protected override void ReadLine(XBinaryReader reader)
		{
			BigMeleePointReward.RowData rowData = new BigMeleePointReward.RowData();
			rowData.levelrange.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.point, CVSReader.intParse);
			this.columnno = 1;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CA3 RID: 3235 RVA: 0x000427D8 File Offset: 0x000409D8
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new BigMeleePointReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400078C RID: 1932
		public BigMeleePointReward.RowData[] Table = null;

		// Token: 0x020003CD RID: 973
		public class RowData
		{
			// Token: 0x0400111F RID: 4383
			public SeqRef<int> levelrange;

			// Token: 0x04001120 RID: 4384
			public int point;

			// Token: 0x04001121 RID: 4385
			public SeqListRef<int> reward;
		}
	}
}
