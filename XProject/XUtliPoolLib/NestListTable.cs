using System;

namespace XUtliPoolLib
{
	// Token: 0x0200012B RID: 299
	public class NestListTable : CVSReader
	{
		// Token: 0x0600071D RID: 1821 RVA: 0x000238AC File Offset: 0x00021AAC
		public NestListTable.RowData GetByNestID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			NestListTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].NestID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x00023918 File Offset: 0x00021B18
		protected override void ReadLine(XBinaryReader reader)
		{
			NestListTable.RowData rowData = new NestListTable.RowData();
			base.Read<int>(reader, ref rowData.NestID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Difficulty, CVSReader.intParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x00023990 File Offset: 0x00021B90
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new NestListTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000377 RID: 887
		public NestListTable.RowData[] Table = null;

		// Token: 0x0200032A RID: 810
		public class RowData
		{
			// Token: 0x04000C45 RID: 3141
			public int NestID;

			// Token: 0x04000C46 RID: 3142
			public int Type;

			// Token: 0x04000C47 RID: 3143
			public int Difficulty;
		}
	}
}
