using System;

namespace XUtliPoolLib
{

	public class MentorTaskTable : CVSReader
	{

		public MentorTaskTable.RowData GetByTaskID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			MentorTaskTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].TaskID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			MentorTaskTable.RowData rowData = new MentorTaskTable.RowData();
			base.Read<uint>(reader, ref rowData.TaskID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.TaskType, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.TaskName, CVSReader.stringParse);
			this.columnno = 2;
			rowData.TaskVar.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			rowData.MasterReward.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.StudentReward.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new MentorTaskTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public MentorTaskTable.RowData[] Table = null;

		public class RowData
		{

			public uint TaskID;

			public uint TaskType;

			public string TaskName;

			public SeqRef<int> TaskVar;

			public SeqListRef<int> MasterReward;

			public SeqListRef<int> StudentReward;
		}
	}
}
