using System;

namespace XUtliPoolLib
{

	public class GuildBossConfigTable : CVSReader
	{

		public GuildBossConfigTable.RowData GetByBossID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildBossConfigTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchBossID(key);
			}
			return result;
		}

		private GuildBossConfigTable.RowData BinarySearchBossID(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			GuildBossConfigTable.RowData rowData;
			GuildBossConfigTable.RowData rowData2;
			GuildBossConfigTable.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.BossID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.BossID == key;
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
				bool flag4 = rowData3.BossID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.BossID.CompareTo(key) < 0;
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
			GuildBossConfigTable.RowData rowData = new GuildBossConfigTable.RowData();
			base.Read<uint>(reader, ref rowData.BossID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.EnemyID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<float>(reader, ref rowData.LifePercent, CVSReader.floatParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.BossName, CVSReader.stringParse);
			this.columnno = 5;
			rowData.FirsttKillReward.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			rowData.JoinReward.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			rowData.KillReward.Read(reader, this.m_DataHandler);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.WinCutScene, CVSReader.stringParse);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildBossConfigTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildBossConfigTable.RowData[] Table = null;

		public class RowData
		{

			public uint BossID;

			public uint EnemyID;

			public float LifePercent;

			public string BossName;

			public SeqListRef<uint> FirsttKillReward;

			public SeqListRef<uint> JoinReward;

			public SeqListRef<uint> KillReward;

			public string WinCutScene;
		}
	}
}
