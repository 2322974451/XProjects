using System;

namespace XUtliPoolLib
{

	public class EquipList : CVSReader
	{

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

		public EquipList.RowData[] Table = null;

		public class RowData
		{

			public int ItemID;

			public byte EquipPos;

			public SeqListRef<int> Attributes;

			public SeqListRef<uint> SmeltNeedItem;

			public uint SmeltNeedMoney;

			public SeqListRef<uint> ForgeNeedItem;

			public SeqRef<uint> ForgeSpecialItem;

			public byte ForgeLowRate;

			public byte ForgeHighRate;

			public SeqListRef<uint> ForgeNeedItemAfter;

			public SeqRef<uint> ForgeSpecialItemAfter;

			public byte ForgeLowRateAfter;

			public byte ForgeHighRateAfter;

			public bool IsCanSmelt;

			public byte ReturnSmeltStoneRate;

			public byte CanForge;

			public SeqListRef<uint> UpgradeNeedMaterials;

			public uint UpgadeTargetID;

			public uint[] FuseCoreItems;

			public byte FuseCanBreakNum;

			public byte EquipType;
		}
	}
}
