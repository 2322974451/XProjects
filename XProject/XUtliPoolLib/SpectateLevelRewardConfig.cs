using System;

namespace XUtliPoolLib
{
	// Token: 0x0200016E RID: 366
	public class SpectateLevelRewardConfig : CVSReader
	{
		// Token: 0x06000813 RID: 2067 RVA: 0x0002A14C File Offset: 0x0002834C
		public SpectateLevelRewardConfig.RowData GetBySceneType(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			SpectateLevelRewardConfig.RowData result;
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

		// Token: 0x06000814 RID: 2068 RVA: 0x0002A1B8 File Offset: 0x000283B8
		protected override void ReadLine(XBinaryReader reader)
		{
			SpectateLevelRewardConfig.RowData rowData = new SpectateLevelRewardConfig.RowData();
			base.Read<int>(reader, ref rowData.SceneType, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<int>(reader, ref rowData.DataConfig, CVSReader.intParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x0002A218 File Offset: 0x00028418
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SpectateLevelRewardConfig.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003BA RID: 954
		public SpectateLevelRewardConfig.RowData[] Table = null;

		// Token: 0x0200036D RID: 877
		public class RowData
		{
			// Token: 0x04000E5F RID: 3679
			public int SceneType;

			// Token: 0x04000E60 RID: 3680
			public int[] DataConfig;
		}
	}
}
