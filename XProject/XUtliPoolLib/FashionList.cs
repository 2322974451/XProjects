using System;

namespace XUtliPoolLib
{
	// Token: 0x020000EB RID: 235
	public class FashionList : CVSReader
	{
		// Token: 0x0600062B RID: 1579 RVA: 0x0001DB14 File Offset: 0x0001BD14
		public FashionList.RowData GetByItemID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FashionList.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchItemID(key);
			}
			return result;
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x0001DB4C File Offset: 0x0001BD4C
		private FashionList.RowData BinarySearchItemID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			FashionList.RowData rowData;
			FashionList.RowData rowData2;
			FashionList.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.ItemID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.ItemID == key;
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
				bool flag4 = rowData3.ItemID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.ItemID.CompareTo(key) < 0;
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

		// Token: 0x0600062D RID: 1581 RVA: 0x0001DC28 File Offset: 0x0001BE28
		protected override void ReadLine(XBinaryReader reader)
		{
			FashionList.RowData rowData = new FashionList.RowData();
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<byte>(reader, ref rowData.EquipPos, CVSReader.byteParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.ModelPrefabWarrior, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.PresentID, CVSReader.intParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.ModelPrefabSorcer, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.ModelPrefabArcher, CVSReader.stringParse);
			this.columnno = 5;
			base.ReadArray<short>(reader, ref rowData.ReplaceID, CVSReader.shortParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.ModelPrefabCleric, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.ModelPrefab5, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.ModelPrefab6, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.ModelPrefab7, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.SuitName, CVSReader.stringParse);
			this.columnno = 14;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x0001DD8C File Offset: 0x0001BF8C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FashionList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000337 RID: 823
		public FashionList.RowData[] Table = null;

		// Token: 0x020002EA RID: 746
		public class RowData
		{
			// Token: 0x04000A9F RID: 2719
			public int ItemID;

			// Token: 0x04000AA0 RID: 2720
			public byte EquipPos;

			// Token: 0x04000AA1 RID: 2721
			public string ModelPrefabWarrior;

			// Token: 0x04000AA2 RID: 2722
			public int PresentID;

			// Token: 0x04000AA3 RID: 2723
			public string ModelPrefabSorcer;

			// Token: 0x04000AA4 RID: 2724
			public string ModelPrefabArcher;

			// Token: 0x04000AA5 RID: 2725
			public short[] ReplaceID;

			// Token: 0x04000AA6 RID: 2726
			public string ModelPrefabCleric;

			// Token: 0x04000AA7 RID: 2727
			public string ModelPrefab5;

			// Token: 0x04000AA8 RID: 2728
			public string ModelPrefab6;

			// Token: 0x04000AA9 RID: 2729
			public string ModelPrefab7;

			// Token: 0x04000AAA RID: 2730
			public string SuitName;
		}
	}
}
