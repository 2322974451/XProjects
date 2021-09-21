using System;

namespace XUtliPoolLib
{
	// Token: 0x020000C7 RID: 199
	public class ChestList : CVSReader
	{
		// Token: 0x06000589 RID: 1417 RVA: 0x00019244 File Offset: 0x00017444
		protected override void ReadLine(XBinaryReader reader)
		{
			ChestList.RowData rowData = new ChestList.RowData();
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.DropID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Profession, CVSReader.intParse);
			this.columnno = 5;
			base.Read<bool>(reader, ref rowData.MultiOpen, CVSReader.boolParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x000192D8 File Offset: 0x000174D8
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ChestList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002ED RID: 749
		public ChestList.RowData[] Table = null;

		// Token: 0x020002C5 RID: 709
		public class RowData
		{
			// Token: 0x04000999 RID: 2457
			public int ItemID;

			// Token: 0x0400099A RID: 2458
			public uint[] DropID;

			// Token: 0x0400099B RID: 2459
			public int Profession;

			// Token: 0x0400099C RID: 2460
			public bool MultiOpen;
		}
	}
}
