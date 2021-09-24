using System;

namespace XUtliPoolLib
{

	public class TeamTowerRewardTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			TeamTowerRewardTable.RowData rowData = new TeamTowerRewardTable.RowData();
			base.Read<int>(reader, ref rowData.TowerHardLevel, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.TowerFloor, CVSReader.intParse);
			this.columnno = 1;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.DragonCoinFindBackCost, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.SceneID, CVSReader.intParse);
			this.columnno = 7;
			rowData.FirstPassReward.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.preward, CVSReader.intParse);
			this.columnno = 9;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new TeamTowerRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public TeamTowerRewardTable.RowData[] Table = null;

		public class RowData
		{

			public int TowerHardLevel;

			public int TowerFloor;

			public SeqListRef<int> Reward;

			public string Name;

			public int DragonCoinFindBackCost;

			public int SceneID;

			public SeqListRef<int> FirstPassReward;

			public int preward;
		}
	}
}
