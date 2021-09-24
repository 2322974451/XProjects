using System;

namespace XUtliPoolLib
{

	public class AchivementTable : CVSReader
	{

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

		public AchivementTable.RowData[] Table = null;

		public class RowData
		{

			public int AchievementID;

			public string AchievementName;

			public string AchievementIcon;

			public int AchievementLevel;

			public SeqListRef<int> AchievementItem;

			public int AchievementParam;

			public string AchievementDescription;

			public int AchievementCategory;

			public int ShowAchivementTip;
		}
	}
}
