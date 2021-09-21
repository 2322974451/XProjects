using System;

namespace XUtliPoolLib
{
	// Token: 0x0200012E RID: 302
	public class OnlineRewardTable : CVSReader
	{
		// Token: 0x0600072A RID: 1834 RVA: 0x00023D28 File Offset: 0x00021F28
		public OnlineRewardTable.RowData GetBytime(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			OnlineRewardTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].time == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x00023D94 File Offset: 0x00021F94
		protected override void ReadLine(XBinaryReader reader)
		{
			OnlineRewardTable.RowData rowData = new OnlineRewardTable.RowData();
			base.Read<uint>(reader, ref rowData.time, CVSReader.uintParse);
			this.columnno = 0;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.RewardTip, CVSReader.stringParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x00023E0C File Offset: 0x0002200C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new OnlineRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400037A RID: 890
		public OnlineRewardTable.RowData[] Table = null;

		// Token: 0x0200032D RID: 813
		public class RowData
		{
			// Token: 0x04000C52 RID: 3154
			public uint time;

			// Token: 0x04000C53 RID: 3155
			public SeqListRef<uint> reward;

			// Token: 0x04000C54 RID: 3156
			public string RewardTip;
		}
	}
}
