using System;

namespace XUtliPoolLib
{
	// Token: 0x020000E5 RID: 229
	public class EquipList : CVSReader
	{
		// Token: 0x06000612 RID: 1554 RVA: 0x0001CCF0 File Offset: 0x0001AEF0
		public EquipList.RowData GetByItemID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			EquipList.RowData result;
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

		// Token: 0x06000613 RID: 1555 RVA: 0x0001CD28 File Offset: 0x0001AF28
		private EquipList.RowData BinarySearchItemID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			EquipList.RowData rowData;
			EquipList.RowData rowData2;
			EquipList.RowData rowData3;
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

		// Token: 0x06000614 RID: 1556 RVA: 0x0001CE04 File Offset: 0x0001B004
		protected override void ReadLine(XBinaryReader reader)
		{
			EquipList.RowData rowData = new EquipList.RowData();
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<byte>(reader, ref rowData.EquipPos, CVSReader.byteParse);
			this.columnno = 1;
			rowData.Attributes.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			rowData.SmeltNeedItem.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.SmeltNeedMoney, CVSReader.uintParse);
			this.columnno = 7;
			rowData.ForgeNeedItem.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			rowData.ForgeSpecialItem.Read(reader, this.m_DataHandler);
			this.columnno = 9;
			base.Read<byte>(reader, ref rowData.ForgeLowRate, CVSReader.byteParse);
			this.columnno = 10;
			base.Read<byte>(reader, ref rowData.ForgeHighRate, CVSReader.byteParse);
			this.columnno = 11;
			rowData.ForgeNeedItemAfter.Read(reader, this.m_DataHandler);
			this.columnno = 12;
			rowData.ForgeSpecialItemAfter.Read(reader, this.m_DataHandler);
			this.columnno = 13;
			base.Read<byte>(reader, ref rowData.ForgeLowRateAfter, CVSReader.byteParse);
			this.columnno = 14;
			base.Read<byte>(reader, ref rowData.ForgeHighRateAfter, CVSReader.byteParse);
			this.columnno = 15;
			base.Read<bool>(reader, ref rowData.IsCanSmelt, CVSReader.boolParse);
			this.columnno = 16;
			base.Read<byte>(reader, ref rowData.ReturnSmeltStoneRate, CVSReader.byteParse);
			this.columnno = 17;
			base.Read<byte>(reader, ref rowData.CanForge, CVSReader.byteParse);
			this.columnno = 18;
			rowData.UpgradeNeedMaterials.Read(reader, this.m_DataHandler);
			this.columnno = 19;
			base.Read<uint>(reader, ref rowData.UpgadeTargetID, CVSReader.uintParse);
			this.columnno = 20;
			base.ReadArray<uint>(reader, ref rowData.FuseCoreItems, CVSReader.uintParse);
			this.columnno = 21;
			base.Read<byte>(reader, ref rowData.FuseCanBreakNum, CVSReader.byteParse);
			this.columnno = 22;
			base.Read<byte>(reader, ref rowData.EquipType, CVSReader.byteParse);
			this.columnno = 23;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x0001D060 File Offset: 0x0001B260
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new EquipList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000331 RID: 817
		public EquipList.RowData[] Table = null;

		// Token: 0x020002E4 RID: 740
		public class RowData
		{
			// Token: 0x04000A52 RID: 2642
			public int ItemID;

			// Token: 0x04000A53 RID: 2643
			public byte EquipPos;

			// Token: 0x04000A54 RID: 2644
			public SeqListRef<int> Attributes;

			// Token: 0x04000A55 RID: 2645
			public SeqListRef<uint> SmeltNeedItem;

			// Token: 0x04000A56 RID: 2646
			public uint SmeltNeedMoney;

			// Token: 0x04000A57 RID: 2647
			public SeqListRef<uint> ForgeNeedItem;

			// Token: 0x04000A58 RID: 2648
			public SeqRef<uint> ForgeSpecialItem;

			// Token: 0x04000A59 RID: 2649
			public byte ForgeLowRate;

			// Token: 0x04000A5A RID: 2650
			public byte ForgeHighRate;

			// Token: 0x04000A5B RID: 2651
			public SeqListRef<uint> ForgeNeedItemAfter;

			// Token: 0x04000A5C RID: 2652
			public SeqRef<uint> ForgeSpecialItemAfter;

			// Token: 0x04000A5D RID: 2653
			public byte ForgeLowRateAfter;

			// Token: 0x04000A5E RID: 2654
			public byte ForgeHighRateAfter;

			// Token: 0x04000A5F RID: 2655
			public bool IsCanSmelt;

			// Token: 0x04000A60 RID: 2656
			public byte ReturnSmeltStoneRate;

			// Token: 0x04000A61 RID: 2657
			public byte CanForge;

			// Token: 0x04000A62 RID: 2658
			public SeqListRef<uint> UpgradeNeedMaterials;

			// Token: 0x04000A63 RID: 2659
			public uint UpgadeTargetID;

			// Token: 0x04000A64 RID: 2660
			public uint[] FuseCoreItems;

			// Token: 0x04000A65 RID: 2661
			public byte FuseCanBreakNum;

			// Token: 0x04000A66 RID: 2662
			public byte EquipType;
		}
	}
}
