using System;

namespace XUtliPoolLib
{
	// Token: 0x0200012C RID: 300
	public class NestTypeTable : CVSReader
	{
		// Token: 0x06000721 RID: 1825 RVA: 0x000239D0 File Offset: 0x00021BD0
		public NestTypeTable.RowData GetByTypeID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			NestTypeTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].TypeID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x00023A3C File Offset: 0x00021C3C
		protected override void ReadLine(XBinaryReader reader)
		{
			NestTypeTable.RowData rowData = new NestTypeTable.RowData();
			base.Read<int>(reader, ref rowData.TypeID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.TypeName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.TypeBg, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.TypeIcon, CVSReader.stringParse);
			this.columnno = 3;
			base.ReadArray<float>(reader, ref rowData.TypeBgTransform, CVSReader.floatParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x00023AE8 File Offset: 0x00021CE8
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new NestTypeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000378 RID: 888
		public NestTypeTable.RowData[] Table = null;

		// Token: 0x0200032B RID: 811
		public class RowData
		{
			// Token: 0x04000C48 RID: 3144
			public int TypeID;

			// Token: 0x04000C49 RID: 3145
			public string TypeName;

			// Token: 0x04000C4A RID: 3146
			public string TypeBg;

			// Token: 0x04000C4B RID: 3147
			public string TypeIcon;

			// Token: 0x04000C4C RID: 3148
			public float[] TypeBgTransform;
		}
	}
}
