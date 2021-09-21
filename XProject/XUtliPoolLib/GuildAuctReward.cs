using System;

namespace XUtliPoolLib
{
	// Token: 0x02000102 RID: 258
	public class GuildAuctReward : CVSReader
	{
		// Token: 0x0600067D RID: 1661 RVA: 0x0001F8C4 File Offset: 0x0001DAC4
		public GuildAuctReward.RowData GetByID(short key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildAuctReward.RowData result;
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

		// Token: 0x0600067E RID: 1662 RVA: 0x0001F8FC File Offset: 0x0001DAFC
		private GuildAuctReward.RowData BinarySearchID(short key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			GuildAuctReward.RowData rowData;
			GuildAuctReward.RowData rowData2;
			GuildAuctReward.RowData rowData3;
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

		// Token: 0x0600067F RID: 1663 RVA: 0x0001F9D8 File Offset: 0x0001DBD8
		protected override void ReadLine(XBinaryReader reader)
		{
			GuildAuctReward.RowData rowData = new GuildAuctReward.RowData();
			base.Read<short>(reader, ref rowData.ID, CVSReader.shortParse);
			this.columnno = 0;
			base.Read<byte>(reader, ref rowData.ActType, CVSReader.byteParse);
			this.columnno = 2;
			base.ReadArray<uint>(reader, ref rowData.RewardShow, CVSReader.uintParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x0001FA50 File Offset: 0x0001DC50
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildAuctReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400034E RID: 846
		public GuildAuctReward.RowData[] Table = null;

		// Token: 0x02000301 RID: 769
		public class RowData
		{
			// Token: 0x04000B2B RID: 2859
			public short ID;

			// Token: 0x04000B2C RID: 2860
			public byte ActType;

			// Token: 0x04000B2D RID: 2861
			public uint[] RewardShow;
		}
	}
}
