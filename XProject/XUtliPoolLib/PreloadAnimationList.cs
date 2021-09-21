using System;

namespace XUtliPoolLib
{
	// Token: 0x0200014F RID: 335
	public class PreloadAnimationList : CVSReader
	{
		// Token: 0x0600079D RID: 1949 RVA: 0x000267F8 File Offset: 0x000249F8
		protected override void ReadLine(XBinaryReader reader)
		{
			PreloadAnimationList.RowData rowData = new PreloadAnimationList.RowData();
			base.Read<int>(reader, ref rowData.SceneID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.AnimName, CVSReader.stringParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x00026858 File Offset: 0x00024A58
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PreloadAnimationList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400039B RID: 923
		public PreloadAnimationList.RowData[] Table = null;

		// Token: 0x0200034E RID: 846
		public class RowData
		{
			// Token: 0x04000D26 RID: 3366
			public int SceneID;

			// Token: 0x04000D27 RID: 3367
			public string AnimName;
		}
	}
}
