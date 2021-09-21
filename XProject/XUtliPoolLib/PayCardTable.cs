using System;

namespace XUtliPoolLib
{
	// Token: 0x02000139 RID: 313
	public class PayCardTable : CVSReader
	{
		// Token: 0x06000751 RID: 1873 RVA: 0x00024C6C File Offset: 0x00022E6C
		protected override void ReadLine(XBinaryReader reader)
		{
			PayCardTable.RowData rowData = new PayCardTable.RowData();
			base.Read<string>(reader, ref rowData.ParamID, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Price, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Diamond, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.DayAward, CVSReader.intParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.ServiceCode, CVSReader.stringParse);
			this.columnno = 9;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x00024D68 File Offset: 0x00022F68
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PayCardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000385 RID: 901
		public PayCardTable.RowData[] Table = null;

		// Token: 0x02000338 RID: 824
		public class RowData
		{
			// Token: 0x04000C9F RID: 3231
			public string ParamID;

			// Token: 0x04000CA0 RID: 3232
			public int Price;

			// Token: 0x04000CA1 RID: 3233
			public int Diamond;

			// Token: 0x04000CA2 RID: 3234
			public int Type;

			// Token: 0x04000CA3 RID: 3235
			public int DayAward;

			// Token: 0x04000CA4 RID: 3236
			public string Name;

			// Token: 0x04000CA5 RID: 3237
			public string Icon;

			// Token: 0x04000CA6 RID: 3238
			public string ServiceCode;
		}
	}
}
