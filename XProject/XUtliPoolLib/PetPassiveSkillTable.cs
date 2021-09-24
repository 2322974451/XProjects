using System;

namespace XUtliPoolLib
{

	public class PetPassiveSkillTable : CVSReader
	{

		public PetPassiveSkillTable.RowData GetByid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PetPassiveSkillTable.RowData result;
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
			PetPassiveSkillTable.RowData rowData = new PetPassiveSkillTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.quality, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.Detail, CVSReader.stringParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PetPassiveSkillTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PetPassiveSkillTable.RowData[] Table = null;

		public class RowData
		{

			public uint id;

			public string name;

			public uint quality;

			public string Icon;

			public string Detail;
		}
	}
}
