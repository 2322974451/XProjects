using System;

namespace XUtliPoolLib
{
	// Token: 0x0200021D RID: 541
	public class MentorTaskTable : CVSReader
	{
		// Token: 0x06000C26 RID: 3110 RVA: 0x0003FCD8 File Offset: 0x0003DED8
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

		// Token: 0x06000C27 RID: 3111 RVA: 0x0003FD44 File Offset: 0x0003DF44
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

		// Token: 0x06000C28 RID: 3112 RVA: 0x0003FE0C File Offset: 0x0003E00C
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

		// Token: 0x0400076B RID: 1899
		public MentorTaskTable.RowData[] Table = null;

		// Token: 0x020003AC RID: 940
		public class RowData
		{
			// Token: 0x04001073 RID: 4211
			public uint TaskID;

			// Token: 0x04001074 RID: 4212
			public uint TaskType;

			// Token: 0x04001075 RID: 4213
			public string TaskName;

			// Token: 0x04001076 RID: 4214
			public SeqRef<int> TaskVar;

			// Token: 0x04001077 RID: 4215
			public SeqListRef<int> MasterReward;

			// Token: 0x04001078 RID: 4216
			public SeqListRef<int> StudentReward;
		}
	}
}
