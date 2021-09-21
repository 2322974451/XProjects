using System;

namespace XUtliPoolLib
{
	// Token: 0x02000169 RID: 361
	public class ShopTypeTable : CVSReader
	{
		// Token: 0x06000800 RID: 2048 RVA: 0x00029408 File Offset: 0x00027608
		public ShopTypeTable.RowData GetByShopID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ShopTypeTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ShopID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x00029474 File Offset: 0x00027674
		public ShopTypeTable.RowData GetBySystemId(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ShopTypeTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SystemId == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x000294E0 File Offset: 0x000276E0
		protected override void ReadLine(XBinaryReader reader)
		{
			ShopTypeTable.RowData rowData = new ShopTypeTable.RowData();
			base.Read<uint>(reader, ref rowData.ShopID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.ShopIcon, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.ShopLevel, CVSReader.uintParse);
			this.columnno = 2;
			rowData.RefreshCost.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.ReadArray<uint>(reader, ref rowData.ShopCycle, CVSReader.uintParse);
			this.columnno = 4;
			rowData.ShopOpen.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.ShopName, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.SystemId, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.IsHasTab, CVSReader.intParse);
			this.columnno = 8;
			rowData.RefreshCount.Read(reader, this.m_DataHandler);
			this.columnno = 9;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x00029610 File Offset: 0x00027810
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ShopTypeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003B5 RID: 949
		public ShopTypeTable.RowData[] Table = null;

		// Token: 0x02000368 RID: 872
		public class RowData
		{
			// Token: 0x04000E06 RID: 3590
			public uint ShopID;

			// Token: 0x04000E07 RID: 3591
			public string ShopIcon;

			// Token: 0x04000E08 RID: 3592
			public uint ShopLevel;

			// Token: 0x04000E09 RID: 3593
			public SeqListRef<uint> RefreshCost;

			// Token: 0x04000E0A RID: 3594
			public uint[] ShopCycle;

			// Token: 0x04000E0B RID: 3595
			public SeqListRef<uint> ShopOpen;

			// Token: 0x04000E0C RID: 3596
			public string ShopName;

			// Token: 0x04000E0D RID: 3597
			public uint SystemId;

			// Token: 0x04000E0E RID: 3598
			public int IsHasTab;

			// Token: 0x04000E0F RID: 3599
			public SeqRef<uint> RefreshCount;
		}
	}
}
