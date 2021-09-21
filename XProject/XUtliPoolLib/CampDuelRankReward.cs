using System;

namespace XUtliPoolLib
{
	// Token: 0x0200026A RID: 618
	public class CampDuelRankReward : CVSReader
	{
		// Token: 0x06000D3E RID: 3390 RVA: 0x00045E40 File Offset: 0x00044040
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

		// Token: 0x06000D3F RID: 3391 RVA: 0x00045ED4 File Offset: 0x000440D4
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

		// Token: 0x040007B8 RID: 1976
		public CampDuelRankReward.RowData[] Table = null;

		// Token: 0x020003F9 RID: 1017
		public class RowData
		{
			// Token: 0x04001216 RID: 4630
			public SeqRef<int> Rank;

			// Token: 0x04001217 RID: 4631
			public SeqListRef<int> Reward;

			// Token: 0x04001218 RID: 4632
			public bool IsWin;

			// Token: 0x04001219 RID: 4633
			public int CampID;
		}
	}
}
