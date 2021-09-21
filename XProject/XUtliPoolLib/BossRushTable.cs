using System;

namespace XUtliPoolLib
{
	// Token: 0x020000B8 RID: 184
	public class BossRushTable : CVSReader
	{
		// Token: 0x06000554 RID: 1364 RVA: 0x00017AC8 File Offset: 0x00015CC8
		public BossRushTable.RowData GetByqniqueid(short key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			BossRushTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchqniqueid(key);
			}
			return result;
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x00017B00 File Offset: 0x00015D00
		private BossRushTable.RowData BinarySearchqniqueid(short key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			BossRushTable.RowData rowData;
			BossRushTable.RowData rowData2;
			BossRushTable.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.qniqueid == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.qniqueid == key;
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
				bool flag4 = rowData3.qniqueid.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.qniqueid.CompareTo(key) < 0;
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

		// Token: 0x06000556 RID: 1366 RVA: 0x00017BDC File Offset: 0x00015DDC
		protected override void ReadLine(XBinaryReader reader)
		{
			BossRushTable.RowData rowData = new BossRushTable.RowData();
			base.Read<int>(reader, ref rowData.bossid, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<byte>(reader, ref rowData.bossdifficult, CVSReader.byteParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.bosstip, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<short>(reader, ref rowData.qniqueid, CVSReader.shortParse);
			this.columnno = 10;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 12;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x00017C8C File Offset: 0x00015E8C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new BossRushTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002DE RID: 734
		public BossRushTable.RowData[] Table = null;

		// Token: 0x020002B6 RID: 694
		public class RowData
		{
			// Token: 0x0400091A RID: 2330
			public int bossid;

			// Token: 0x0400091B RID: 2331
			public byte[] bossdifficult;

			// Token: 0x0400091C RID: 2332
			public string bosstip;

			// Token: 0x0400091D RID: 2333
			public short qniqueid;

			// Token: 0x0400091E RID: 2334
			public SeqListRef<uint> reward;
		}
	}
}
