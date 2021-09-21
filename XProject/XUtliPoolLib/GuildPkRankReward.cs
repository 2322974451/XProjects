using System;

namespace XUtliPoolLib
{
	// Token: 0x02000113 RID: 275
	public class GuildPkRankReward : CVSReader
	{
		// Token: 0x060006BF RID: 1727 RVA: 0x00020FE0 File Offset: 0x0001F1E0
		public GuildPkRankReward.RowData GetByrank(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildPkRankReward.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].rank == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x0002104C File Offset: 0x0001F24C
		protected override void ReadLine(XBinaryReader reader)
		{
			GuildPkRankReward.RowData rowData = new GuildPkRankReward.RowData();
			base.Read<uint>(reader, ref rowData.rank, CVSReader.uintParse);
			this.columnno = 0;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x000210AC File Offset: 0x0001F2AC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildPkRankReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400035F RID: 863
		public GuildPkRankReward.RowData[] Table = null;

		// Token: 0x02000312 RID: 786
		public class RowData
		{
			// Token: 0x04000B80 RID: 2944
			public uint rank;

			// Token: 0x04000B81 RID: 2945
			public SeqListRef<uint> reward;
		}
	}
}
