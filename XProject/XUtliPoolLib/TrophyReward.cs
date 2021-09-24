using System;

namespace XUtliPoolLib
{

	public class TrophyReward : CVSReader
	{

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

		public TrophyReward.RowData[] Table = null;

		public class RowData
		{

			public int HonourRank;

			public int TrophyScore;

			public SeqListRef<uint> Rewards;
		}
	}
}
