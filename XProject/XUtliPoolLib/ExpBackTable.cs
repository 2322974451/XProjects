using System;

namespace XUtliPoolLib
{

	public class ExpBackTable : CVSReader
	{

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

		public ExpBackTable.RowData[] Table = null;

		public class RowData
		{

			public int type;

			public int count;

			public int exp;

			public int freeExpParam;

			public int moneyCostParam;
		}
	}
}
