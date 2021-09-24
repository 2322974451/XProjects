using System;

namespace XUtliPoolLib
{

	public class GuildRankRewardTable : CVSReader
	{

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

		public GuildRankRewardTable.RowData[] Table = null;

		public class RowData
		{

			public SeqRef<uint> Rank;

			public SeqListRef<uint> LeaderReward;

			public SeqListRef<uint> OfficerRreward;

			public SeqListRef<uint> MemberReward;
		}
	}
}
