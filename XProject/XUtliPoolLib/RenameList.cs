using System;

namespace XUtliPoolLib
{

	public class RenameList : CVSReader
	{

		public RenameList.RowData GetByid(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			RenameList.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].id == key;
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
			RenameList.RowData rowData = new RenameList.RowData();
			base.Read<int>(reader, ref rowData.id, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.cost, CVSReader.intParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new RenameList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public RenameList.RowData[] Table = null;

		public class RowData
		{

			public int id;

			public int cost;
		}
	}
}
