using System;

namespace XUtliPoolLib
{
	// Token: 0x02000264 RID: 612
	public class PayGiftTable : CVSReader
	{
		// Token: 0x06000D2C RID: 3372 RVA: 0x0004589C File Offset: 0x00043A9C
		protected override void ReadLine(XBinaryReader reader)
		{
			PayGiftTable.RowData rowData = new PayGiftTable.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.ParamID, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.ItemID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.LimitCount, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.Price, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D2D RID: 3373 RVA: 0x0004597C File Offset: 0x00043B7C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PayGiftTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007B2 RID: 1970
		public PayGiftTable.RowData[] Table = null;

		// Token: 0x020003F3 RID: 1011
		public class RowData
		{
			// Token: 0x040011F7 RID: 4599
			public uint ID;

			// Token: 0x040011F8 RID: 4600
			public string ParamID;

			// Token: 0x040011F9 RID: 4601
			public uint ItemID;

			// Token: 0x040011FA RID: 4602
			public uint LimitCount;

			// Token: 0x040011FB RID: 4603
			public uint Price;

			// Token: 0x040011FC RID: 4604
			public string Name;

			// Token: 0x040011FD RID: 4605
			public string Desc;
		}
	}
}
