using System;

namespace XUtliPoolLib
{
	// Token: 0x020000E0 RID: 224
	public class EmblemBasic : CVSReader
	{
		// Token: 0x06000600 RID: 1536 RVA: 0x0001C6B4 File Offset: 0x0001A8B4
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

		// Token: 0x06000601 RID: 1537 RVA: 0x0001C6EC File Offset: 0x0001A8EC
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

		// Token: 0x06000602 RID: 1538 RVA: 0x0001C7C8 File Offset: 0x0001A9C8
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

		// Token: 0x06000603 RID: 1539 RVA: 0x0001C890 File Offset: 0x0001AA90
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

		// Token: 0x0400032C RID: 812
		public EmblemBasic.RowData[] Table = null;

		// Token: 0x020002DF RID: 735
		public class RowData
		{
			// Token: 0x04000A38 RID: 2616
			public uint EmblemID;

			// Token: 0x04000A39 RID: 2617
			public short EmblemType;

			// Token: 0x04000A3A RID: 2618
			public short DragonCoinCost;

			// Token: 0x04000A3B RID: 2619
			public SeqListRef<uint> SmeltNeedItem;

			// Token: 0x04000A3C RID: 2620
			public uint SmeltNeedMoney;

			// Token: 0x04000A3D RID: 2621
			public byte ReturnSmeltStoneRate;
		}
	}
}
