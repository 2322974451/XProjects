using System;

namespace XUtliPoolLib
{
	// Token: 0x020000C1 RID: 193
	public class CardsList : CVSReader
	{
		// Token: 0x06000574 RID: 1396 RVA: 0x00018A78 File Offset: 0x00016C78
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

		// Token: 0x06000575 RID: 1397 RVA: 0x00018AB0 File Offset: 0x00016CB0
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

		// Token: 0x06000576 RID: 1398 RVA: 0x00018B8C File Offset: 0x00016D8C
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

		// Token: 0x06000577 RID: 1399 RVA: 0x00018C54 File Offset: 0x00016E54
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

		// Token: 0x040002E7 RID: 743
		public CardsList.RowData[] Table = null;

		// Token: 0x020002BF RID: 703
		public class RowData
		{
			// Token: 0x04000974 RID: 2420
			public uint CardId;

			// Token: 0x04000975 RID: 2421
			public string CardName;

			// Token: 0x04000976 RID: 2422
			public uint GroupId;

			// Token: 0x04000977 RID: 2423
			public string Description;

			// Token: 0x04000978 RID: 2424
			public uint Avatar;

			// Token: 0x04000979 RID: 2425
			public uint MapID;
		}
	}
}
