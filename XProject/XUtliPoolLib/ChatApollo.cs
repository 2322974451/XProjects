using System;

namespace XUtliPoolLib
{
	// Token: 0x020000C4 RID: 196
	public class ChatApollo : CVSReader
	{
		// Token: 0x0600057F RID: 1407 RVA: 0x00018DB8 File Offset: 0x00016FB8
		protected override void ReadLine(XBinaryReader reader)
		{
			ChatApollo.RowData rowData = new ChatApollo.RowData();
			base.Read<int>(reader, ref rowData.speak, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.music, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.click, CVSReader.intParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.note, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.opens, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.openm, CVSReader.intParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.note2, CVSReader.stringParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x00018E98 File Offset: 0x00017098
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ChatApollo.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002EA RID: 746
		public ChatApollo.RowData[] Table = null;

		// Token: 0x020002C2 RID: 706
		public class RowData
		{
			// Token: 0x0400097D RID: 2429
			public int speak;

			// Token: 0x0400097E RID: 2430
			public int music;

			// Token: 0x0400097F RID: 2431
			public int click;

			// Token: 0x04000980 RID: 2432
			public string note;

			// Token: 0x04000981 RID: 2433
			public int opens;

			// Token: 0x04000982 RID: 2434
			public int openm;

			// Token: 0x04000983 RID: 2435
			public string note2;
		}
	}
}
