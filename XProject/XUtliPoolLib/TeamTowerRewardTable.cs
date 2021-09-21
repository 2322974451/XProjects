using System;

namespace XUtliPoolLib
{
	// Token: 0x0200017D RID: 381
	public class TeamTowerRewardTable : CVSReader
	{
		// Token: 0x0600084E RID: 2126 RVA: 0x0002BAF0 File Offset: 0x00029CF0
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

		// Token: 0x0600084F RID: 2127 RVA: 0x0002BBEC File Offset: 0x00029DEC
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

		// Token: 0x040003C9 RID: 969
		public TeamTowerRewardTable.RowData[] Table = null;

		// Token: 0x0200037C RID: 892
		public class RowData
		{
			// Token: 0x04000EDA RID: 3802
			public int TowerHardLevel;

			// Token: 0x04000EDB RID: 3803
			public int TowerFloor;

			// Token: 0x04000EDC RID: 3804
			public SeqListRef<int> Reward;

			// Token: 0x04000EDD RID: 3805
			public string Name;

			// Token: 0x04000EDE RID: 3806
			public int DragonCoinFindBackCost;

			// Token: 0x04000EDF RID: 3807
			public int SceneID;

			// Token: 0x04000EE0 RID: 3808
			public SeqListRef<int> FirstPassReward;

			// Token: 0x04000EE1 RID: 3809
			public int preward;
		}
	}
}
