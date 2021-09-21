using System;

namespace XUtliPoolLib
{
	// Token: 0x02000234 RID: 564
	public class MobaWeekReward : CVSReader
	{
		// Token: 0x06000C7C RID: 3196 RVA: 0x00041A8C File Offset: 0x0003FC8C
		public MobaWeekReward.RowData GetByid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			MobaWeekReward.RowData result;
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

		// Token: 0x06000C7D RID: 3197 RVA: 0x00041AF8 File Offset: 0x0003FCF8
		protected override void ReadLine(XBinaryReader reader)
		{
			MobaWeekReward.RowData rowData = new MobaWeekReward.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.winnum, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadArray<uint>(reader, ref rowData.reward, CVSReader.uintParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C7E RID: 3198 RVA: 0x00041B70 File Offset: 0x0003FD70
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new MobaWeekReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000782 RID: 1922
		public MobaWeekReward.RowData[] Table = null;

		// Token: 0x020003C3 RID: 963
		public class RowData
		{
			// Token: 0x040010F0 RID: 4336
			public uint id;

			// Token: 0x040010F1 RID: 4337
			public uint winnum;

			// Token: 0x040010F2 RID: 4338
			public uint[] reward;
		}
	}
}
