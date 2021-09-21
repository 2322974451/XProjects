using System;

namespace XUtliPoolLib
{
	// Token: 0x020000A9 RID: 169
	public class AchievementV2Table : CVSReader
	{
		// Token: 0x0600051A RID: 1306 RVA: 0x0001635C File Offset: 0x0001455C
		public AchievementV2Table.RowData GetByID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			AchievementV2Table.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchID(key);
			}
			return result;
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x00016394 File Offset: 0x00014594
		private AchievementV2Table.RowData BinarySearchID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			AchievementV2Table.RowData rowData;
			AchievementV2Table.RowData rowData2;
			AchievementV2Table.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.ID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.ID == key;
				if (flag2)
				{
					goto Block_2;
				}
				bool flag3 = num2 - num <= 1;
				if (flag3)
				{
					goto Block_3;
				}
				int num3 = num + (num2 - num) / 2;
				rowData3 = this.Table[num3];
				bool flag4 = rowData3.ID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.ID.CompareTo(key) < 0;
					if (!flag5)
					{
						goto IL_B1;
					}
					num = num3;
				}
				if (num >= num2)
				{
					goto Block_6;
				}
			}
			return rowData;
			Block_2:
			return rowData2;
			Block_3:
			return null;
			IL_B1:
			return rowData3;
			Block_6:
			return null;
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x00016470 File Offset: 0x00014670
		protected override void ReadLine(XBinaryReader reader)
		{
			AchievementV2Table.RowData rowData = new AchievementV2Table.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Achievement, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Explanation, CVSReader.stringParse);
			this.columnno = 3;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.ICON, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.DesignationName, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.GainShowIcon, CVSReader.intParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.SortID, CVSReader.intParse);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x00016588 File Offset: 0x00014788
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new AchievementV2Table.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002CF RID: 719
		public AchievementV2Table.RowData[] Table = null;

		// Token: 0x020002A7 RID: 679
		public class RowData
		{
			// Token: 0x040008AC RID: 2220
			public int ID;

			// Token: 0x040008AD RID: 2221
			public string Achievement;

			// Token: 0x040008AE RID: 2222
			public int Type;

			// Token: 0x040008AF RID: 2223
			public string Explanation;

			// Token: 0x040008B0 RID: 2224
			public SeqListRef<int> Reward;

			// Token: 0x040008B1 RID: 2225
			public string ICON;

			// Token: 0x040008B2 RID: 2226
			public string DesignationName;

			// Token: 0x040008B3 RID: 2227
			public int GainShowIcon;

			// Token: 0x040008B4 RID: 2228
			public int SortID;
		}
	}
}
