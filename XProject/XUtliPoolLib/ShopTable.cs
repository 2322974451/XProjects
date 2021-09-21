using System;

namespace XUtliPoolLib
{
	// Token: 0x02000168 RID: 360
	public class ShopTable : CVSReader
	{
		// Token: 0x060007FB RID: 2043 RVA: 0x000290C8 File Offset: 0x000272C8
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

		// Token: 0x060007FC RID: 2044 RVA: 0x00029100 File Offset: 0x00027300
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

		// Token: 0x060007FD RID: 2045 RVA: 0x000291DC File Offset: 0x000273DC
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

		// Token: 0x060007FE RID: 2046 RVA: 0x000293C8 File Offset: 0x000275C8
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

		// Token: 0x040003B4 RID: 948
		public ShopTable.RowData[] Table = null;

		// Token: 0x02000367 RID: 871
		public class RowData
		{
			// Token: 0x04000DF5 RID: 3573
			public uint ID;

			// Token: 0x04000DF6 RID: 3574
			public uint ItemId;

			// Token: 0x04000DF7 RID: 3575
			public SeqRef<uint> ConsumeItem;

			// Token: 0x04000DF8 RID: 3576
			public uint Type;

			// Token: 0x04000DF9 RID: 3577
			public byte LevelCondition;

			// Token: 0x04000DFA RID: 3578
			public byte DailyCountCondition;

			// Token: 0x04000DFB RID: 3579
			public uint CountCondition;

			// Token: 0x04000DFC RID: 3580
			public SeqRef<uint> Benefit;

			// Token: 0x04000DFD RID: 3581
			public SeqRef<uint> LevelShow;

			// Token: 0x04000DFE RID: 3582
			public bool IsNotBind;

			// Token: 0x04000DFF RID: 3583
			public byte CookLevel;

			// Token: 0x04000E00 RID: 3584
			public byte ShopItemType;

			// Token: 0x04000E01 RID: 3585
			public byte WeekCountCondition;

			// Token: 0x04000E02 RID: 3586
			public uint ItemOverlap;

			// Token: 0x04000E03 RID: 3587
			public bool IsPrecious;

			// Token: 0x04000E04 RID: 3588
			public int PayLimit;

			// Token: 0x04000E05 RID: 3589
			public uint ShopItemCategory;
		}
	}
}
