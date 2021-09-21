using System;

namespace XUtliPoolLib
{
	// Token: 0x020000F0 RID: 240
	public class FirstPassReward : CVSReader
	{
		// Token: 0x0600063E RID: 1598 RVA: 0x0001E3B4 File Offset: 0x0001C5B4
		protected override void ReadLine(XBinaryReader reader)
		{
			FirstPassReward.RowData rowData = new FirstPassReward.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			rowData.Rank.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x0001E42C File Offset: 0x0001C62C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FirstPassReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400033C RID: 828
		public FirstPassReward.RowData[] Table = null;

		// Token: 0x020002EF RID: 751
		public class RowData
		{
			// Token: 0x04000ACC RID: 2764
			public int ID;

			// Token: 0x04000ACD RID: 2765
			public SeqRef<int> Rank;

			// Token: 0x04000ACE RID: 2766
			public SeqListRef<int> Reward;
		}
	}
}
