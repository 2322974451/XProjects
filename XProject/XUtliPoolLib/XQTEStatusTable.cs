using System;

namespace XUtliPoolLib
{

	public class XQTEStatusTable : CVSReader
	{

		public XQTEStatusTable.RowData GetByValue(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			XQTEStatusTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].Value == key;
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
			XQTEStatusTable.RowData rowData = new XQTEStatusTable.RowData();
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Value, CVSReader.uintParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new XQTEStatusTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public XQTEStatusTable.RowData[] Table = null;

		public class RowData
		{

			public string Name;

			public uint Value;
		}
	}
}
