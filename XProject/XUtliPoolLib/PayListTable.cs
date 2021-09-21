using System;

namespace XUtliPoolLib
{
	// Token: 0x0200013B RID: 315
	public class PayListTable : CVSReader
	{
		// Token: 0x06000757 RID: 1879 RVA: 0x00024E60 File Offset: 0x00023060
		public PayListTable.RowData GetByParamID(string key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PayListTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ParamID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x00024ED0 File Offset: 0x000230D0
		protected override void ReadLine(XBinaryReader reader)
		{
			PayListTable.RowData rowData = new PayListTable.RowData();
			base.Read<string>(reader, ref rowData.ParamID, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Price, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Diamond, CVSReader.intParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Effect, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.Effect2, CVSReader.stringParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x00024FB0 File Offset: 0x000231B0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PayListTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000387 RID: 903
		public PayListTable.RowData[] Table = null;

		// Token: 0x0200033A RID: 826
		public class RowData
		{
			// Token: 0x04000CAA RID: 3242
			public string ParamID;

			// Token: 0x04000CAB RID: 3243
			public int Price;

			// Token: 0x04000CAC RID: 3244
			public int Diamond;

			// Token: 0x04000CAD RID: 3245
			public string Name;

			// Token: 0x04000CAE RID: 3246
			public string Icon;

			// Token: 0x04000CAF RID: 3247
			public string Effect;

			// Token: 0x04000CB0 RID: 3248
			public string Effect2;
		}
	}
}
