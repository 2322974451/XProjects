using System;

namespace XUtliPoolLib
{
	// Token: 0x020000B7 RID: 183
	public class BossRushBuffTable : CVSReader
	{
		// Token: 0x06000550 RID: 1360 RVA: 0x00017970 File Offset: 0x00015B70
		public BossRushBuffTable.RowData GetByBossRushBuffID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			BossRushBuffTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].BossRushBuffID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x000179DC File Offset: 0x00015BDC
		protected override void ReadLine(XBinaryReader reader)
		{
			BossRushBuffTable.RowData rowData = new BossRushBuffTable.RowData();
			base.Read<int>(reader, ref rowData.BossRushBuffID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<float>(reader, ref rowData.RewardBuff, CVSReader.floatParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.Quality, CVSReader.intParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Comment, CVSReader.stringParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x00017A88 File Offset: 0x00015C88
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new BossRushBuffTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002DD RID: 733
		public BossRushBuffTable.RowData[] Table = null;

		// Token: 0x020002B5 RID: 693
		public class RowData
		{
			// Token: 0x04000915 RID: 2325
			public int BossRushBuffID;

			// Token: 0x04000916 RID: 2326
			public float RewardBuff;

			// Token: 0x04000917 RID: 2327
			public string icon;

			// Token: 0x04000918 RID: 2328
			public int Quality;

			// Token: 0x04000919 RID: 2329
			public string Comment;
		}
	}
}
