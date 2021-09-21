using System;

namespace XUtliPoolLib
{
	// Token: 0x02000121 RID: 289
	public class ItemList : CVSReader
	{
		// Token: 0x060006F5 RID: 1781 RVA: 0x000226E8 File Offset: 0x000208E8
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

		// Token: 0x060006F6 RID: 1782 RVA: 0x00022720 File Offset: 0x00020920
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

		// Token: 0x060006F7 RID: 1783 RVA: 0x000227FC File Offset: 0x000209FC
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

		// Token: 0x060006F8 RID: 1784 RVA: 0x00022B64 File Offset: 0x00020D64
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

		// Token: 0x0400036D RID: 877
		public ItemList.RowData[] Table = null;

		// Token: 0x02000320 RID: 800
		public class RowData
		{
			// Token: 0x04000BF1 RID: 3057
			public int ItemID;

			// Token: 0x04000BF2 RID: 3058
			public string[] ItemName;

			// Token: 0x04000BF3 RID: 3059
			public string ItemDescription;

			// Token: 0x04000BF4 RID: 3060
			public string[] ItemIcon;

			// Token: 0x04000BF5 RID: 3061
			public byte ItemType;

			// Token: 0x04000BF6 RID: 3062
			public byte ItemQuality;

			// Token: 0x04000BF7 RID: 3063
			public short ReqLevel;

			// Token: 0x04000BF8 RID: 3064
			public int SortID;

			// Token: 0x04000BF9 RID: 3065
			public string[] ItemAtlas;

			// Token: 0x04000BFA RID: 3066
			public string DoodadFx;

			// Token: 0x04000BFB RID: 3067
			public SeqListRef<int> Access;

			// Token: 0x04000BFC RID: 3068
			public byte ShowTips;

			// Token: 0x04000BFD RID: 3069
			public string[] ItemAtlas1;

			// Token: 0x04000BFE RID: 3070
			public string[] ItemIcon1;

			// Token: 0x04000BFF RID: 3071
			public bool CanTrade;

			// Token: 0x04000C00 RID: 3072
			public byte[] AuctionType;

			// Token: 0x04000C01 RID: 3073
			public int OverCnt;

			// Token: 0x04000C02 RID: 3074
			public uint AuctPriceRecommend;

			// Token: 0x04000C03 RID: 3075
			public byte Profession;

			// Token: 0x04000C04 RID: 3076
			public string NumberName;

			// Token: 0x04000C05 RID: 3077
			public uint TimeLimit;

			// Token: 0x04000C06 RID: 3078
			public SeqListRef<uint> Decompose;

			// Token: 0x04000C07 RID: 3079
			public string ItemEffect;

			// Token: 0x04000C08 RID: 3080
			public byte AuctionGroup;

			// Token: 0x04000C09 RID: 3081
			public byte IsNeedShowTipsPanel;

			// Token: 0x04000C0A RID: 3082
			public float[] IconTransform;

			// Token: 0x04000C0B RID: 3083
			public SeqRef<float> AuctionRange;

			// Token: 0x04000C0C RID: 3084
			public byte IsCanRecycle;

			// Token: 0x04000C0D RID: 3085
			public SeqRef<uint> Sell;

			// Token: 0x04000C0E RID: 3086
			public byte BagType;

			// Token: 0x04000C0F RID: 3087
			public short AuctionUpperLimit;
		}
	}
}
