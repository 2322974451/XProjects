using System;

namespace XUtliPoolLib
{
	// Token: 0x02000161 RID: 353
	public class RandomTaskTable : CVSReader
	{
		// Token: 0x060007E0 RID: 2016 RVA: 0x00027EB4 File Offset: 0x000260B4
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

		// Token: 0x060007E1 RID: 2017 RVA: 0x00027F20 File Offset: 0x00026120
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

		// Token: 0x060007E2 RID: 2018 RVA: 0x00027FCC File Offset: 0x000261CC
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

		// Token: 0x040003AD RID: 941
		public RandomTaskTable.RowData[] Table = null;

		// Token: 0x02000360 RID: 864
		public class RowData
		{
			// Token: 0x04000D7E RID: 3454
			public int TaskID;

			// Token: 0x04000D7F RID: 3455
			public string TaskDescription;

			// Token: 0x04000D80 RID: 3456
			public int TaskCondition;

			// Token: 0x04000D81 RID: 3457
			public int TaskParam;

			// Token: 0x04000D82 RID: 3458
			public SeqListRef<int> TaskReward;
		}
	}
}
