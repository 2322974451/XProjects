using System;

namespace XUtliPoolLib
{

	public class XOptions : CVSReader
	{

		public XOptions.RowData GetByID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			XOptions.RowData result;
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

		private XOptions.RowData BinarySearchID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			XOptions.RowData rowData;
			XOptions.RowData rowData2;
			XOptions.RowData rowData3;
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

		protected override void ReadLine(XBinaryReader reader)
		{
			XOptions.RowData rowData = new XOptions.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<int>(reader, ref rowData.Classify, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Sort, CVSReader.intParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Text, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Range, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Default, CVSReader.stringParse);
			this.columnno = 6;
			base.ReadArray<string>(reader, ref rowData.OptionText, CVSReader.stringParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new XOptions.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public XOptions.RowData[] Table = null;

		public class RowData
		{

			public int ID;

			public int[] Classify;

			public int Sort;

			public string Text;

			public int Type;

			public string Range;

			public string Default;

			public string[] OptionText;
		}
	}
}
