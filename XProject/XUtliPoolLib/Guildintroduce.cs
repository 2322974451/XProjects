using System;

namespace XUtliPoolLib
{
	// Token: 0x0200010D RID: 269
	public class Guildintroduce : CVSReader
	{
		// Token: 0x060006A8 RID: 1704 RVA: 0x0002085C File Offset: 0x0001EA5C
		public Guildintroduce.RowData GetByHelpName(string key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			Guildintroduce.RowData result;
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

		// Token: 0x060006A9 RID: 1705 RVA: 0x000208CC File Offset: 0x0001EACC
		protected override void ReadLine(XBinaryReader reader)
		{
			Guildintroduce.RowData rowData = new Guildintroduce.RowData();
			base.Read<string>(reader, ref rowData.HelpName, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Title, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x00020944 File Offset: 0x0001EB44
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new Guildintroduce.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000359 RID: 857
		public Guildintroduce.RowData[] Table = null;

		// Token: 0x0200030C RID: 780
		public class RowData
		{
			// Token: 0x04000B66 RID: 2918
			public string HelpName;

			// Token: 0x04000B67 RID: 2919
			public string Title;

			// Token: 0x04000B68 RID: 2920
			public string Desc;
		}
	}
}
