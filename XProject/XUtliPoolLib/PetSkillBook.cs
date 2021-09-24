using System;

namespace XUtliPoolLib
{

	public class PetSkillBook : CVSReader
	{

		public PetSkillBook.RowData GetByitemid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PetSkillBook.RowData result;
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
			PetSkillBook.RowData rowData = new PetSkillBook.RowData();
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PetSkillBook.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PetSkillBook.RowData[] Table = null;

		public class RowData
		{

			public uint itemid;

			public string Description;
		}
	}
}
