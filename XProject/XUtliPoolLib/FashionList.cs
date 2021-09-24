using System;

namespace XUtliPoolLib
{

	public class FashionList : CVSReader
	{

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

		public FashionList.RowData[] Table = null;

		public class RowData
		{

			public int ItemID;

			public byte EquipPos;

			public string ModelPrefabWarrior;

			public int PresentID;

			public string ModelPrefabSorcer;

			public string ModelPrefabArcher;

			public short[] ReplaceID;

			public string ModelPrefabCleric;

			public string ModelPrefab5;

			public string ModelPrefab6;

			public string ModelPrefab7;

			public string SuitName;
		}
	}
}
