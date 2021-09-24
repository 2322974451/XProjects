using System;

namespace XUtliPoolLib
{

	public class ShopTable : CVSReader
	{

		public ShopTable.RowData GetByID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ShopTable.RowData result;
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

		private ShopTable.RowData BinarySearchID(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			ShopTable.RowData rowData;
			ShopTable.RowData rowData2;
			ShopTable.RowData rowData3;
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
			ShopTable.RowData rowData = new ShopTable.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.ItemId, CVSReader.uintParse);
			this.columnno = 1;
			rowData.ConsumeItem.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<byte>(reader, ref rowData.LevelCondition, CVSReader.byteParse);
			this.columnno = 4;
			base.Read<byte>(reader, ref rowData.DailyCountCondition, CVSReader.byteParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.CountCondition, CVSReader.uintParse);
			this.columnno = 7;
			rowData.Benefit.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			rowData.LevelShow.Read(reader, this.m_DataHandler);
			this.columnno = 10;
			base.Read<bool>(reader, ref rowData.IsNotBind, CVSReader.boolParse);
			this.columnno = 16;
			base.Read<byte>(reader, ref rowData.CookLevel, CVSReader.byteParse);
			this.columnno = 17;
			base.Read<byte>(reader, ref rowData.ShopItemType, CVSReader.byteParse);
			this.columnno = 18;
			base.Read<byte>(reader, ref rowData.WeekCountCondition, CVSReader.byteParse);
			this.columnno = 19;
			base.Read<uint>(reader, ref rowData.ItemOverlap, CVSReader.uintParse);
			this.columnno = 21;
			base.Read<bool>(reader, ref rowData.IsPrecious, CVSReader.boolParse);
			this.columnno = 22;
			base.Read<int>(reader, ref rowData.PayLimit, CVSReader.intParse);
			this.columnno = 23;
			base.Read<uint>(reader, ref rowData.ShopItemCategory, CVSReader.uintParse);
			this.columnno = 24;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ShopTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ShopTable.RowData[] Table = null;

		public class RowData
		{

			public uint ID;

			public uint ItemId;

			public SeqRef<uint> ConsumeItem;

			public uint Type;

			public byte LevelCondition;

			public byte DailyCountCondition;

			public uint CountCondition;

			public SeqRef<uint> Benefit;

			public SeqRef<uint> LevelShow;

			public bool IsNotBind;

			public byte CookLevel;

			public byte ShopItemType;

			public byte WeekCountCondition;

			public uint ItemOverlap;

			public bool IsPrecious;

			public int PayLimit;

			public uint ShopItemCategory;
		}
	}
}
