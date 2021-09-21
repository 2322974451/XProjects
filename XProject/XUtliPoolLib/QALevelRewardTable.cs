using System;

namespace XUtliPoolLib
{
	// Token: 0x0200015A RID: 346
	public class QALevelRewardTable : CVSReader
	{
		// Token: 0x060007C5 RID: 1989 RVA: 0x00027620 File Offset: 0x00025820
		public QALevelRewardTable.RowData GetByID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			QALevelRewardTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x0002768C File Offset: 0x0002588C
		protected override void ReadLine(XBinaryReader reader)
		{
			QALevelRewardTable.RowData rowData = new QALevelRewardTable.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.QAType, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.MinLevel, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.MaxLevel, CVSReader.uintParse);
			this.columnno = 3;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.ExtraReward.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x00027754 File Offset: 0x00025954
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new QALevelRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003A6 RID: 934
		public QALevelRewardTable.RowData[] Table = null;

		// Token: 0x02000359 RID: 857
		public class RowData
		{
			// Token: 0x04000D64 RID: 3428
			public uint ID;

			// Token: 0x04000D65 RID: 3429
			public uint QAType;

			// Token: 0x04000D66 RID: 3430
			public uint MinLevel;

			// Token: 0x04000D67 RID: 3431
			public uint MaxLevel;

			// Token: 0x04000D68 RID: 3432
			public SeqListRef<uint> Reward;

			// Token: 0x04000D69 RID: 3433
			public SeqListRef<uint> ExtraReward;
		}
	}
}
