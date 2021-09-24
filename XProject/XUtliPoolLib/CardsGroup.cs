using System;

namespace XUtliPoolLib
{

	public class CardsGroup : CVSReader
	{

		public CardsGroup.RowData GetByTeamId(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			CardsGroup.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchTeamId(key);
			}
			return result;
		}

		private CardsGroup.RowData BinarySearchTeamId(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			CardsGroup.RowData rowData;
			CardsGroup.RowData rowData2;
			CardsGroup.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.TeamId == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.TeamId == key;
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
				bool flag4 = rowData3.TeamId.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.TeamId.CompareTo(key) < 0;
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
			CardsGroup.RowData rowData = new CardsGroup.RowData();
			base.Read<uint>(reader, ref rowData.GroupId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.TeamId, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.TeamName, CVSReader.stringParse);
			this.columnno = 2;
			rowData.FireProperty_1.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			rowData.FireProperty_2.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.StarFireCondition.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CardsGroup.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public CardsGroup.RowData[] Table = null;

		public class RowData
		{

			public uint GroupId;

			public uint TeamId;

			public string TeamName;

			public SeqListRef<uint> FireProperty_1;

			public SeqListRef<uint> FireProperty_2;

			public SeqListRef<uint> StarFireCondition;
		}
	}
}
