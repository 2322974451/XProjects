using System;

namespace XUtliPoolLib
{
	// Token: 0x02000122 RID: 290
	public class ItemTransform : CVSReader
	{
		// Token: 0x060006FA RID: 1786 RVA: 0x00022BA4 File Offset: 0x00020DA4
		public ItemTransform.RowData GetByitemid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ItemTransform.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchitemid(key);
			}
			return result;
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x00022BDC File Offset: 0x00020DDC
		private ItemTransform.RowData BinarySearchitemid(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			ItemTransform.RowData rowData;
			ItemTransform.RowData rowData2;
			ItemTransform.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.itemid == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.itemid == key;
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
				bool flag4 = rowData3.itemid.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.itemid.CompareTo(key) < 0;
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

		// Token: 0x060006FC RID: 1788 RVA: 0x00022CB8 File Offset: 0x00020EB8
		protected override void ReadLine(XBinaryReader reader)
		{
			ItemTransform.RowData rowData = new ItemTransform.RowData();
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.type, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.time, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x00022D30 File Offset: 0x00020F30
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ItemTransform.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400036E RID: 878
		public ItemTransform.RowData[] Table = null;

		// Token: 0x02000321 RID: 801
		public class RowData
		{
			// Token: 0x04000C10 RID: 3088
			public uint itemid;

			// Token: 0x04000C11 RID: 3089
			public uint type;

			// Token: 0x04000C12 RID: 3090
			public string time;
		}
	}
}
