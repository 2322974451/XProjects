using System;

namespace XUtliPoolLib
{
	// Token: 0x02000175 RID: 373
	public class SuperActivity : CVSReader
	{
		// Token: 0x0600082D RID: 2093 RVA: 0x0002AC1C File Offset: 0x00028E1C
		protected override void ReadLine(XBinaryReader reader)
		{
			SuperActivity.RowData rowData = new SuperActivity.RowData();
			base.Read<uint>(reader, ref rowData.actid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadArray<string>(reader, ref rowData.childs, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.offset, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.belong, CVSReader.uintParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x0002ACFC File Offset: 0x00028EFC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SuperActivity.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003C1 RID: 961
		public SuperActivity.RowData[] Table = null;

		// Token: 0x02000374 RID: 884
		public class RowData
		{
			// Token: 0x04000E96 RID: 3734
			public uint actid;

			// Token: 0x04000E97 RID: 3735
			public uint id;

			// Token: 0x04000E98 RID: 3736
			public string[] childs;

			// Token: 0x04000E99 RID: 3737
			public uint offset;

			// Token: 0x04000E9A RID: 3738
			public string icon;

			// Token: 0x04000E9B RID: 3739
			public string name;

			// Token: 0x04000E9C RID: 3740
			public uint belong;
		}
	}
}
