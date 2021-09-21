using System;

namespace XUtliPoolLib
{
	// Token: 0x02000128 RID: 296
	public class LiveTable : CVSReader
	{
		// Token: 0x06000711 RID: 1809 RVA: 0x00023400 File Offset: 0x00021600
		public LiveTable.RowData GetBySceneType(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			LiveTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SceneType == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x0002346C File Offset: 0x0002166C
		protected override void ReadLine(XBinaryReader reader)
		{
			LiveTable.RowData rowData = new LiveTable.RowData();
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.SceneType, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.ShowWatch, CVSReader.intParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.ShowPraise, CVSReader.intParse);
			this.columnno = 8;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x00023500 File Offset: 0x00021700
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new LiveTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000374 RID: 884
		public LiveTable.RowData[] Table = null;

		// Token: 0x02000327 RID: 807
		public class RowData
		{
			// Token: 0x04000C30 RID: 3120
			public int Type;

			// Token: 0x04000C31 RID: 3121
			public int SceneType;

			// Token: 0x04000C32 RID: 3122
			public int ShowWatch;

			// Token: 0x04000C33 RID: 3123
			public int ShowPraise;
		}
	}
}
