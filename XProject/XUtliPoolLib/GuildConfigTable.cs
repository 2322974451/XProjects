using System;

namespace XUtliPoolLib
{

	public class GuildConfigTable : CVSReader
	{

		public GuildConfigTable.RowData GetByGuildLevel(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildConfigTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].GuildLevel == key;
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
			GuildConfigTable.RowData rowData = new GuildConfigTable.RowData();
			base.Read<int>(reader, ref rowData.GuildLevel, CVSReader.intParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.GuildExpNeed, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.PokerTimes, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.GuildSign, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.GuildWelfare, CVSReader.intParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.GuildStore, CVSReader.intParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.GuildSkill, CVSReader.intParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.GuildDragon, CVSReader.uintParse);
			this.columnno = 13;
			base.Read<int>(reader, ref rowData.GuildActivity, CVSReader.intParse);
			this.columnno = 15;
			base.Read<uint>(reader, ref rowData.StudySkillTimes, CVSReader.uintParse);
			this.columnno = 21;
			base.Read<int>(reader, ref rowData.GuildArena, CVSReader.intParse);
			this.columnno = 23;
			base.Read<int>(reader, ref rowData.GuildChallenge, CVSReader.intParse);
			this.columnno = 26;
			base.Read<int>(reader, ref rowData.GuildJokerMatch, CVSReader.intParse);
			this.columnno = 27;
			base.Read<int>(reader, ref rowData.GuildSalay, CVSReader.intParse);
			this.columnno = 28;
			base.Read<int>(reader, ref rowData.GuildMine, CVSReader.intParse);
			this.columnno = 29;
			base.Read<int>(reader, ref rowData.GuildTerritory, CVSReader.intParse);
			this.columnno = 30;
			base.Read<uint>(reader, ref rowData.JZSchoolRoleMax, CVSReader.uintParse);
			this.columnno = 31;
			base.Read<uint>(reader, ref rowData.JZSchoolTotalMax, CVSReader.uintParse);
			this.columnno = 32;
			base.Read<uint>(reader, ref rowData.JZHallRoleMax, CVSReader.uintParse);
			this.columnno = 33;
			base.Read<uint>(reader, ref rowData.JZHallTotalmax, CVSReader.uintParse);
			this.columnno = 34;
			base.Read<uint>(reader, ref rowData.JZSalaryOpen, CVSReader.uintParse);
			this.columnno = 35;
			base.Read<uint>(reader, ref rowData.JZSaleOpen, CVSReader.uintParse);
			this.columnno = 36;
			base.Read<int>(reader, ref rowData.CrossGVG, CVSReader.intParse);
			this.columnno = 37;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildConfigTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildConfigTable.RowData[] Table = null;

		public class RowData
		{

			public int GuildLevel;

			public uint GuildExpNeed;

			public int PokerTimes;

			public int GuildSign;

			public int GuildWelfare;

			public int GuildStore;

			public int GuildSkill;

			public uint GuildDragon;

			public int GuildActivity;

			public uint StudySkillTimes;

			public int GuildArena;

			public int GuildChallenge;

			public int GuildJokerMatch;

			public int GuildSalay;

			public int GuildMine;

			public int GuildTerritory;

			public uint JZSchoolRoleMax;

			public uint JZSchoolTotalMax;

			public uint JZHallRoleMax;

			public uint JZHallTotalmax;

			public uint JZSalaryOpen;

			public uint JZSaleOpen;

			public int CrossGVG;
		}
	}
}
