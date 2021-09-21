using System;

namespace XUtliPoolLib
{
	// Token: 0x02000127 RID: 295
	public class LevelSealTypeTable : CVSReader
	{
		// Token: 0x0600070D RID: 1805 RVA: 0x000231D4 File Offset: 0x000213D4
		public LevelSealTypeTable.RowData GetByType(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			LevelSealTypeTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].Type == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x00023240 File Offset: 0x00021440
		protected override void ReadLine(XBinaryReader reader)
		{
			LevelSealTypeTable.RowData rowData = new LevelSealTypeTable.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.Time, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.UnlockBossName, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.UnlockBossCount, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.NowSealImage, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.NextSealImageL, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.NextSealImageR, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.NextSealImageBig, CVSReader.stringParse);
			this.columnno = 9;
			rowData.ExchangeInfo.Read(reader, this.m_DataHandler);
			this.columnno = 13;
			rowData.CollectAward.Read(reader, this.m_DataHandler);
			this.columnno = 14;
			rowData.PlayerAward.Read(reader, this.m_DataHandler);
			this.columnno = 16;
			base.Read<int>(reader, ref rowData.ApplyStudentLevel, CVSReader.intParse);
			this.columnno = 19;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x000233C0 File Offset: 0x000215C0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new LevelSealTypeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000373 RID: 883
		public LevelSealTypeTable.RowData[] Table = null;

		// Token: 0x02000326 RID: 806
		public class RowData
		{
			// Token: 0x04000C23 RID: 3107
			public uint Type;

			// Token: 0x04000C24 RID: 3108
			public uint Level;

			// Token: 0x04000C25 RID: 3109
			public uint Time;

			// Token: 0x04000C26 RID: 3110
			public string UnlockBossName;

			// Token: 0x04000C27 RID: 3111
			public uint UnlockBossCount;

			// Token: 0x04000C28 RID: 3112
			public string NowSealImage;

			// Token: 0x04000C29 RID: 3113
			public string NextSealImageL;

			// Token: 0x04000C2A RID: 3114
			public string NextSealImageR;

			// Token: 0x04000C2B RID: 3115
			public string NextSealImageBig;

			// Token: 0x04000C2C RID: 3116
			public SeqRef<uint> ExchangeInfo;

			// Token: 0x04000C2D RID: 3117
			public SeqListRef<uint> CollectAward;

			// Token: 0x04000C2E RID: 3118
			public SeqListRef<uint> PlayerAward;

			// Token: 0x04000C2F RID: 3119
			public int ApplyStudentLevel;
		}
	}
}
