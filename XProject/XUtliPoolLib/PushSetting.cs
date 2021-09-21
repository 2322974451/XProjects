using System;

namespace XUtliPoolLib
{
	// Token: 0x02000154 RID: 340
	public class PushSetting : CVSReader
	{
		// Token: 0x060007AE RID: 1966 RVA: 0x00026F70 File Offset: 0x00025170
		protected override void ReadLine(XBinaryReader reader)
		{
			PushSetting.RowData rowData = new PushSetting.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.ConfigName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.TimeOrSystem, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Time, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.WeekDay, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.ConfigKey, CVSReader.stringParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x00027038 File Offset: 0x00025238
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PushSetting.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003A0 RID: 928
		public PushSetting.RowData[] Table = null;

		// Token: 0x02000353 RID: 851
		public class RowData
		{
			// Token: 0x04000D52 RID: 3410
			public uint Type;

			// Token: 0x04000D53 RID: 3411
			public string ConfigName;

			// Token: 0x04000D54 RID: 3412
			public uint TimeOrSystem;

			// Token: 0x04000D55 RID: 3413
			public string Time;

			// Token: 0x04000D56 RID: 3414
			public string WeekDay;

			// Token: 0x04000D57 RID: 3415
			public string ConfigKey;
		}
	}
}
