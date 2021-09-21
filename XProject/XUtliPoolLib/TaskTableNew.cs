using System;

namespace XUtliPoolLib
{
	// Token: 0x0200017C RID: 380
	public class TaskTableNew : CVSReader
	{
		// Token: 0x06000849 RID: 2121 RVA: 0x0002B790 File Offset: 0x00029990
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

		// Token: 0x0600084A RID: 2122 RVA: 0x0002B7C8 File Offset: 0x000299C8
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

		// Token: 0x0600084B RID: 2123 RVA: 0x0002B8A4 File Offset: 0x00029AA4
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

		// Token: 0x0600084C RID: 2124 RVA: 0x0002BAB0 File Offset: 0x00029CB0
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

		// Token: 0x040003C8 RID: 968
		public TaskTableNew.RowData[] Table = null;

		// Token: 0x0200037B RID: 891
		public class RowData
		{
			// Token: 0x04000EC8 RID: 3784
			public uint TaskType;

			// Token: 0x04000EC9 RID: 3785
			public uint TaskID;

			// Token: 0x04000ECA RID: 3786
			public uint[] EndTime;

			// Token: 0x04000ECB RID: 3787
			public uint[] BeginTaskNPCID;

			// Token: 0x04000ECC RID: 3788
			public uint[] EndTaskNPCID;

			// Token: 0x04000ECD RID: 3789
			public string TaskTitle;

			// Token: 0x04000ECE RID: 3790
			public string TaskDesc;

			// Token: 0x04000ECF RID: 3791
			public string InprocessDesc;

			// Token: 0x04000ED0 RID: 3792
			public SeqListRef<uint> PassScene;

			// Token: 0x04000ED1 RID: 3793
			public SeqListRef<uint> TaskScene;

			// Token: 0x04000ED2 RID: 3794
			public SeqListRef<uint> RewardItem;

			// Token: 0x04000ED3 RID: 3795
			public string BeginDesc;

			// Token: 0x04000ED4 RID: 3796
			public string EndDesc;

			// Token: 0x04000ED5 RID: 3797
			public uint[] MailID;

			// Token: 0x04000ED6 RID: 3798
			public uint ActivityID;

			// Token: 0x04000ED7 RID: 3799
			public SeqListRef<uint> TaskActivity;

			// Token: 0x04000ED8 RID: 3800
			public int[] Prof;

			// Token: 0x04000ED9 RID: 3801
			public int ProfLevel;
		}
	}
}
