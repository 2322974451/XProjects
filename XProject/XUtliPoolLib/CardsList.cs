using System;

namespace XUtliPoolLib
{

	public class CardsList : CVSReader
	{

		public CardsList.RowData GetByCardId(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			CardsList.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchCardId(key);
			}
			return result;
		}

		private CardsList.RowData BinarySearchCardId(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			CardsList.RowData rowData;
			CardsList.RowData rowData2;
			CardsList.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.CardId == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.CardId == key;
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
				bool flag4 = rowData3.CardId.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.CardId.CompareTo(key) < 0;
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
			CardsList.RowData rowData = new CardsList.RowData();
			base.Read<uint>(reader, ref rowData.CardId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.CardName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.GroupId, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.Avatar, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.MapID, CVSReader.uintParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CardsList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public CardsList.RowData[] Table = null;

		public class RowData
		{

			public uint CardId;

			public string CardName;

			public uint GroupId;

			public string Description;

			public uint Avatar;

			public uint MapID;
		}
	}
}
