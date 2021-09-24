using System;

namespace XUtliPoolLib
{

	public class SpritePreviewTable : CVSReader
	{

		public SpritePreviewTable.RowData GetByItemID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			SpritePreviewTable.RowData result;
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

		private SpritePreviewTable.RowData BinarySearchItemID(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			SpritePreviewTable.RowData rowData;
			SpritePreviewTable.RowData rowData2;
			SpritePreviewTable.RowData rowData3;
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
			SpritePreviewTable.RowData rowData = new SpritePreviewTable.RowData();
			base.Read<uint>(reader, ref rowData.ItemID, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<int>(reader, ref rowData.SpriteShow, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.ItemQuality, CVSReader.intParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SpritePreviewTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public SpritePreviewTable.RowData[] Table = null;

		public class RowData
		{

			public uint ItemID;

			public int[] SpriteShow;

			public int ItemQuality;
		}
	}
}
