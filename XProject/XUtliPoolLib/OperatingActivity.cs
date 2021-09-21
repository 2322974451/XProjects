using System;

namespace XUtliPoolLib
{
	// Token: 0x02000130 RID: 304
	public class OperatingActivity : CVSReader
	{
		// Token: 0x06000733 RID: 1843 RVA: 0x00024124 File Offset: 0x00022324
		protected override void ReadLine(XBinaryReader reader)
		{
			OperatingActivity.RowData rowData = new OperatingActivity.RowData();
			base.Read<uint>(reader, ref rowData.OrderId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SysEnum, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.SysID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.TabName, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.TabIcon, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<bool>(reader, ref rowData.IsPandoraTab, CVSReader.boolParse);
			this.columnno = 5;
			base.ReadArray<string>(reader, ref rowData.OpenTime, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x00024220 File Offset: 0x00022420
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new OperatingActivity.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400037C RID: 892
		public OperatingActivity.RowData[] Table = null;

		// Token: 0x0200032F RID: 815
		public class RowData
		{
			// Token: 0x04000C62 RID: 3170
			public uint OrderId;

			// Token: 0x04000C63 RID: 3171
			public string SysEnum;

			// Token: 0x04000C64 RID: 3172
			public uint SysID;

			// Token: 0x04000C65 RID: 3173
			public string TabName;

			// Token: 0x04000C66 RID: 3174
			public string TabIcon;

			// Token: 0x04000C67 RID: 3175
			public bool IsPandoraTab;

			// Token: 0x04000C68 RID: 3176
			public string[] OpenTime;

			// Token: 0x04000C69 RID: 3177
			public uint Level;
		}
	}
}
