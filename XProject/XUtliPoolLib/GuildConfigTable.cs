using System;

namespace XUtliPoolLib
{
	// Token: 0x0200010C RID: 268
	public class GuildConfigTable : CVSReader
	{
		// Token: 0x060006A4 RID: 1700 RVA: 0x00020520 File Offset: 0x0001E720
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

		// Token: 0x060006A5 RID: 1701 RVA: 0x0002058C File Offset: 0x0001E78C
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

		// Token: 0x060006A6 RID: 1702 RVA: 0x0002081C File Offset: 0x0001EA1C
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

		// Token: 0x04000358 RID: 856
		public GuildConfigTable.RowData[] Table = null;

		// Token: 0x0200030B RID: 779
		public class RowData
		{
			// Token: 0x04000B4F RID: 2895
			public int GuildLevel;

			// Token: 0x04000B50 RID: 2896
			public uint GuildExpNeed;

			// Token: 0x04000B51 RID: 2897
			public int PokerTimes;

			// Token: 0x04000B52 RID: 2898
			public int GuildSign;

			// Token: 0x04000B53 RID: 2899
			public int GuildWelfare;

			// Token: 0x04000B54 RID: 2900
			public int GuildStore;

			// Token: 0x04000B55 RID: 2901
			public int GuildSkill;

			// Token: 0x04000B56 RID: 2902
			public uint GuildDragon;

			// Token: 0x04000B57 RID: 2903
			public int GuildActivity;

			// Token: 0x04000B58 RID: 2904
			public uint StudySkillTimes;

			// Token: 0x04000B59 RID: 2905
			public int GuildArena;

			// Token: 0x04000B5A RID: 2906
			public int GuildChallenge;

			// Token: 0x04000B5B RID: 2907
			public int GuildJokerMatch;

			// Token: 0x04000B5C RID: 2908
			public int GuildSalay;

			// Token: 0x04000B5D RID: 2909
			public int GuildMine;

			// Token: 0x04000B5E RID: 2910
			public int GuildTerritory;

			// Token: 0x04000B5F RID: 2911
			public uint JZSchoolRoleMax;

			// Token: 0x04000B60 RID: 2912
			public uint JZSchoolTotalMax;

			// Token: 0x04000B61 RID: 2913
			public uint JZHallRoleMax;

			// Token: 0x04000B62 RID: 2914
			public uint JZHallTotalmax;

			// Token: 0x04000B63 RID: 2915
			public uint JZSalaryOpen;

			// Token: 0x04000B64 RID: 2916
			public uint JZSaleOpen;

			// Token: 0x04000B65 RID: 2917
			public int CrossGVG;
		}
	}
}
