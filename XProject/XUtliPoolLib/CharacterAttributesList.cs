using System;

namespace XUtliPoolLib
{
	// Token: 0x020000C3 RID: 195
	public class CharacterAttributesList : CVSReader
	{
		// Token: 0x0600057C RID: 1404 RVA: 0x00018D18 File Offset: 0x00016F18
		protected override void ReadLine(XBinaryReader reader)
		{
			CharacterAttributesList.RowData rowData = new CharacterAttributesList.RowData();
			base.Read<uint>(reader, ref rowData.AttributeID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Section, CVSReader.stringParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x00018D78 File Offset: 0x00016F78
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CharacterAttributesList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002E9 RID: 745
		public CharacterAttributesList.RowData[] Table = null;

		// Token: 0x020002C1 RID: 705
		public class RowData
		{
			// Token: 0x0400097B RID: 2427
			public uint AttributeID;

			// Token: 0x0400097C RID: 2428
			public string Section;
		}
	}
}
