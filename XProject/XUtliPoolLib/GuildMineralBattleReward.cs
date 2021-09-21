using System;

namespace XUtliPoolLib
{
	// Token: 0x0200010F RID: 271
	public class GuildMineralBattleReward : CVSReader
	{
		// Token: 0x060006B1 RID: 1713 RVA: 0x00020B6C File Offset: 0x0001ED6C
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

		// Token: 0x060006B2 RID: 1714 RVA: 0x00020BD8 File Offset: 0x0001EDD8
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

		// Token: 0x060006B3 RID: 1715 RVA: 0x00020C50 File Offset: 0x0001EE50
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

		// Token: 0x0400035B RID: 859
		public GuildMineralBattleReward.RowData[] Table = null;

		// Token: 0x0200030E RID: 782
		public class RowData
		{
			// Token: 0x04000B6D RID: 2925
			public uint Rank;

			// Token: 0x04000B6E RID: 2926
			public SeqListRef<int> RewardShow;

			// Token: 0x04000B6F RID: 2927
			public uint LevelSeal;
		}
	}
}
