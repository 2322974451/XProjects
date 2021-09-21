using System;

namespace XUtliPoolLib
{
	// Token: 0x02000253 RID: 595
	public class GoalAwards : CVSReader
	{
		// Token: 0x06000CF0 RID: 3312 RVA: 0x000441A8 File Offset: 0x000423A8
		protected override void ReadLine(XBinaryReader reader)
		{
			GoalAwards.RowData rowData = new GoalAwards.RowData();
			base.Read<uint>(reader, ref rowData.GoalAwardsID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.AwardsIndex, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.GKID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<double>(reader, ref rowData.AwardsValue, CVSReader.doubleParse);
			this.columnno = 3;
			rowData.Awards.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.TitleID, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.Explanation, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.ShowLevel, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.ShowType, CVSReader.uintParse);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CF1 RID: 3313 RVA: 0x000442F4 File Offset: 0x000424F4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GoalAwards.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007A1 RID: 1953
		public GoalAwards.RowData[] Table = null;

		// Token: 0x020003E2 RID: 994
		public class RowData
		{
			// Token: 0x04001188 RID: 4488
			public uint GoalAwardsID;

			// Token: 0x04001189 RID: 4489
			public uint AwardsIndex;

			// Token: 0x0400118A RID: 4490
			public uint GKID;

			// Token: 0x0400118B RID: 4491
			public double AwardsValue;

			// Token: 0x0400118C RID: 4492
			public SeqListRef<uint> Awards;

			// Token: 0x0400118D RID: 4493
			public uint TitleID;

			// Token: 0x0400118E RID: 4494
			public uint Type;

			// Token: 0x0400118F RID: 4495
			public string Description;

			// Token: 0x04001190 RID: 4496
			public string Explanation;

			// Token: 0x04001191 RID: 4497
			public uint ShowLevel;

			// Token: 0x04001192 RID: 4498
			public uint ShowType;
		}
	}
}
