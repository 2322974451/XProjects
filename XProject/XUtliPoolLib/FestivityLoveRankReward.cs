using System;

namespace XUtliPoolLib
{
	// Token: 0x02000275 RID: 629
	public class FestivityLoveRankReward : CVSReader
	{
		// Token: 0x06000D61 RID: 3425 RVA: 0x000469E8 File Offset: 0x00044BE8
		protected override void ReadLine(XBinaryReader reader)
		{
			FestivityLoveRankReward.RowData rowData = new FestivityLoveRankReward.RowData();
			rowData.LoveRank.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			rowData.RankReward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.DesignationId, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.DesignationIcon, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D62 RID: 3426 RVA: 0x00046A7C File Offset: 0x00044C7C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FestivityLoveRankReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007C3 RID: 1987
		public FestivityLoveRankReward.RowData[] Table = null;

		// Token: 0x02000404 RID: 1028
		public class RowData
		{
			// Token: 0x04001253 RID: 4691
			public SeqRef<uint> LoveRank;

			// Token: 0x04001254 RID: 4692
			public SeqListRef<uint> RankReward;

			// Token: 0x04001255 RID: 4693
			public uint DesignationId;

			// Token: 0x04001256 RID: 4694
			public string DesignationIcon;
		}
	}
}
