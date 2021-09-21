using System;

namespace XUtliPoolLib
{
	// Token: 0x020000D6 RID: 214
	public class DailyTask : CVSReader
	{
		// Token: 0x060005D9 RID: 1497 RVA: 0x0001B090 File Offset: 0x00019290
		public DailyTask.RowData GetBytaskID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			DailyTask.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchtaskID(key);
			}
			return result;
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x0001B0C8 File Offset: 0x000192C8
		private DailyTask.RowData BinarySearchtaskID(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			DailyTask.RowData rowData;
			DailyTask.RowData rowData2;
			DailyTask.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.taskID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.taskID == key;
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
				bool flag4 = rowData3.taskID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.taskID.CompareTo(key) < 0;
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

		// Token: 0x060005DB RID: 1499 RVA: 0x0001B1A4 File Offset: 0x000193A4
		protected override void ReadLine(XBinaryReader reader)
		{
			DailyTask.RowData rowData = new DailyTask.RowData();
			base.Read<uint>(reader, ref rowData.taskID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.taskquality, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.tasktype, CVSReader.uintParse);
			this.columnno = 3;
			base.ReadArray<uint>(reader, ref rowData.conditionId, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.taskdescription, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.conditionNum, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.NPCID, CVSReader.uintParse);
			this.columnno = 7;
			rowData.BQ.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.category, CVSReader.uintParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.score, CVSReader.uintParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.TaskIcon, CVSReader.stringParse);
			this.columnno = 12;
			base.Read<string>(reader, ref rowData.AtlasName, CVSReader.stringParse);
			this.columnno = 13;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x0001B30C File Offset: 0x0001950C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DailyTask.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000322 RID: 802
		public DailyTask.RowData[] Table = null;

		// Token: 0x020002D5 RID: 725
		public class RowData
		{
			// Token: 0x040009B8 RID: 2488
			public uint taskID;

			// Token: 0x040009B9 RID: 2489
			public uint taskquality;

			// Token: 0x040009BA RID: 2490
			public uint tasktype;

			// Token: 0x040009BB RID: 2491
			public uint[] conditionId;

			// Token: 0x040009BC RID: 2492
			public string taskdescription;

			// Token: 0x040009BD RID: 2493
			public uint conditionNum;

			// Token: 0x040009BE RID: 2494
			public uint NPCID;

			// Token: 0x040009BF RID: 2495
			public SeqListRef<uint> BQ;

			// Token: 0x040009C0 RID: 2496
			public uint category;

			// Token: 0x040009C1 RID: 2497
			public uint score;

			// Token: 0x040009C2 RID: 2498
			public string TaskIcon;

			// Token: 0x040009C3 RID: 2499
			public string AtlasName;
		}
	}
}
