using System;

namespace XUtliPoolLib
{
	// Token: 0x02000242 RID: 578
	public class TrophyReward : CVSReader
	{
		// Token: 0x06000CB2 RID: 3250 RVA: 0x00042C50 File Offset: 0x00040E50
		protected override void ReadLine(XBinaryReader reader)
		{
			TrophyReward.RowData rowData = new TrophyReward.RowData();
			base.Read<int>(reader, ref rowData.HonourRank, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.TrophyScore, CVSReader.intParse);
			this.columnno = 1;
			rowData.Rewards.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CB3 RID: 3251 RVA: 0x00042CC8 File Offset: 0x00040EC8
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new TrophyReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000790 RID: 1936
		public TrophyReward.RowData[] Table = null;

		// Token: 0x020003D1 RID: 977
		public class RowData
		{
			// Token: 0x0400112A RID: 4394
			public int HonourRank;

			// Token: 0x0400112B RID: 4395
			public int TrophyScore;

			// Token: 0x0400112C RID: 4396
			public SeqListRef<uint> Rewards;
		}
	}
}
