using System;

namespace XUtliPoolLib
{
	// Token: 0x02000144 RID: 324
	public class PetPassiveSkillTable : CVSReader
	{
		// Token: 0x06000776 RID: 1910 RVA: 0x00025B7C File Offset: 0x00023D7C
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

		// Token: 0x06000777 RID: 1911 RVA: 0x00025BE8 File Offset: 0x00023DE8
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

		// Token: 0x06000778 RID: 1912 RVA: 0x00025C94 File Offset: 0x00023E94
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

		// Token: 0x04000390 RID: 912
		public PetPassiveSkillTable.RowData[] Table = null;

		// Token: 0x02000343 RID: 835
		public class RowData
		{
			// Token: 0x04000CF4 RID: 3316
			public uint id;

			// Token: 0x04000CF5 RID: 3317
			public string name;

			// Token: 0x04000CF6 RID: 3318
			public uint quality;

			// Token: 0x04000CF7 RID: 3319
			public string Icon;

			// Token: 0x04000CF8 RID: 3320
			public string Detail;
		}
	}
}
