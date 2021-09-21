using System;

namespace XUtliPoolLib
{
	// Token: 0x02000267 RID: 615
	public class RiftType : CVSReader
	{
		// Token: 0x06000D35 RID: 3381 RVA: 0x00045BB0 File Offset: 0x00043DB0
		protected override void ReadLine(XBinaryReader reader)
		{
			RiftType.RowData rowData = new RiftType.RowData();
			base.Read<int>(reader, ref rowData.id, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.sceneid, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.worldlevel, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.bufflibrary, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.buffcounts, CVSReader.intParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D36 RID: 3382 RVA: 0x00045C5C File Offset: 0x00043E5C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new RiftType.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007B5 RID: 1973
		public RiftType.RowData[] Table = null;

		// Token: 0x020003F6 RID: 1014
		public class RowData
		{
			// Token: 0x04001209 RID: 4617
			public int id;

			// Token: 0x0400120A RID: 4618
			public int sceneid;

			// Token: 0x0400120B RID: 4619
			public int worldlevel;

			// Token: 0x0400120C RID: 4620
			public int bufflibrary;

			// Token: 0x0400120D RID: 4621
			public int buffcounts;
		}
	}
}
