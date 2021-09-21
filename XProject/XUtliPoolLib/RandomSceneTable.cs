using System;

namespace XUtliPoolLib
{
	// Token: 0x02000160 RID: 352
	public class RandomSceneTable : CVSReader
	{
		// Token: 0x060007DD RID: 2013 RVA: 0x00027E14 File Offset: 0x00026014
		protected override void ReadLine(XBinaryReader reader)
		{
			RandomSceneTable.RowData rowData = new RandomSceneTable.RowData();
			base.Read<uint>(reader, ref rowData.RandomID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x00027E74 File Offset: 0x00026074
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new RandomSceneTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003AC RID: 940
		public RandomSceneTable.RowData[] Table = null;

		// Token: 0x0200035F RID: 863
		public class RowData
		{
			// Token: 0x04000D7C RID: 3452
			public uint RandomID;

			// Token: 0x04000D7D RID: 3453
			public uint SceneID;
		}
	}
}
