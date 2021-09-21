using System;

namespace XUtliPoolLib
{
	// Token: 0x020000DE RID: 222
	public class DragonNestType : CVSReader
	{
		// Token: 0x060005FA RID: 1530 RVA: 0x0001C50C File Offset: 0x0001A70C
		protected override void ReadLine(XBinaryReader reader)
		{
			DragonNestType.RowData rowData = new DragonNestType.RowData();
			base.Read<uint>(reader, ref rowData.DragonNestType, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.TypeName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.TypeBg, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.TypeIcon, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x0001C5A0 File Offset: 0x0001A7A0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DragonNestType.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400032A RID: 810
		public DragonNestType.RowData[] Table = null;

		// Token: 0x020002DD RID: 733
		public class RowData
		{
			// Token: 0x04000A30 RID: 2608
			public uint DragonNestType;

			// Token: 0x04000A31 RID: 2609
			public string TypeName;

			// Token: 0x04000A32 RID: 2610
			public string TypeBg;

			// Token: 0x04000A33 RID: 2611
			public string TypeIcon;
		}
	}
}
