using System;

namespace XUtliPoolLib
{
	// Token: 0x020000DF RID: 223
	public class DropList : CVSReader
	{
		// Token: 0x060005FD RID: 1533 RVA: 0x0001C5E0 File Offset: 0x0001A7E0
		protected override void ReadLine(XBinaryReader reader)
		{
			DropList.RowData rowData = new DropList.RowData();
			base.Read<int>(reader, ref rowData.DropID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.ItemCount, CVSReader.intParse);
			this.columnno = 2;
			base.Read<bool>(reader, ref rowData.ItemBind, CVSReader.boolParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x0001C674 File Offset: 0x0001A874
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DropList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400032B RID: 811
		public DropList.RowData[] Table = null;

		// Token: 0x020002DE RID: 734
		public class RowData
		{
			// Token: 0x04000A34 RID: 2612
			public int DropID;

			// Token: 0x04000A35 RID: 2613
			public int ItemID;

			// Token: 0x04000A36 RID: 2614
			public int ItemCount;

			// Token: 0x04000A37 RID: 2615
			public bool ItemBind;
		}
	}
}
