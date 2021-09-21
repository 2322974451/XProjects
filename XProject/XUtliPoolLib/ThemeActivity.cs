using System;

namespace XUtliPoolLib
{
	// Token: 0x02000248 RID: 584
	public class ThemeActivity : CVSReader
	{
		// Token: 0x06000CC7 RID: 3271 RVA: 0x00043390 File Offset: 0x00041590
		public ThemeActivity.RowData GetBySysID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ThemeActivity.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SysID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000CC8 RID: 3272 RVA: 0x000433FC File Offset: 0x000415FC
		protected override void ReadLine(XBinaryReader reader)
		{
			ThemeActivity.RowData rowData = new ThemeActivity.RowData();
			base.Read<uint>(reader, ref rowData.SysID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.TabName, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.TabIcon, CVSReader.stringParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CC9 RID: 3273 RVA: 0x00043474 File Offset: 0x00041674
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ThemeActivity.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000796 RID: 1942
		public ThemeActivity.RowData[] Table = null;

		// Token: 0x020003D7 RID: 983
		public class RowData
		{
			// Token: 0x0400114C RID: 4428
			public uint SysID;

			// Token: 0x0400114D RID: 4429
			public string TabName;

			// Token: 0x0400114E RID: 4430
			public string TabIcon;
		}
	}
}
