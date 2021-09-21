using System;

namespace XUtliPoolLib
{
	// Token: 0x020000D7 RID: 215
	public class DailyTaskReward : CVSReader
	{
		// Token: 0x060005DE RID: 1502 RVA: 0x0001B34C File Offset: 0x0001954C
		protected override void ReadLine(XBinaryReader reader)
		{
			DailyTaskReward.RowData rowData = new DailyTaskReward.RowData();
			rowData.level.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.tasktype, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.taskquality, CVSReader.uintParse);
			this.columnno = 2;
			rowData.taskreward.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			rowData.extrareward_s.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.category, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.score, CVSReader.uintParse);
			this.columnno = 7;
			rowData.reward_s.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			rowData.reward_a.Read(reader, this.m_DataHandler);
			this.columnno = 9;
			rowData.reward_b.Read(reader, this.m_DataHandler);
			this.columnno = 10;
			rowData.reward_c.Read(reader, this.m_DataHandler);
			this.columnno = 11;
			rowData.reward_d.Read(reader, this.m_DataHandler);
			this.columnno = 12;
			rowData.extrareward_a.Read(reader, this.m_DataHandler);
			this.columnno = 13;
			rowData.extrareward_b.Read(reader, this.m_DataHandler);
			this.columnno = 14;
			rowData.extrareward_c.Read(reader, this.m_DataHandler);
			this.columnno = 15;
			rowData.extrareward_d.Read(reader, this.m_DataHandler);
			this.columnno = 16;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x0001B520 File Offset: 0x00019720
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DailyTaskReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000323 RID: 803
		public DailyTaskReward.RowData[] Table = null;

		// Token: 0x020002D6 RID: 726
		public class RowData
		{
			// Token: 0x040009C4 RID: 2500
			public SeqRef<uint> level;

			// Token: 0x040009C5 RID: 2501
			public uint tasktype;

			// Token: 0x040009C6 RID: 2502
			public uint taskquality;

			// Token: 0x040009C7 RID: 2503
			public SeqListRef<uint> taskreward;

			// Token: 0x040009C8 RID: 2504
			public SeqListRef<uint> extrareward_s;

			// Token: 0x040009C9 RID: 2505
			public uint category;

			// Token: 0x040009CA RID: 2506
			public uint score;

			// Token: 0x040009CB RID: 2507
			public SeqListRef<uint> reward_s;

			// Token: 0x040009CC RID: 2508
			public SeqListRef<uint> reward_a;

			// Token: 0x040009CD RID: 2509
			public SeqListRef<uint> reward_b;

			// Token: 0x040009CE RID: 2510
			public SeqListRef<uint> reward_c;

			// Token: 0x040009CF RID: 2511
			public SeqListRef<uint> reward_d;

			// Token: 0x040009D0 RID: 2512
			public SeqListRef<uint> extrareward_a;

			// Token: 0x040009D1 RID: 2513
			public SeqListRef<uint> extrareward_b;

			// Token: 0x040009D2 RID: 2514
			public SeqListRef<uint> extrareward_c;

			// Token: 0x040009D3 RID: 2515
			public SeqListRef<uint> extrareward_d;
		}
	}
}
