using System;

namespace XUtliPoolLib
{
	// Token: 0x0200010E RID: 270
	public class GuildMineralBattle : CVSReader
	{
		// Token: 0x060006AC RID: 1708 RVA: 0x00020984 File Offset: 0x0001EB84
		public GuildMineralBattle.RowData GetByID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildMineralBattle.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchID(key);
			}
			return result;
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x000209BC File Offset: 0x0001EBBC
		private GuildMineralBattle.RowData BinarySearchID(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			GuildMineralBattle.RowData rowData;
			GuildMineralBattle.RowData rowData2;
			GuildMineralBattle.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.ID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.ID == key;
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
				bool flag4 = rowData3.ID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.ID.CompareTo(key) < 0;
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

		// Token: 0x060006AE RID: 1710 RVA: 0x00020A98 File Offset: 0x0001EC98
		protected override void ReadLine(XBinaryReader reader)
		{
			GuildMineralBattle.RowData rowData = new GuildMineralBattle.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Mineralcounts, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.DifficultLevel, CVSReader.intParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.BossID, CVSReader.uintParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x00020B2C File Offset: 0x0001ED2C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildMineralBattle.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400035A RID: 858
		public GuildMineralBattle.RowData[] Table = null;

		// Token: 0x0200030D RID: 781
		public class RowData
		{
			// Token: 0x04000B69 RID: 2921
			public uint ID;

			// Token: 0x04000B6A RID: 2922
			public uint Mineralcounts;

			// Token: 0x04000B6B RID: 2923
			public int DifficultLevel;

			// Token: 0x04000B6C RID: 2924
			public uint BossID;
		}
	}
}
