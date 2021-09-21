using System;

namespace XUtliPoolLib
{
	// Token: 0x02000247 RID: 583
	public class TaJieHelpUrl : CVSReader
	{
		// Token: 0x06000CC3 RID: 3267 RVA: 0x0004326C File Offset: 0x0004146C
		public TaJieHelpUrl.RowData GetBySceneId(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			TaJieHelpUrl.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SceneId == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000CC4 RID: 3268 RVA: 0x000432D8 File Offset: 0x000414D8
		protected override void ReadLine(XBinaryReader reader)
		{
			TaJieHelpUrl.RowData rowData = new TaJieHelpUrl.RowData();
			base.Read<uint>(reader, ref rowData.SceneId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Url, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CC5 RID: 3269 RVA: 0x00043350 File Offset: 0x00041550
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new TaJieHelpUrl.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000795 RID: 1941
		public TaJieHelpUrl.RowData[] Table = null;

		// Token: 0x020003D6 RID: 982
		public class RowData
		{
			// Token: 0x04001149 RID: 4425
			public uint SceneId;

			// Token: 0x0400114A RID: 4426
			public string Url;

			// Token: 0x0400114B RID: 4427
			public string Name;
		}
	}
}
