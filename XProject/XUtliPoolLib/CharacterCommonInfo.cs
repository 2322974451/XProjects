using System;

namespace XUtliPoolLib
{
	// Token: 0x0200023C RID: 572
	public class CharacterCommonInfo : CVSReader
	{
		// Token: 0x06000C9A RID: 3226 RVA: 0x000424F4 File Offset: 0x000406F4
		protected override void ReadLine(XBinaryReader reader)
		{
			CharacterCommonInfo.RowData rowData = new CharacterCommonInfo.RowData();
			base.Read<string>(reader, ref rowData.ShowText, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C9B RID: 3227 RVA: 0x00042554 File Offset: 0x00040754
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CharacterCommonInfo.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400078A RID: 1930
		public CharacterCommonInfo.RowData[] Table = null;

		// Token: 0x020003CB RID: 971
		public class RowData
		{
			// Token: 0x0400111A RID: 4378
			public string ShowText;

			// Token: 0x0400111B RID: 4379
			public uint Type;
		}
	}
}
