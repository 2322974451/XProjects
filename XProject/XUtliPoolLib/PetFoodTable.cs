using System;

namespace XUtliPoolLib
{
	// Token: 0x0200013F RID: 319
	public class PetFoodTable : CVSReader
	{
		// Token: 0x06000764 RID: 1892 RVA: 0x00025520 File Offset: 0x00023720
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

		// Token: 0x06000765 RID: 1893 RVA: 0x0002558C File Offset: 0x0002378C
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

		// Token: 0x06000766 RID: 1894 RVA: 0x00025620 File Offset: 0x00023820
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

		// Token: 0x0400038B RID: 907
		public PetFoodTable.RowData[] Table = null;

		// Token: 0x0200033E RID: 830
		public class RowData
		{
			// Token: 0x04000CD7 RID: 3287
			public uint itemid;

			// Token: 0x04000CD8 RID: 3288
			public uint exp;

			// Token: 0x04000CD9 RID: 3289
			public string description;

			// Token: 0x04000CDA RID: 3290
			public uint hungry;
		}
	}
}
