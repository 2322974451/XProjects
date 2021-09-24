using System;

namespace XUtliPoolLib
{

	public class DailyTaskReward : CVSReader
	{

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

		public DailyTaskReward.RowData[] Table = null;

		public class RowData
		{

			public SeqRef<uint> level;

			public uint tasktype;

			public uint taskquality;

			public SeqListRef<uint> taskreward;

			public SeqListRef<uint> extrareward_s;

			public uint category;

			public uint score;

			public SeqListRef<uint> reward_s;

			public SeqListRef<uint> reward_a;

			public SeqListRef<uint> reward_b;

			public SeqListRef<uint> reward_c;

			public SeqListRef<uint> reward_d;

			public SeqListRef<uint> extrareward_a;

			public SeqListRef<uint> extrareward_b;

			public SeqListRef<uint> extrareward_c;

			public SeqListRef<uint> extrareward_d;
		}
	}
}
