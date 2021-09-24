using System;

namespace XUtliPoolLib
{

	public class QuestionLibraryTable : CVSReader
	{

		public QuestionLibraryTable.RowData GetByID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			QuestionLibraryTable.RowData result;
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

		private QuestionLibraryTable.RowData BinarySearchID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			QuestionLibraryTable.RowData rowData;
			QuestionLibraryTable.RowData rowData2;
			QuestionLibraryTable.RowData rowData3;
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
			QuestionLibraryTable.RowData rowData = new QuestionLibraryTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Question, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.TimeLimit, CVSReader.intParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.Week, CVSReader.uintParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new QuestionLibraryTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public QuestionLibraryTable.RowData[] Table = null;

		public class RowData
		{

			public int ID;

			public string Question;

			public int TimeLimit;

			public uint Week;
		}
	}
}
