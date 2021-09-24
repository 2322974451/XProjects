using System;

namespace XUtliPoolLib
{

	public class RandomTaskTable : CVSReader
	{

		public RandomTaskTable.RowData GetByTaskID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			RandomTaskTable.RowData result;
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
			RandomTaskTable.RowData rowData = new RandomTaskTable.RowData();
			base.Read<int>(reader, ref rowData.TaskID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.TaskDescription, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.TaskCondition, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.TaskParam, CVSReader.intParse);
			this.columnno = 4;
			rowData.TaskReward.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new RandomTaskTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public RandomTaskTable.RowData[] Table = null;

		public class RowData
		{

			public int TaskID;

			public string TaskDescription;

			public int TaskCondition;

			public int TaskParam;

			public SeqListRef<int> TaskReward;
		}
	}
}
