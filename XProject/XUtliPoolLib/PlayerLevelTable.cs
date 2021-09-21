using System;

namespace XUtliPoolLib
{
	// Token: 0x0200014C RID: 332
	public class PlayerLevelTable : CVSReader
	{
		// Token: 0x06000792 RID: 1938 RVA: 0x0002649C File Offset: 0x0002469C
		public PlayerLevelTable.RowData GetByLevel(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PlayerLevelTable.RowData result;
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

		// Token: 0x06000793 RID: 1939 RVA: 0x000264D4 File Offset: 0x000246D4
		private PlayerLevelTable.RowData BinarySearchLevel(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			PlayerLevelTable.RowData rowData;
			PlayerLevelTable.RowData rowData2;
			PlayerLevelTable.RowData rowData3;
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

		// Token: 0x06000794 RID: 1940 RVA: 0x000265B0 File Offset: 0x000247B0
		protected override void ReadLine(XBinaryReader reader)
		{
			PlayerLevelTable.RowData rowData = new PlayerLevelTable.RowData();
			base.Read<int>(reader, ref rowData.Level, CVSReader.intParse);
			this.columnno = 0;
			base.Read<long>(reader, ref rowData.Exp, CVSReader.longParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.AddSkillPoint, CVSReader.intParse);
			this.columnno = 10;
			base.Read<double>(reader, ref rowData.ExpAddition, CVSReader.doubleParse);
			this.columnno = 11;
			base.Read<uint>(reader, ref rowData.MaxEnhanceLevel, CVSReader.uintParse);
			this.columnno = 12;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x00026660 File Offset: 0x00024860
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PlayerLevelTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000398 RID: 920
		public PlayerLevelTable.RowData[] Table = null;

		// Token: 0x0200034B RID: 843
		public class RowData
		{
			// Token: 0x04000D1C RID: 3356
			public int Level;

			// Token: 0x04000D1D RID: 3357
			public long Exp;

			// Token: 0x04000D1E RID: 3358
			public int AddSkillPoint;

			// Token: 0x04000D1F RID: 3359
			public double ExpAddition;

			// Token: 0x04000D20 RID: 3360
			public uint MaxEnhanceLevel;
		}
	}
}
