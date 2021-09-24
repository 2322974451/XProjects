using System;

namespace XUtliPoolLib
{

	public class ExpeditionTable : CVSReader
	{

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

		public ExpeditionTable.RowData[] Table = null;

		public class RowData
		{

			public int DNExpeditionID;

			public string DNExpeditionName;

			public uint[] ViewableDropList;

			public int RequiredLevel;

			public int PlayerNumber;

			public uint[] RandomSceneIDs;

			public int GuildLevel;

			public int Type;

			public int PlayerLeastNumber;

			public int Category;

			public uint DisplayLevel;

			public uint DisplayPPT;

			public int fastmatch;

			public int FMARobotTime;

			public SeqListRef<int> CostItem;

			public uint LevelSealType;

			public int CanHelp;

			public int AutoSelectPriority;

			public SeqListRef<uint> CostType;

			public int CostCountType;

			public SeqRef<uint> ServerOpenTime;

			public int SortID;

			public SeqRef<uint> UseTicket;

			public SeqRef<uint> Stars;

			public bool isCrossServerInvite;

			public bool ShowPPT;
		}
	}
}
