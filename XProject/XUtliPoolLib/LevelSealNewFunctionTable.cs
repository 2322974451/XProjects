using System;

namespace XUtliPoolLib
{
	// Token: 0x02000126 RID: 294
	public class LevelSealNewFunctionTable : CVSReader
	{
		// Token: 0x0600070A RID: 1802 RVA: 0x00023100 File Offset: 0x00021300
		protected override void ReadLine(XBinaryReader reader)
		{
			LevelSealNewFunctionTable.RowData rowData = new LevelSealNewFunctionTable.RowData();
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.OpenLevel, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Tag, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.IconName, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00023194 File Offset: 0x00021394
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new LevelSealNewFunctionTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000372 RID: 882
		public LevelSealNewFunctionTable.RowData[] Table = null;

		// Token: 0x02000325 RID: 805
		public class RowData
		{
			// Token: 0x04000C1F RID: 3103
			public int Type;

			// Token: 0x04000C20 RID: 3104
			public int OpenLevel;

			// Token: 0x04000C21 RID: 3105
			public string Tag;

			// Token: 0x04000C22 RID: 3106
			public string IconName;
		}
	}
}
