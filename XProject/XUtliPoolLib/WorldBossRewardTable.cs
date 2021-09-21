using System;

namespace XUtliPoolLib
{
	// Token: 0x02000181 RID: 385
	public class WorldBossRewardTable : CVSReader
	{
		// Token: 0x0600085C RID: 2140 RVA: 0x0002C178 File Offset: 0x0002A378
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

		// Token: 0x0600085D RID: 2141 RVA: 0x0002C1F0 File Offset: 0x0002A3F0
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

		// Token: 0x040003CD RID: 973
		public WorldBossRewardTable.RowData[] Table = null;

		// Token: 0x02000380 RID: 896
		public class RowData
		{
			// Token: 0x04000F01 RID: 3841
			public int Level;

			// Token: 0x04000F02 RID: 3842
			public SeqRef<uint> Rank;

			// Token: 0x04000F03 RID: 3843
			public SeqListRef<uint> ShowReward;
		}
	}
}
