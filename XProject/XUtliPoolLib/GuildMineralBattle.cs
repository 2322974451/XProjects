using System;

namespace XUtliPoolLib
{

	public class GuildMineralBattle : CVSReader
	{

		public GuildMineralBattle.RowData GetByID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildMineralBattle.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchID(key);
			}
			return result;
		}

		private GuildMineralBattle.RowData BinarySearchID(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			GuildMineralBattle.RowData rowData;
			GuildMineralBattle.RowData rowData2;
			GuildMineralBattle.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.ID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.ID == key;
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
				bool flag4 = rowData3.ID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.ID.CompareTo(key) < 0;
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
			GuildMineralBattle.RowData rowData = new GuildMineralBattle.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Mineralcounts, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.DifficultLevel, CVSReader.intParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.BossID, CVSReader.uintParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildMineralBattle.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildMineralBattle.RowData[] Table = null;

		public class RowData
		{

			public uint ID;

			public uint Mineralcounts;

			public int DifficultLevel;

			public uint BossID;
		}
	}
}
