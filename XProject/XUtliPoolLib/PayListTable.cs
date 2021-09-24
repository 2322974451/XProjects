using System;

namespace XUtliPoolLib
{

	public class PayListTable : CVSReader
	{

		public PayListTable.RowData GetByParamID(string key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PayListTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ParamID == key;
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
			PayListTable.RowData rowData = new PayListTable.RowData();
			base.Read<string>(reader, ref rowData.ParamID, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Price, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Diamond, CVSReader.intParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Effect, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.Effect2, CVSReader.stringParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PayListTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PayListTable.RowData[] Table = null;

		public class RowData
		{

			public string ParamID;

			public int Price;

			public int Diamond;

			public string Name;

			public string Icon;

			public string Effect;

			public string Effect2;
		}
	}
}
