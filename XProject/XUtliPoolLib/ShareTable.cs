using System;

namespace XUtliPoolLib
{
	// Token: 0x0200021A RID: 538
	public class ShareTable : CVSReader
	{
		// Token: 0x06000C1C RID: 3100 RVA: 0x0003F970 File Offset: 0x0003DB70
		public ShareTable.RowData GetByCondition(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ShareTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].Condition == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000C1D RID: 3101 RVA: 0x0003F9DC File Offset: 0x0003DBDC
		protected override void ReadLine(XBinaryReader reader)
		{
			ShareTable.RowData rowData = new ShareTable.RowData();
			base.Read<int>(reader, ref rowData.Condition, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Title, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Link, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.type, CVSReader.uintParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C1E RID: 3102 RVA: 0x0003FAA4 File Offset: 0x0003DCA4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ShareTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000768 RID: 1896
		public ShareTable.RowData[] Table = null;

		// Token: 0x020003A9 RID: 937
		public class RowData
		{
			// Token: 0x04001062 RID: 4194
			public int Condition;

			// Token: 0x04001063 RID: 4195
			public string Desc;

			// Token: 0x04001064 RID: 4196
			public string Title;

			// Token: 0x04001065 RID: 4197
			public string Icon;

			// Token: 0x04001066 RID: 4198
			public string Link;

			// Token: 0x04001067 RID: 4199
			public uint type;
		}
	}
}
