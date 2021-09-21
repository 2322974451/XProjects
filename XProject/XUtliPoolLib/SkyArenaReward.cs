using System;

namespace XUtliPoolLib
{
	// Token: 0x0200016D RID: 365
	public class SkyArenaReward : CVSReader
	{
		// Token: 0x06000810 RID: 2064 RVA: 0x0002A094 File Offset: 0x00028294
		protected override void ReadLine(XBinaryReader reader)
		{
			SkyArenaReward.RowData rowData = new SkyArenaReward.RowData();
			base.Read<int>(reader, ref rowData.LevelSegment, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Floor, CVSReader.intParse);
			this.columnno = 1;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x0002A10C File Offset: 0x0002830C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SkyArenaReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003B9 RID: 953
		public SkyArenaReward.RowData[] Table = null;

		// Token: 0x0200036C RID: 876
		public class RowData
		{
			// Token: 0x04000E5C RID: 3676
			public int LevelSegment;

			// Token: 0x04000E5D RID: 3677
			public int Floor;

			// Token: 0x04000E5E RID: 3678
			public SeqListRef<uint> Reward;
		}
	}
}
