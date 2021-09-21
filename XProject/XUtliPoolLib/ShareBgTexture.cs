using System;

namespace XUtliPoolLib
{
	// Token: 0x0200023B RID: 571
	public class ShareBgTexture : CVSReader
	{
		// Token: 0x06000C97 RID: 3223 RVA: 0x00042420 File Offset: 0x00040620
		protected override void ReadLine(XBinaryReader reader)
		{
			ShareBgTexture.RowData rowData = new ShareBgTexture.RowData();
			base.Read<int>(reader, ref rowData.ShareBgType, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.SubBgIDList, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadArray<string>(reader, ref rowData.TexturePathList, CVSReader.stringParse);
			this.columnno = 2;
			base.ReadArray<string>(reader, ref rowData.Text, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C98 RID: 3224 RVA: 0x000424B4 File Offset: 0x000406B4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ShareBgTexture.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000789 RID: 1929
		public ShareBgTexture.RowData[] Table = null;

		// Token: 0x020003CA RID: 970
		public class RowData
		{
			// Token: 0x04001116 RID: 4374
			public int ShareBgType;

			// Token: 0x04001117 RID: 4375
			public uint[] SubBgIDList;

			// Token: 0x04001118 RID: 4376
			public string[] TexturePathList;

			// Token: 0x04001119 RID: 4377
			public string[] Text;
		}
	}
}
