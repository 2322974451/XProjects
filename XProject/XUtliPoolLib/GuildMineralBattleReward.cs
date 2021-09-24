using System;

namespace XUtliPoolLib
{

	public class GuildMineralBattleReward : CVSReader
	{

		public GuildMineralBattleReward.RowData GetByRank(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildMineralBattleReward.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].Rank == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			GuildMineralBattleReward.RowData rowData = new GuildMineralBattleReward.RowData();
			base.Read<uint>(reader, ref rowData.Rank, CVSReader.uintParse);
			this.columnno = 0;
			rowData.RewardShow.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.LevelSeal, CVSReader.uintParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildMineralBattleReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildMineralBattleReward.RowData[] Table = null;

		public class RowData
		{

			public uint Rank;

			public SeqListRef<int> RewardShow;

			public uint LevelSeal;
		}
	}
}
