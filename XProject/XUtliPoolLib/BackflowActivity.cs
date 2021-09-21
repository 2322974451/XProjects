using System;

namespace XUtliPoolLib
{
	// Token: 0x020000B5 RID: 181
	public class BackflowActivity : CVSReader
	{
		// Token: 0x06000546 RID: 1350 RVA: 0x00017554 File Offset: 0x00015754
		public BackflowActivity.RowData GetByTaskId(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			BackflowActivity.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchTaskId(key);
			}
			return result;
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x0001758C File Offset: 0x0001578C
		private BackflowActivity.RowData BinarySearchTaskId(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			BackflowActivity.RowData rowData;
			BackflowActivity.RowData rowData2;
			BackflowActivity.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.TaskId == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.TaskId == key;
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
				bool flag4 = rowData3.TaskId.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.TaskId.CompareTo(key) < 0;
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

		// Token: 0x06000548 RID: 1352 RVA: 0x00017668 File Offset: 0x00015868
		protected override void ReadLine(XBinaryReader reader)
		{
			BackflowActivity.RowData rowData = new BackflowActivity.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.TaskId, CVSReader.uintParse);
			this.columnno = 1;
			rowData.WorldLevel.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.Point, CVSReader.uintParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x000176FC File Offset: 0x000158FC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new BackflowActivity.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002DB RID: 731
		public BackflowActivity.RowData[] Table = null;

		// Token: 0x020002B3 RID: 691
		public class RowData
		{
			// Token: 0x0400090A RID: 2314
			public uint Type;

			// Token: 0x0400090B RID: 2315
			public uint TaskId;

			// Token: 0x0400090C RID: 2316
			public SeqRef<uint> WorldLevel;

			// Token: 0x0400090D RID: 2317
			public uint Point;
		}
	}
}
