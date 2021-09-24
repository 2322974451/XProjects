using System;

namespace XUtliPoolLib
{

	public class EmblemBasic : CVSReader
	{

		public EmblemBasic.RowData GetByEmblemID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			EmblemBasic.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchEmblemID(key);
			}
			return result;
		}

		private EmblemBasic.RowData BinarySearchEmblemID(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			EmblemBasic.RowData rowData;
			EmblemBasic.RowData rowData2;
			EmblemBasic.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.EmblemID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.EmblemID == key;
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
				bool flag4 = rowData3.EmblemID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.EmblemID.CompareTo(key) < 0;
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
			EmblemBasic.RowData rowData = new EmblemBasic.RowData();
			base.Read<uint>(reader, ref rowData.EmblemID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<short>(reader, ref rowData.EmblemType, CVSReader.shortParse);
			this.columnno = 3;
			base.Read<short>(reader, ref rowData.DragonCoinCost, CVSReader.shortParse);
			this.columnno = 4;
			rowData.SmeltNeedItem.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.SmeltNeedMoney, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<byte>(reader, ref rowData.ReturnSmeltStoneRate, CVSReader.byteParse);
			this.columnno = 8;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new EmblemBasic.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public EmblemBasic.RowData[] Table = null;

		public class RowData
		{

			public uint EmblemID;

			public short EmblemType;

			public short DragonCoinCost;

			public SeqListRef<uint> SmeltNeedItem;

			public uint SmeltNeedMoney;

			public byte ReturnSmeltStoneRate;
		}
	}
}
