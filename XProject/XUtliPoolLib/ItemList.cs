using System;

namespace XUtliPoolLib
{

	public class ItemList : CVSReader
	{

		public ItemList.RowData GetByItemID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ItemList.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchItemID(key);
			}
			return result;
		}

		private ItemList.RowData BinarySearchItemID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			ItemList.RowData rowData;
			ItemList.RowData rowData2;
			ItemList.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.ItemID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.ItemID == key;
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
				bool flag4 = rowData3.ItemID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.ItemID.CompareTo(key) < 0;
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
			ItemList.RowData rowData = new ItemList.RowData();
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<string>(reader, ref rowData.ItemName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.ItemDescription, CVSReader.stringParse);
			this.columnno = 2;
			base.ReadArray<string>(reader, ref rowData.ItemIcon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<byte>(reader, ref rowData.ItemType, CVSReader.byteParse);
			this.columnno = 4;
			base.Read<byte>(reader, ref rowData.ItemQuality, CVSReader.byteParse);
			this.columnno = 5;
			base.Read<short>(reader, ref rowData.ReqLevel, CVSReader.shortParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.SortID, CVSReader.intParse);
			this.columnno = 8;
			base.ReadArray<string>(reader, ref rowData.ItemAtlas, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.DoodadFx, CVSReader.stringParse);
			this.columnno = 10;
			rowData.Access.Read(reader, this.m_DataHandler);
			this.columnno = 11;
			base.Read<byte>(reader, ref rowData.ShowTips, CVSReader.byteParse);
			this.columnno = 12;
			base.ReadArray<string>(reader, ref rowData.ItemAtlas1, CVSReader.stringParse);
			this.columnno = 13;
			base.ReadArray<string>(reader, ref rowData.ItemIcon1, CVSReader.stringParse);
			this.columnno = 14;
			base.Read<bool>(reader, ref rowData.CanTrade, CVSReader.boolParse);
			this.columnno = 15;
			base.ReadArray<byte>(reader, ref rowData.AuctionType, CVSReader.byteParse);
			this.columnno = 16;
			base.Read<int>(reader, ref rowData.OverCnt, CVSReader.intParse);
			this.columnno = 17;
			base.Read<uint>(reader, ref rowData.AuctPriceRecommend, CVSReader.uintParse);
			this.columnno = 18;
			base.Read<byte>(reader, ref rowData.Profession, CVSReader.byteParse);
			this.columnno = 19;
			base.Read<string>(reader, ref rowData.NumberName, CVSReader.stringParse);
			this.columnno = 21;
			base.Read<uint>(reader, ref rowData.TimeLimit, CVSReader.uintParse);
			this.columnno = 22;
			rowData.Decompose.Read(reader, this.m_DataHandler);
			this.columnno = 23;
			base.Read<string>(reader, ref rowData.ItemEffect, CVSReader.stringParse);
			this.columnno = 24;
			base.Read<byte>(reader, ref rowData.AuctionGroup, CVSReader.byteParse);
			this.columnno = 26;
			base.Read<byte>(reader, ref rowData.IsNeedShowTipsPanel, CVSReader.byteParse);
			this.columnno = 27;
			base.ReadArray<float>(reader, ref rowData.IconTransform, CVSReader.floatParse);
			this.columnno = 28;
			rowData.AuctionRange.Read(reader, this.m_DataHandler);
			this.columnno = 29;
			base.Read<byte>(reader, ref rowData.IsCanRecycle, CVSReader.byteParse);
			this.columnno = 30;
			rowData.Sell.Read(reader, this.m_DataHandler);
			this.columnno = 31;
			base.Read<byte>(reader, ref rowData.BagType, CVSReader.byteParse);
			this.columnno = 32;
			base.Read<short>(reader, ref rowData.AuctionUpperLimit, CVSReader.shortParse);
			this.columnno = 33;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ItemList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ItemList.RowData[] Table = null;

		public class RowData
		{

			public int ItemID;

			public string[] ItemName;

			public string ItemDescription;

			public string[] ItemIcon;

			public byte ItemType;

			public byte ItemQuality;

			public short ReqLevel;

			public int SortID;

			public string[] ItemAtlas;

			public string DoodadFx;

			public SeqListRef<int> Access;

			public byte ShowTips;

			public string[] ItemAtlas1;

			public string[] ItemIcon1;

			public bool CanTrade;

			public byte[] AuctionType;

			public int OverCnt;

			public uint AuctPriceRecommend;

			public byte Profession;

			public string NumberName;

			public uint TimeLimit;

			public SeqListRef<uint> Decompose;

			public string ItemEffect;

			public byte AuctionGroup;

			public byte IsNeedShowTipsPanel;

			public float[] IconTransform;

			public SeqRef<float> AuctionRange;

			public byte IsCanRecycle;

			public SeqRef<uint> Sell;

			public byte BagType;

			public short AuctionUpperLimit;
		}
	}
}
