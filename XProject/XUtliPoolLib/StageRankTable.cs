using System;

namespace XUtliPoolLib
{

	public class StageRankTable : CVSReader
	{

		public StageRankTable.RowData GetByscendid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			StageRankTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchscendid(key);
			}
			return result;
		}

		private StageRankTable.RowData BinarySearchscendid(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			StageRankTable.RowData rowData;
			StageRankTable.RowData rowData2;
			StageRankTable.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.scendid == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.scendid == key;
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
				bool flag4 = rowData3.scendid.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.scendid.CompareTo(key) < 0;
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
			StageRankTable.RowData rowData = new StageRankTable.RowData();
			base.Read<uint>(reader, ref rowData.scendid, CVSReader.uintParse);
			this.columnno = 0;
			rowData.star2.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.star3.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new StageRankTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public StageRankTable.RowData[] Table = null;

		public class RowData
		{

			public uint scendid;

			public SeqRef<uint> star2;

			public SeqRef<uint> star3;
		}
	}
}
