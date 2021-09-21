using System;

namespace XUtliPoolLib
{
	// Token: 0x02000104 RID: 260
	public class GuildBossConfigTable : CVSReader
	{
		// Token: 0x06000686 RID: 1670 RVA: 0x0001FBD0 File Offset: 0x0001DDD0
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

		// Token: 0x06000687 RID: 1671 RVA: 0x0001FC08 File Offset: 0x0001DE08
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

		// Token: 0x06000688 RID: 1672 RVA: 0x0001FCE4 File Offset: 0x0001DEE4
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

		// Token: 0x06000689 RID: 1673 RVA: 0x0001FDE0 File Offset: 0x0001DFE0
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

		// Token: 0x04000350 RID: 848
		public GuildBossConfigTable.RowData[] Table = null;

		// Token: 0x02000303 RID: 771
		public class RowData
		{
			// Token: 0x04000B32 RID: 2866
			public uint BossID;

			// Token: 0x04000B33 RID: 2867
			public uint EnemyID;

			// Token: 0x04000B34 RID: 2868
			public float LifePercent;

			// Token: 0x04000B35 RID: 2869
			public string BossName;

			// Token: 0x04000B36 RID: 2870
			public SeqListRef<uint> FirsttKillReward;

			// Token: 0x04000B37 RID: 2871
			public SeqListRef<uint> JoinReward;

			// Token: 0x04000B38 RID: 2872
			public SeqListRef<uint> KillReward;

			// Token: 0x04000B39 RID: 2873
			public string WinCutScene;
		}
	}
}
