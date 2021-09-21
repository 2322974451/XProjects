using System;

namespace XUtliPoolLib
{
	// Token: 0x020000A8 RID: 168
	public class AchievementPointRewardTable : CVSReader
	{
		// Token: 0x06000516 RID: 1302 RVA: 0x00016238 File Offset: 0x00014438
		public AchievementPointRewardTable.RowData GetByID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			AchievementPointRewardTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x000162A4 File Offset: 0x000144A4
		protected override void ReadLine(XBinaryReader reader)
		{
			AchievementPointRewardTable.RowData rowData = new AchievementPointRewardTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Point, CVSReader.intParse);
			this.columnno = 1;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x0001631C File Offset: 0x0001451C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new AchievementPointRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002CE RID: 718
		public AchievementPointRewardTable.RowData[] Table = null;

		// Token: 0x020002A6 RID: 678
		public class RowData
		{
			// Token: 0x040008A9 RID: 2217
			public int ID;

			// Token: 0x040008AA RID: 2218
			public int Point;

			// Token: 0x040008AB RID: 2219
			public SeqListRef<int> Reward;
		}
	}
}
