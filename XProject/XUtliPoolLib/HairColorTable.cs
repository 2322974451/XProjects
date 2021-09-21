using System;

namespace XUtliPoolLib
{
	// Token: 0x02000238 RID: 568
	public class HairColorTable : CVSReader
	{
		// Token: 0x06000C8B RID: 3211 RVA: 0x0004202C File Offset: 0x0004022C
		public HairColorTable.RowData GetByID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			HairColorTable.RowData result;
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

		// Token: 0x06000C8C RID: 3212 RVA: 0x00042098 File Offset: 0x00040298
		protected override void ReadLine(XBinaryReader reader)
		{
			HairColorTable.RowData rowData = new HairColorTable.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<float>(reader, ref rowData.Color, CVSReader.floatParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C8D RID: 3213 RVA: 0x0004212C File Offset: 0x0004032C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new HairColorTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000786 RID: 1926
		public HairColorTable.RowData[] Table = null;

		// Token: 0x020003C7 RID: 967
		public class RowData
		{
			// Token: 0x04001108 RID: 4360
			public uint ID;

			// Token: 0x04001109 RID: 4361
			public float[] Color;

			// Token: 0x0400110A RID: 4362
			public string Name;

			// Token: 0x0400110B RID: 4363
			public string Icon;
		}
	}
}
