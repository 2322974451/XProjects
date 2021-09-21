using System;

namespace XUtliPoolLib
{
	// Token: 0x02000107 RID: 263
	public class GuildBuffTable : CVSReader
	{
		// Token: 0x06000693 RID: 1683 RVA: 0x00020074 File Offset: 0x0001E274
		protected override void ReadLine(XBinaryReader reader)
		{
			GuildBuffTable.RowData rowData = new GuildBuffTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x000200D4 File Offset: 0x0001E2D4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildBuffTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000353 RID: 851
		public GuildBuffTable.RowData[] Table = null;

		// Token: 0x02000306 RID: 774
		public class RowData
		{
			// Token: 0x04000B3E RID: 2878
			public uint id;

			// Token: 0x04000B3F RID: 2879
			public uint itemid;
		}
	}
}
