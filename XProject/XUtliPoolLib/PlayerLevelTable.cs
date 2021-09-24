using System;

namespace XUtliPoolLib
{

	public class PlayerLevelTable : CVSReader
	{

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

		public PlayerLevelTable.RowData[] Table = null;

		public class RowData
		{

			public int Level;

			public long Exp;

			public int AddSkillPoint;

			public double ExpAddition;

			public uint MaxEnhanceLevel;
		}
	}
}
