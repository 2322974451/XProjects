using System;

namespace XUtliPoolLib
{
	// Token: 0x0200021E RID: 542
	public class HeroBattleWeekReward : CVSReader
	{
		// Token: 0x06000C2A RID: 3114 RVA: 0x0003FE4C File Offset: 0x0003E04C
		public HeroBattleWeekReward.RowData GetByid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			HeroBattleWeekReward.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].id == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000C2B RID: 3115 RVA: 0x0003FEB8 File Offset: 0x0003E0B8
		protected override void ReadLine(XBinaryReader reader)
		{
			HeroBattleWeekReward.RowData rowData = new HeroBattleWeekReward.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.winnum, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadArray<uint>(reader, ref rowData.reward, CVSReader.uintParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C2C RID: 3116 RVA: 0x0003FF30 File Offset: 0x0003E130
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new HeroBattleWeekReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400076C RID: 1900
		public HeroBattleWeekReward.RowData[] Table = null;

		// Token: 0x020003AD RID: 941
		public class RowData
		{
			// Token: 0x04001079 RID: 4217
			public uint id;

			// Token: 0x0400107A RID: 4218
			public uint winnum;

			// Token: 0x0400107B RID: 4219
			public uint[] reward;
		}
	}
}
