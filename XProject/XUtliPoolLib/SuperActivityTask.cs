using System;

namespace XUtliPoolLib
{
	// Token: 0x02000176 RID: 374
	public class SuperActivityTask : CVSReader
	{
		// Token: 0x06000830 RID: 2096 RVA: 0x0002AD3C File Offset: 0x00028F3C
		public SuperActivityTask.RowData GetBytaskid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			SuperActivityTask.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchtaskid(key);
			}
			return result;
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x0002AD74 File Offset: 0x00028F74
		private SuperActivityTask.RowData BinarySearchtaskid(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			SuperActivityTask.RowData rowData;
			SuperActivityTask.RowData rowData2;
			SuperActivityTask.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.taskid == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.taskid == key;
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
				bool flag4 = rowData3.taskid.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.taskid.CompareTo(key) < 0;
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

		// Token: 0x06000832 RID: 2098 RVA: 0x0002AE50 File Offset: 0x00029050
		protected override void ReadLine(XBinaryReader reader)
		{
			SuperActivityTask.RowData rowData = new SuperActivityTask.RowData();
			base.Read<uint>(reader, ref rowData.taskid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.title, CVSReader.stringParse);
			this.columnno = 1;
			base.ReadArray<uint>(reader, ref rowData.num, CVSReader.uintParse);
			this.columnno = 3;
			rowData.items.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.type, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.belong, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.jump, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.actid, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.cnt, CVSReader.intParse);
			this.columnno = 10;
			base.ReadArray<int>(reader, ref rowData.arg, CVSReader.intParse);
			this.columnno = 11;
			base.Read<uint>(reader, ref rowData.tasktype, CVSReader.uintParse);
			this.columnno = 12;
			base.ReadArray<uint>(reader, ref rowData.taskson, CVSReader.uintParse);
			this.columnno = 13;
			base.Read<uint>(reader, ref rowData.taskfather, CVSReader.uintParse);
			this.columnno = 14;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x0002AFEC File Offset: 0x000291EC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SuperActivityTask.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003C2 RID: 962
		public SuperActivityTask.RowData[] Table = null;

		// Token: 0x02000375 RID: 885
		public class RowData
		{
			// Token: 0x04000E9D RID: 3741
			public uint taskid;

			// Token: 0x04000E9E RID: 3742
			public string title;

			// Token: 0x04000E9F RID: 3743
			public uint[] num;

			// Token: 0x04000EA0 RID: 3744
			public SeqListRef<uint> items;

			// Token: 0x04000EA1 RID: 3745
			public string icon;

			// Token: 0x04000EA2 RID: 3746
			public uint type;

			// Token: 0x04000EA3 RID: 3747
			public uint belong;

			// Token: 0x04000EA4 RID: 3748
			public uint jump;

			// Token: 0x04000EA5 RID: 3749
			public uint actid;

			// Token: 0x04000EA6 RID: 3750
			public int cnt;

			// Token: 0x04000EA7 RID: 3751
			public int[] arg;

			// Token: 0x04000EA8 RID: 3752
			public uint tasktype;

			// Token: 0x04000EA9 RID: 3753
			public uint[] taskson;

			// Token: 0x04000EAA RID: 3754
			public uint taskfather;
		}
	}
}
