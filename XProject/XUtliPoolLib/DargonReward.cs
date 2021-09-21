using System;

namespace XUtliPoolLib
{
	// Token: 0x02000236 RID: 566
	public class DargonReward : CVSReader
	{
		// Token: 0x06000C83 RID: 3203 RVA: 0x00041D58 File Offset: 0x0003FF58
		protected override void ReadLine(XBinaryReader reader)
		{
			DargonReward.RowData rowData = new DargonReward.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Achievement, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Explanation, CVSReader.stringParse);
			this.columnno = 2;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.ICON, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.DesignationName, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.SortID, CVSReader.intParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x00041E38 File Offset: 0x00040038
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DargonReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000784 RID: 1924
		public DargonReward.RowData[] Table = null;

		// Token: 0x020003C5 RID: 965
		public class RowData
		{
			// Token: 0x040010FF RID: 4351
			public int ID;

			// Token: 0x04001100 RID: 4352
			public string Achievement;

			// Token: 0x04001101 RID: 4353
			public string Explanation;

			// Token: 0x04001102 RID: 4354
			public SeqListRef<int> Reward;

			// Token: 0x04001103 RID: 4355
			public string ICON;

			// Token: 0x04001104 RID: 4356
			public string DesignationName;

			// Token: 0x04001105 RID: 4357
			public int SortID;
		}
	}
}
