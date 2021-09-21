using System;

namespace XUtliPoolLib
{
	// Token: 0x02000109 RID: 265
	public class GuildCampRank : CVSReader
	{
		// Token: 0x06000699 RID: 1689 RVA: 0x0002021C File Offset: 0x0001E41C
		protected override void ReadLine(XBinaryReader reader)
		{
			GuildCampRank.RowData rowData = new GuildCampRank.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Rank, CVSReader.intParse);
			this.columnno = 1;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x00020294 File Offset: 0x0001E494
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildCampRank.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000355 RID: 853
		public GuildCampRank.RowData[] Table = null;

		// Token: 0x02000308 RID: 776
		public class RowData
		{
			// Token: 0x04000B46 RID: 2886
			public int ID;

			// Token: 0x04000B47 RID: 2887
			public int Rank;

			// Token: 0x04000B48 RID: 2888
			public SeqListRef<uint> Reward;
		}
	}
}
