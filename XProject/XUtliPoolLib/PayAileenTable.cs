using System;

namespace XUtliPoolLib
{
	// Token: 0x02000138 RID: 312
	public class PayAileenTable : CVSReader
	{
		// Token: 0x0600074E RID: 1870 RVA: 0x00024B14 File Offset: 0x00022D14
		protected override void ReadLine(XBinaryReader reader)
		{
			PayAileenTable.RowData rowData = new PayAileenTable.RowData();
			base.Read<string>(reader, ref rowData.ParamID, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Days, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Price, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.VipLimit, CVSReader.intParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 6;
			base.ReadArray<int>(reader, ref rowData.LevelSealGiftID, CVSReader.intParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.MemberLimit, CVSReader.intParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.ServiceCode, CVSReader.stringParse);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x00024C2C File Offset: 0x00022E2C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PayAileenTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000384 RID: 900
		public PayAileenTable.RowData[] Table = null;

		// Token: 0x02000337 RID: 823
		public class RowData
		{
			// Token: 0x04000C96 RID: 3222
			public string ParamID;

			// Token: 0x04000C97 RID: 3223
			public int Days;

			// Token: 0x04000C98 RID: 3224
			public int Price;

			// Token: 0x04000C99 RID: 3225
			public int VipLimit;

			// Token: 0x04000C9A RID: 3226
			public string Name;

			// Token: 0x04000C9B RID: 3227
			public string Desc;

			// Token: 0x04000C9C RID: 3228
			public int[] LevelSealGiftID;

			// Token: 0x04000C9D RID: 3229
			public int MemberLimit;

			// Token: 0x04000C9E RID: 3230
			public string ServiceCode;
		}
	}
}
