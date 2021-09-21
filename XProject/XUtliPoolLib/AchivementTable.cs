using System;

namespace XUtliPoolLib
{
	// Token: 0x020000AA RID: 170
	public class AchivementTable : CVSReader
	{
		// Token: 0x0600051F RID: 1311 RVA: 0x000165C8 File Offset: 0x000147C8
		public AchivementTable.RowData GetByAchievementID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			AchivementTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].AchievementID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x00016634 File Offset: 0x00014834
		protected override void ReadLine(XBinaryReader reader)
		{
			AchivementTable.RowData rowData = new AchivementTable.RowData();
			base.Read<int>(reader, ref rowData.AchievementID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.AchievementName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.AchievementIcon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.AchievementLevel, CVSReader.intParse);
			this.columnno = 4;
			rowData.AchievementItem.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.AchievementParam, CVSReader.intParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.AchievementDescription, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.AchievementCategory, CVSReader.intParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.ShowAchivementTip, CVSReader.intParse);
			this.columnno = 11;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x00016748 File Offset: 0x00014948
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new AchivementTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002D0 RID: 720
		public AchivementTable.RowData[] Table = null;

		// Token: 0x020002A8 RID: 680
		public class RowData
		{
			// Token: 0x040008B5 RID: 2229
			public int AchievementID;

			// Token: 0x040008B6 RID: 2230
			public string AchievementName;

			// Token: 0x040008B7 RID: 2231
			public string AchievementIcon;

			// Token: 0x040008B8 RID: 2232
			public int AchievementLevel;

			// Token: 0x040008B9 RID: 2233
			public SeqListRef<int> AchievementItem;

			// Token: 0x040008BA RID: 2234
			public int AchievementParam;

			// Token: 0x040008BB RID: 2235
			public string AchievementDescription;

			// Token: 0x040008BC RID: 2236
			public int AchievementCategory;

			// Token: 0x040008BD RID: 2237
			public int ShowAchivementTip;
		}
	}
}
