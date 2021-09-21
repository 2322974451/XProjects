using System;

namespace XUtliPoolLib
{
	// Token: 0x02000256 RID: 598
	public class CompeteDragonRankRewardTable : CVSReader
	{
		// Token: 0x06000CFD RID: 3325 RVA: 0x000447A0 File Offset: 0x000429A0
		protected override void ReadLine(XBinaryReader reader)
		{
			CompeteDragonRankRewardTable.RowData rowData = new CompeteDragonRankRewardTable.RowData();
			base.Read<uint>(reader, ref rowData.rank, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.desigation, CVSReader.uintParse);
			this.columnno = 1;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CFE RID: 3326 RVA: 0x00044818 File Offset: 0x00042A18
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CompeteDragonRankRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007A4 RID: 1956
		public CompeteDragonRankRewardTable.RowData[] Table = null;

		// Token: 0x020003E5 RID: 997
		public class RowData
		{
			// Token: 0x040011A1 RID: 4513
			public uint rank;

			// Token: 0x040011A2 RID: 4514
			public uint desigation;

			// Token: 0x040011A3 RID: 4515
			public SeqListRef<int> reward;
		}
	}
}
