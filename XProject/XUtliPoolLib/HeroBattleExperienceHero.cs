using System;

namespace XUtliPoolLib
{
	// Token: 0x02000226 RID: 550
	public class HeroBattleExperienceHero : CVSReader
	{
		// Token: 0x06000C48 RID: 3144 RVA: 0x000407F4 File Offset: 0x0003E9F4
		public HeroBattleExperienceHero.RowData GetByItemID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			HeroBattleExperienceHero.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ItemID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000C49 RID: 3145 RVA: 0x00040860 File Offset: 0x0003EA60
		protected override void ReadLine(XBinaryReader reader)
		{
			HeroBattleExperienceHero.RowData rowData = new HeroBattleExperienceHero.RowData();
			base.Read<uint>(reader, ref rowData.ItemID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.HeroID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.LastTime, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.ShowTime, CVSReader.stringParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C4A RID: 3146 RVA: 0x000408F4 File Offset: 0x0003EAF4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new HeroBattleExperienceHero.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000774 RID: 1908
		public HeroBattleExperienceHero.RowData[] Table = null;

		// Token: 0x020003B5 RID: 949
		public class RowData
		{
			// Token: 0x0400109C RID: 4252
			public uint ItemID;

			// Token: 0x0400109D RID: 4253
			public uint HeroID;

			// Token: 0x0400109E RID: 4254
			public uint LastTime;

			// Token: 0x0400109F RID: 4255
			public string ShowTime;
		}
	}
}
