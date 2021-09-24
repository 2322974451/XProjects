using System;

namespace XUtliPoolLib
{

	public class PetFoodTable : CVSReader
	{

		public PetFoodTable.RowData GetByitemid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PetFoodTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].itemid == key;
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
			PetFoodTable.RowData rowData = new PetFoodTable.RowData();
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.exp, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.description, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.hungry, CVSReader.uintParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PetFoodTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PetFoodTable.RowData[] Table = null;

		public class RowData
		{

			public uint itemid;

			public uint exp;

			public string description;

			public uint hungry;
		}
	}
}
