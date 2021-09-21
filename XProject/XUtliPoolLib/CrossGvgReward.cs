using System;

namespace XUtliPoolLib
{
	// Token: 0x02000270 RID: 624
	public class CrossGvgReward : CVSReader
	{
		// Token: 0x06000D52 RID: 3410 RVA: 0x00046578 File Offset: 0x00044778
		protected override void ReadLine(XBinaryReader reader)
		{
			CrossGvgReward.RowData rowData = new CrossGvgReward.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			rowData.Rank.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.MemberRewardMail, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.GuildExp, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.GuildPrestige, CVSReader.uintParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D53 RID: 3411 RVA: 0x00046624 File Offset: 0x00044824
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CrossGvgReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007BE RID: 1982
		public CrossGvgReward.RowData[] Table = null;

		// Token: 0x020003FF RID: 1023
		public class RowData
		{
			// Token: 0x0400123C RID: 4668
			public uint Type;

			// Token: 0x0400123D RID: 4669
			public SeqRef<uint> Rank;

			// Token: 0x0400123E RID: 4670
			public uint MemberRewardMail;

			// Token: 0x0400123F RID: 4671
			public uint GuildExp;

			// Token: 0x04001240 RID: 4672
			public uint GuildPrestige;
		}
	}
}
