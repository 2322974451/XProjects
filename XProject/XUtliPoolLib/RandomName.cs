using System;

namespace XUtliPoolLib
{
	// Token: 0x0200015F RID: 351
	public class RandomName : CVSReader
	{
		// Token: 0x060007D8 RID: 2008 RVA: 0x00027C48 File Offset: 0x00025E48
		public RandomName.RowData GetByID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			RandomName.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchID(key);
			}
			return result;
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x00027C80 File Offset: 0x00025E80
		private RandomName.RowData BinarySearchID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			RandomName.RowData rowData;
			RandomName.RowData rowData2;
			RandomName.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.ID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.ID == key;
				if (flag2)
				{
					goto Block_2;
				}
				bool flag3 = num2 - num <= 1;
				if (flag3)
				{
					goto Block_3;
				}
				int num3 = num + (num2 - num) / 2;
				rowData3 = this.Table[num3];
				bool flag4 = rowData3.ID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.ID.CompareTo(key) < 0;
					if (!flag5)
					{
						goto IL_B1;
					}
					num = num3;
				}
				if (num >= num2)
				{
					goto Block_6;
				}
			}
			return rowData;
			Block_2:
			return rowData2;
			Block_3:
			return null;
			IL_B1:
			return rowData3;
			Block_6:
			return null;
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x00027D5C File Offset: 0x00025F5C
		protected override void ReadLine(XBinaryReader reader)
		{
			RandomName.RowData rowData = new RandomName.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.FirstName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.LastName, CVSReader.stringParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x00027DD4 File Offset: 0x00025FD4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new RandomName.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003AB RID: 939
		public RandomName.RowData[] Table = null;

		// Token: 0x0200035E RID: 862
		public class RowData
		{
			// Token: 0x04000D79 RID: 3449
			public int ID;

			// Token: 0x04000D7A RID: 3450
			public string FirstName;

			// Token: 0x04000D7B RID: 3451
			public string LastName;
		}
	}
}
