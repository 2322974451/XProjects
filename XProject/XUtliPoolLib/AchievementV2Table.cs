using System;

namespace XUtliPoolLib
{

	public class AchievementV2Table : CVSReader
	{

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

		public AchievementV2Table.RowData[] Table = null;

		public class RowData
		{

			public int ID;

			public string Achievement;

			public int Type;

			public string Explanation;

			public SeqListRef<int> Reward;

			public string ICON;

			public string DesignationName;

			public int GainShowIcon;

			public int SortID;
		}
	}
}
