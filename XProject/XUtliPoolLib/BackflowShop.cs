using System;

namespace XUtliPoolLib
{
	// Token: 0x020000B6 RID: 182
	public class BackflowShop : CVSReader
	{
		// Token: 0x0600054B RID: 1355 RVA: 0x0001773C File Offset: 0x0001593C
		public BackflowShop.RowData GetByGoodID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			BackflowShop.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchGoodID(key);
			}
			return result;
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x00017774 File Offset: 0x00015974
		private BackflowShop.RowData BinarySearchGoodID(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			BackflowShop.RowData rowData;
			BackflowShop.RowData rowData2;
			BackflowShop.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.GoodID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.GoodID == key;
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
				bool flag4 = rowData3.GoodID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.GoodID.CompareTo(key) < 0;
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

		// Token: 0x0600054D RID: 1357 RVA: 0x00017850 File Offset: 0x00015A50
		protected override void ReadLine(XBinaryReader reader)
		{
			BackflowShop.RowData rowData = new BackflowShop.RowData();
			base.Read<uint>(reader, ref rowData.GoodID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.ItemID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.ItemCount, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.CostType, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.CostNum, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.Discount, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.Quality, CVSReader.uintParse);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x00017930 File Offset: 0x00015B30
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new BackflowShop.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002DC RID: 732
		public BackflowShop.RowData[] Table = null;

		// Token: 0x020002B4 RID: 692
		public class RowData
		{
			// Token: 0x0400090E RID: 2318
			public uint GoodID;

			// Token: 0x0400090F RID: 2319
			public uint ItemID;

			// Token: 0x04000910 RID: 2320
			public uint ItemCount;

			// Token: 0x04000911 RID: 2321
			public uint CostType;

			// Token: 0x04000912 RID: 2322
			public uint CostNum;

			// Token: 0x04000913 RID: 2323
			public uint Discount;

			// Token: 0x04000914 RID: 2324
			public uint Quality;
		}
	}
}
