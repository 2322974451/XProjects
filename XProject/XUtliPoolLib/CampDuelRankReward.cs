using System;

namespace XUtliPoolLib
{

	public class CampDuelRankReward : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			CampDuelRankReward.RowData rowData = new CampDuelRankReward.RowData();
			rowData.Rank.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<bool>(reader, ref rowData.IsWin, CVSReader.boolParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.CampID, CVSReader.intParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CampDuelRankReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public CampDuelRankReward.RowData[] Table = null;

		public class RowData
		{

			public SeqRef<int> Rank;

			public SeqListRef<int> Reward;

			public bool IsWin;

			public int CampID;
		}
	}
}
