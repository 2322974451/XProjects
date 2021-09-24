using System;

namespace XUtliPoolLib
{

	public class TaskTableNew : CVSReader
	{

		public TaskTableNew.RowData GetByTaskID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			TaskTableNew.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchTaskID(key);
			}
			return result;
		}

		private TaskTableNew.RowData BinarySearchTaskID(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			TaskTableNew.RowData rowData;
			TaskTableNew.RowData rowData2;
			TaskTableNew.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.TaskID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.TaskID == key;
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
				bool flag4 = rowData3.TaskID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.TaskID.CompareTo(key) < 0;
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

		protected override void ReadLine(XBinaryReader reader)
		{
			TaskTableNew.RowData rowData = new TaskTableNew.RowData();
			base.Read<uint>(reader, ref rowData.TaskType, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.TaskID, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadArray<uint>(reader, ref rowData.EndTime, CVSReader.uintParse);
			this.columnno = 4;
			base.ReadArray<uint>(reader, ref rowData.BeginTaskNPCID, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadArray<uint>(reader, ref rowData.EndTaskNPCID, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.TaskTitle, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.TaskDesc, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.InprocessDesc, CVSReader.stringParse);
			this.columnno = 10;
			rowData.PassScene.Read(reader, this.m_DataHandler);
			this.columnno = 11;
			rowData.TaskScene.Read(reader, this.m_DataHandler);
			this.columnno = 12;
			rowData.RewardItem.Read(reader, this.m_DataHandler);
			this.columnno = 15;
			base.Read<string>(reader, ref rowData.BeginDesc, CVSReader.stringParse);
			this.columnno = 16;
			base.Read<string>(reader, ref rowData.EndDesc, CVSReader.stringParse);
			this.columnno = 17;
			base.ReadArray<uint>(reader, ref rowData.MailID, CVSReader.uintParse);
			this.columnno = 18;
			base.Read<uint>(reader, ref rowData.ActivityID, CVSReader.uintParse);
			this.columnno = 19;
			rowData.TaskActivity.Read(reader, this.m_DataHandler);
			this.columnno = 20;
			base.ReadArray<int>(reader, ref rowData.Prof, CVSReader.intParse);
			this.columnno = 21;
			base.Read<int>(reader, ref rowData.ProfLevel, CVSReader.intParse);
			this.columnno = 22;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new TaskTableNew.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public TaskTableNew.RowData[] Table = null;

		public class RowData
		{

			public uint TaskType;

			public uint TaskID;

			public uint[] EndTime;

			public uint[] BeginTaskNPCID;

			public uint[] EndTaskNPCID;

			public string TaskTitle;

			public string TaskDesc;

			public string InprocessDesc;

			public SeqListRef<uint> PassScene;

			public SeqListRef<uint> TaskScene;

			public SeqListRef<uint> RewardItem;

			public string BeginDesc;

			public string EndDesc;

			public uint[] MailID;

			public uint ActivityID;

			public SeqListRef<uint> TaskActivity;

			public int[] Prof;

			public int ProfLevel;
		}
	}
}
