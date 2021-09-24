using System;

namespace XUtliPoolLib
{

	public class NestListTable : CVSReader
	{

		public NestListTable.RowData GetByNestID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			NestListTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].NestID == key;
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
			NestListTable.RowData rowData = new NestListTable.RowData();
			base.Read<int>(reader, ref rowData.NestID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Difficulty, CVSReader.intParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new NestListTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public NestListTable.RowData[] Table = null;

		public class RowData
		{

			public int NestID;

			public int Type;

			public int Difficulty;
		}
	}
}
