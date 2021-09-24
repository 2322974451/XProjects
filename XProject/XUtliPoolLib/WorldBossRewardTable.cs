using System;

namespace XUtliPoolLib
{

	public class WorldBossRewardTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			WorldBossRewardTable.RowData rowData = new WorldBossRewardTable.RowData();
			base.Read<int>(reader, ref rowData.Level, CVSReader.intParse);
			this.columnno = 0;
			rowData.Rank.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.ShowReward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new WorldBossRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public WorldBossRewardTable.RowData[] Table = null;

		public class RowData
		{

			public int Level;

			public SeqRef<uint> Rank;

			public SeqListRef<uint> ShowReward;
		}
	}
}
