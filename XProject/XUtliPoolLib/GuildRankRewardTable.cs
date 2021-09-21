using System;

namespace XUtliPoolLib
{
	// Token: 0x02000114 RID: 276
	public class GuildRankRewardTable : CVSReader
	{
		// Token: 0x060006C3 RID: 1731 RVA: 0x000210EC File Offset: 0x0001F2EC
		protected override void ReadLine(XBinaryReader reader)
		{
			GuildRankRewardTable.RowData rowData = new GuildRankRewardTable.RowData();
			rowData.Rank.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			rowData.LeaderReward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.OfficerRreward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			rowData.MemberReward.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x00021180 File Offset: 0x0001F380
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildRankRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000360 RID: 864
		public GuildRankRewardTable.RowData[] Table = null;

		// Token: 0x02000313 RID: 787
		public class RowData
		{
			// Token: 0x04000B82 RID: 2946
			public SeqRef<uint> Rank;

			// Token: 0x04000B83 RID: 2947
			public SeqListRef<uint> LeaderReward;

			// Token: 0x04000B84 RID: 2948
			public SeqListRef<uint> OfficerRreward;

			// Token: 0x04000B85 RID: 2949
			public SeqListRef<uint> MemberReward;
		}
	}
}
