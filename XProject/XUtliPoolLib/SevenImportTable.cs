using System;

namespace XUtliPoolLib
{

	public class SevenImportTable : CVSReader
	{

		public SevenImportTable.RowData GetByID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			SevenImportTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ID == key;
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
			SevenImportTable.RowData rowData = new SevenImportTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.SharedTexture, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.SharedIcon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.DialogSharedTexture, CVSReader.stringParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SevenImportTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public SevenImportTable.RowData[] Table = null;

		public class RowData
		{

			public int ID;

			public int ItemID;

			public string SharedTexture;

			public string SharedIcon;

			public string DialogSharedTexture;
		}
	}
}
