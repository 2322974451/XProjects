using System;

namespace XUtliPoolLib
{
	// Token: 0x020000E7 RID: 231
	public class ExpBackTable : CVSReader
	{
		// Token: 0x0600061C RID: 1564 RVA: 0x0001D3FC File Offset: 0x0001B5FC
		public ExpBackTable.RowData GetBytype(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ExpBackTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].type == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x0001D468 File Offset: 0x0001B668
		protected override void ReadLine(XBinaryReader reader)
		{
			ExpBackTable.RowData rowData = new ExpBackTable.RowData();
			base.Read<int>(reader, ref rowData.type, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.count, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.exp, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.freeExpParam, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.moneyCostParam, CVSReader.intParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x0001D514 File Offset: 0x0001B714
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ExpBackTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000333 RID: 819
		public ExpBackTable.RowData[] Table = null;

		// Token: 0x020002E6 RID: 742
		public class RowData
		{
			// Token: 0x04000A79 RID: 2681
			public int type;

			// Token: 0x04000A7A RID: 2682
			public int count;

			// Token: 0x04000A7B RID: 2683
			public int exp;

			// Token: 0x04000A7C RID: 2684
			public int freeExpParam;

			// Token: 0x04000A7D RID: 2685
			public int moneyCostParam;
		}
	}
}
