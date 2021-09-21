using System;

namespace XUtliPoolLib
{
	// Token: 0x0200011E RID: 286
	public class ItemBackTable : CVSReader
	{
		// Token: 0x060006E9 RID: 1769 RVA: 0x00022204 File Offset: 0x00020404
		protected override void ReadLine(XBinaryReader reader)
		{
			ItemBackTable.RowData rowData = new ItemBackTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SystemName, CVSReader.stringParse);
			this.columnno = 2;
			rowData.ItemGold.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.ItemDragonCoin.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.count, CVSReader.intParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.FindBackDays, CVSReader.intParse);
			this.columnno = 10;
			base.Read<bool>(reader, ref rowData.IsWeekBack, CVSReader.boolParse);
			this.columnno = 11;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x00022300 File Offset: 0x00020500
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ItemBackTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400036A RID: 874
		public ItemBackTable.RowData[] Table = null;

		// Token: 0x0200031D RID: 797
		public class RowData
		{
			// Token: 0x04000BDC RID: 3036
			public int ID;

			// Token: 0x04000BDD RID: 3037
			public string SystemName;

			// Token: 0x04000BDE RID: 3038
			public SeqListRef<int> ItemGold;

			// Token: 0x04000BDF RID: 3039
			public SeqListRef<int> ItemDragonCoin;

			// Token: 0x04000BE0 RID: 3040
			public int count;

			// Token: 0x04000BE1 RID: 3041
			public string Desc;

			// Token: 0x04000BE2 RID: 3042
			public int FindBackDays;

			// Token: 0x04000BE3 RID: 3043
			public bool IsWeekBack;
		}
	}
}
