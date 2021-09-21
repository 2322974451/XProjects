using System;

namespace XUtliPoolLib
{
	// Token: 0x02000105 RID: 261
	public class GuildBossRewardTable : CVSReader
	{
		// Token: 0x0600068B RID: 1675 RVA: 0x0001FE20 File Offset: 0x0001E020
		public GuildBossRewardTable.RowData GetByrank(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildBossRewardTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchrank(key);
			}
			return result;
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x0001FE58 File Offset: 0x0001E058
		private GuildBossRewardTable.RowData BinarySearchrank(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			GuildBossRewardTable.RowData rowData;
			GuildBossRewardTable.RowData rowData2;
			GuildBossRewardTable.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.rank == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.rank == key;
				if (flag2)
				{
					goto Block_2;
				}
				bool flag3 = num2 - num <= 1;
				if (flag3)
				{
					goto Block_3;
				}
				int num3 = num + (num2 - num) / 2;
				rowData3 = this.Table[num3];
				bool flag4 = rowData3.rank.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.rank.CompareTo(key) < 0;
					if (!flag5)
					{
						goto IL_B1;
					}
					num = num3;
				}
				if (num >= num2)
				{
					goto Block_6;
				}
			}
			return rowData;
			Block_2:
			return rowData2;
			Block_3:
			return null;
			IL_B1:
			return rowData3;
			Block_6:
			return null;
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x0001FF34 File Offset: 0x0001E134
		protected override void ReadLine(XBinaryReader reader)
		{
			GuildBossRewardTable.RowData rowData = new GuildBossRewardTable.RowData();
			base.Read<uint>(reader, ref rowData.rank, CVSReader.uintParse);
			this.columnno = 0;
			rowData.guildexp.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x0001FF94 File Offset: 0x0001E194
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildBossRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000351 RID: 849
		public GuildBossRewardTable.RowData[] Table = null;

		// Token: 0x02000304 RID: 772
		public class RowData
		{
			// Token: 0x04000B3A RID: 2874
			public uint rank;

			// Token: 0x04000B3B RID: 2875
			public SeqListRef<uint> guildexp;
		}
	}
}
