using System;

namespace XUtliPoolLib
{
	// Token: 0x0200021F RID: 543
	public class SkillTreeConfigTable : CVSReader
	{
		// Token: 0x06000C2E RID: 3118 RVA: 0x0003FF70 File Offset: 0x0003E170
		public SkillTreeConfigTable.RowData GetByLevel(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			SkillTreeConfigTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchLevel(key);
			}
			return result;
		}

		// Token: 0x06000C2F RID: 3119 RVA: 0x0003FFA8 File Offset: 0x0003E1A8
		private SkillTreeConfigTable.RowData BinarySearchLevel(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			SkillTreeConfigTable.RowData rowData;
			SkillTreeConfigTable.RowData rowData2;
			SkillTreeConfigTable.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.Level == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.Level == key;
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
				bool flag4 = rowData3.Level.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.Level.CompareTo(key) < 0;
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

		// Token: 0x06000C30 RID: 3120 RVA: 0x00040084 File Offset: 0x0003E284
		protected override void ReadLine(XBinaryReader reader)
		{
			SkillTreeConfigTable.RowData rowData = new SkillTreeConfigTable.RowData();
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.RedPointShowNum, CVSReader.intParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C31 RID: 3121 RVA: 0x000400E4 File Offset: 0x0003E2E4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SkillTreeConfigTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400076D RID: 1901
		public SkillTreeConfigTable.RowData[] Table = null;

		// Token: 0x020003AE RID: 942
		public class RowData
		{
			// Token: 0x0400107C RID: 4220
			public uint Level;

			// Token: 0x0400107D RID: 4221
			public int RedPointShowNum;
		}
	}
}
