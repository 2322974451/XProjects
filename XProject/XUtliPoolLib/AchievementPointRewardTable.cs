using System;

namespace XUtliPoolLib
{

	public class AchievementPointRewardTable : CVSReader
	{

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

		public AchievementPointRewardTable.RowData[] Table = null;

		public class RowData
		{

			public int ID;

			public int Point;

			public SeqListRef<int> Reward;
		}
	}
}
