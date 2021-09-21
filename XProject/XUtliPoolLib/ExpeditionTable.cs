using System;

namespace XUtliPoolLib
{
	// Token: 0x020000E8 RID: 232
	public class ExpeditionTable : CVSReader
	{
		// Token: 0x06000620 RID: 1568 RVA: 0x0001D554 File Offset: 0x0001B754
		public ExpeditionTable.RowData GetByDNExpeditionID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ExpeditionTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchDNExpeditionID(key);
			}
			return result;
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x0001D58C File Offset: 0x0001B78C
		private ExpeditionTable.RowData BinarySearchDNExpeditionID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			ExpeditionTable.RowData rowData;
			ExpeditionTable.RowData rowData2;
			ExpeditionTable.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.DNExpeditionID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.DNExpeditionID == key;
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
				bool flag4 = rowData3.DNExpeditionID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.DNExpeditionID.CompareTo(key) < 0;
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

		// Token: 0x06000622 RID: 1570 RVA: 0x0001D668 File Offset: 0x0001B868
		protected override void ReadLine(XBinaryReader reader)
		{
			ExpeditionTable.RowData rowData = new ExpeditionTable.RowData();
			base.Read<int>(reader, ref rowData.DNExpeditionID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.DNExpeditionName, CVSReader.stringParse);
			this.columnno = 1;
			base.ReadArray<uint>(reader, ref rowData.ViewableDropList, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.RequiredLevel, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.PlayerNumber, CVSReader.intParse);
			this.columnno = 4;
			base.ReadArray<uint>(reader, ref rowData.RandomSceneIDs, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.GuildLevel, CVSReader.intParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.PlayerLeastNumber, CVSReader.intParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.Category, CVSReader.intParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.DisplayLevel, CVSReader.uintParse);
			this.columnno = 12;
			base.Read<uint>(reader, ref rowData.DisplayPPT, CVSReader.uintParse);
			this.columnno = 13;
			base.Read<int>(reader, ref rowData.fastmatch, CVSReader.intParse);
			this.columnno = 15;
			base.Read<int>(reader, ref rowData.FMARobotTime, CVSReader.intParse);
			this.columnno = 16;
			rowData.CostItem.Read(reader, this.m_DataHandler);
			this.columnno = 17;
			base.Read<uint>(reader, ref rowData.LevelSealType, CVSReader.uintParse);
			this.columnno = 18;
			base.Read<int>(reader, ref rowData.CanHelp, CVSReader.intParse);
			this.columnno = 19;
			base.Read<int>(reader, ref rowData.AutoSelectPriority, CVSReader.intParse);
			this.columnno = 21;
			rowData.CostType.Read(reader, this.m_DataHandler);
			this.columnno = 23;
			base.Read<int>(reader, ref rowData.CostCountType, CVSReader.intParse);
			this.columnno = 24;
			rowData.ServerOpenTime.Read(reader, this.m_DataHandler);
			this.columnno = 27;
			base.Read<int>(reader, ref rowData.SortID, CVSReader.intParse);
			this.columnno = 29;
			rowData.UseTicket.Read(reader, this.m_DataHandler);
			this.columnno = 30;
			rowData.Stars.Read(reader, this.m_DataHandler);
			this.columnno = 31;
			base.Read<bool>(reader, ref rowData.isCrossServerInvite, CVSReader.boolParse);
			this.columnno = 32;
			base.Read<bool>(reader, ref rowData.ShowPPT, CVSReader.boolParse);
			this.columnno = 38;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x0001D948 File Offset: 0x0001BB48
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ExpeditionTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000334 RID: 820
		public ExpeditionTable.RowData[] Table = null;

		// Token: 0x020002E7 RID: 743
		public class RowData
		{
			// Token: 0x04000A7E RID: 2686
			public int DNExpeditionID;

			// Token: 0x04000A7F RID: 2687
			public string DNExpeditionName;

			// Token: 0x04000A80 RID: 2688
			public uint[] ViewableDropList;

			// Token: 0x04000A81 RID: 2689
			public int RequiredLevel;

			// Token: 0x04000A82 RID: 2690
			public int PlayerNumber;

			// Token: 0x04000A83 RID: 2691
			public uint[] RandomSceneIDs;

			// Token: 0x04000A84 RID: 2692
			public int GuildLevel;

			// Token: 0x04000A85 RID: 2693
			public int Type;

			// Token: 0x04000A86 RID: 2694
			public int PlayerLeastNumber;

			// Token: 0x04000A87 RID: 2695
			public int Category;

			// Token: 0x04000A88 RID: 2696
			public uint DisplayLevel;

			// Token: 0x04000A89 RID: 2697
			public uint DisplayPPT;

			// Token: 0x04000A8A RID: 2698
			public int fastmatch;

			// Token: 0x04000A8B RID: 2699
			public int FMARobotTime;

			// Token: 0x04000A8C RID: 2700
			public SeqListRef<int> CostItem;

			// Token: 0x04000A8D RID: 2701
			public uint LevelSealType;

			// Token: 0x04000A8E RID: 2702
			public int CanHelp;

			// Token: 0x04000A8F RID: 2703
			public int AutoSelectPriority;

			// Token: 0x04000A90 RID: 2704
			public SeqListRef<uint> CostType;

			// Token: 0x04000A91 RID: 2705
			public int CostCountType;

			// Token: 0x04000A92 RID: 2706
			public SeqRef<uint> ServerOpenTime;

			// Token: 0x04000A93 RID: 2707
			public int SortID;

			// Token: 0x04000A94 RID: 2708
			public SeqRef<uint> UseTicket;

			// Token: 0x04000A95 RID: 2709
			public SeqRef<uint> Stars;

			// Token: 0x04000A96 RID: 2710
			public bool isCrossServerInvite;

			// Token: 0x04000A97 RID: 2711
			public bool ShowPPT;
		}
	}
}
