using System;

namespace XUtliPoolLib
{

	public class DailyTask : CVSReader
	{

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

		public DailyTask.RowData[] Table = null;

		public class RowData
		{

			public uint taskID;

			public uint taskquality;

			public uint tasktype;

			public uint[] conditionId;

			public string taskdescription;

			public uint conditionNum;

			public uint NPCID;

			public SeqListRef<uint> BQ;

			public uint category;

			public uint score;

			public string TaskIcon;

			public string AtlasName;
		}
	}
}
