using System;

namespace XUtliPoolLib
{
	// Token: 0x02000141 RID: 321
	public class PetItemTable : CVSReader
	{
		// Token: 0x0600076C RID: 1900 RVA: 0x000258C8 File Offset: 0x00023AC8
		public PetItemTable.RowData GetByitemid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PetItemTable.RowData result;
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

		// Token: 0x0600076D RID: 1901 RVA: 0x00025934 File Offset: 0x00023B34
		protected override void ReadLine(XBinaryReader reader)
		{
			PetItemTable.RowData rowData = new PetItemTable.RowData();
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.petid, CVSReader.uintParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x00025994 File Offset: 0x00023B94
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PetItemTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400038D RID: 909
		public PetItemTable.RowData[] Table = null;

		// Token: 0x02000340 RID: 832
		public class RowData
		{
			// Token: 0x04000CEA RID: 3306
			public uint itemid;

			// Token: 0x04000CEB RID: 3307
			public uint petid;
		}
	}
}
