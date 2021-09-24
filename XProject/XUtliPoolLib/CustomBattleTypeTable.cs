using System;

namespace XUtliPoolLib
{

	public class CustomBattleTypeTable : CVSReader
	{

		public CustomBattleTypeTable.RowData GetBytype(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			CustomBattleTypeTable.RowData result;
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
			CustomBattleTypeTable.RowData rowData = new CustomBattleTypeTable.RowData();
			base.Read<int>(reader, ref rowData.type, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.show, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<bool>(reader, ref rowData.notopen, CVSReader.boolParse);
			this.columnno = 3;
			base.Read<bool>(reader, ref rowData.gmcreate, CVSReader.boolParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CustomBattleTypeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public CustomBattleTypeTable.RowData[] Table = null;

		public class RowData
		{

			public int type;

			public string name;

			public string show;

			public bool notopen;

			public bool gmcreate;
		}
	}
}
