using System;

namespace XUtliPoolLib
{
	// Token: 0x0200024E RID: 590
	public class DragonGuildIntroduce : CVSReader
	{
		// Token: 0x06000CDC RID: 3292 RVA: 0x000439F8 File Offset: 0x00041BF8
		public DragonGuildIntroduce.RowData GetByHelpName(string key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			DragonGuildIntroduce.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].HelpName == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000CDD RID: 3293 RVA: 0x00043A68 File Offset: 0x00041C68
		protected override void ReadLine(XBinaryReader reader)
		{
			DragonGuildIntroduce.RowData rowData = new DragonGuildIntroduce.RowData();
			base.Read<string>(reader, ref rowData.HelpName, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Logo, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Title, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CDE RID: 3294 RVA: 0x00043AFC File Offset: 0x00041CFC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DragonGuildIntroduce.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400079C RID: 1948
		public DragonGuildIntroduce.RowData[] Table = null;

		// Token: 0x020003DD RID: 989
		public class RowData
		{
			// Token: 0x04001166 RID: 4454
			public string HelpName;

			// Token: 0x04001167 RID: 4455
			public string Logo;

			// Token: 0x04001168 RID: 4456
			public string Title;

			// Token: 0x04001169 RID: 4457
			public string Desc;
		}
	}
}
