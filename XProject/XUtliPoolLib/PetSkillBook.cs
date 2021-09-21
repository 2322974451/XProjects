using System;

namespace XUtliPoolLib
{
	// Token: 0x02000145 RID: 325
	public class PetSkillBook : CVSReader
	{
		// Token: 0x0600077A RID: 1914 RVA: 0x00025CD4 File Offset: 0x00023ED4
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

		// Token: 0x0600077B RID: 1915 RVA: 0x00025D40 File Offset: 0x00023F40
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

		// Token: 0x0600077C RID: 1916 RVA: 0x00025DA0 File Offset: 0x00023FA0
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

		// Token: 0x04000391 RID: 913
		public PetSkillBook.RowData[] Table = null;

		// Token: 0x02000344 RID: 836
		public class RowData
		{
			// Token: 0x04000CF9 RID: 3321
			public uint itemid;

			// Token: 0x04000CFA RID: 3322
			public string Description;
		}
	}
}
