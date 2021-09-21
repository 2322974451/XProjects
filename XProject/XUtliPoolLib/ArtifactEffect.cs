using System;

namespace XUtliPoolLib
{
	// Token: 0x02000233 RID: 563
	public class ArtifactEffect : CVSReader
	{
		// Token: 0x06000C79 RID: 3193 RVA: 0x000419D4 File Offset: 0x0003FBD4
		protected override void ReadLine(XBinaryReader reader)
		{
			ArtifactEffect.RowData rowData = new ArtifactEffect.RowData();
			base.Read<uint>(reader, ref rowData.Quanlity, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.AttrTyte, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Path, CVSReader.stringParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C7A RID: 3194 RVA: 0x00041A4C File Offset: 0x0003FC4C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ArtifactEffect.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000781 RID: 1921
		public ArtifactEffect.RowData[] Table = null;

		// Token: 0x020003C2 RID: 962
		public class RowData
		{
			// Token: 0x040010ED RID: 4333
			public uint Quanlity;

			// Token: 0x040010EE RID: 4334
			public uint AttrTyte;

			// Token: 0x040010EF RID: 4335
			public string Path;
		}
	}
}
