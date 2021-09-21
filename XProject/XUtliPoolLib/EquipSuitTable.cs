using System;

namespace XUtliPoolLib
{
	// Token: 0x020000E6 RID: 230
	public class EquipSuitTable : CVSReader
	{
		// Token: 0x06000617 RID: 1559 RVA: 0x0001D0A0 File Offset: 0x0001B2A0
		public EquipSuitTable.RowData GetBySuitID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			EquipSuitTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchSuitID(key);
			}
			return result;
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x0001D0D8 File Offset: 0x0001B2D8
		private EquipSuitTable.RowData BinarySearchSuitID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			EquipSuitTable.RowData rowData;
			EquipSuitTable.RowData rowData2;
			EquipSuitTable.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.SuitID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.SuitID == key;
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
				bool flag4 = rowData3.SuitID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.SuitID.CompareTo(key) < 0;
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

		// Token: 0x06000619 RID: 1561 RVA: 0x0001D1B4 File Offset: 0x0001B3B4
		protected override void ReadLine(XBinaryReader reader)
		{
			EquipSuitTable.RowData rowData = new EquipSuitTable.RowData();
			base.Read<int>(reader, ref rowData.SuitID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SuitName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.SuitQuality, CVSReader.intParse);
			this.columnno = 2;
			base.ReadArray<int>(reader, ref rowData.EquipID, CVSReader.intParse);
			this.columnno = 3;
			rowData.Effect1.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.Effect2.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			rowData.Effect3.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			rowData.Effect4.Read(reader, this.m_DataHandler);
			this.columnno = 7;
			rowData.Effect5.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			rowData.Effect6.Read(reader, this.m_DataHandler);
			this.columnno = 9;
			rowData.Effect7.Read(reader, this.m_DataHandler);
			this.columnno = 10;
			rowData.Effect8.Read(reader, this.m_DataHandler);
			this.columnno = 11;
			rowData.Effect9.Read(reader, this.m_DataHandler);
			this.columnno = 12;
			rowData.Effect10.Read(reader, this.m_DataHandler);
			this.columnno = 13;
			base.Read<int>(reader, ref rowData.ProfID, CVSReader.intParse);
			this.columnno = 14;
			base.Read<int>(reader, ref rowData.Level, CVSReader.intParse);
			this.columnno = 15;
			base.Read<bool>(reader, ref rowData.IsCreateShow, CVSReader.boolParse);
			this.columnno = 16;
			base.Read<uint>(reader, ref rowData.SuitNum, CVSReader.uintParse);
			this.columnno = 17;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x0001D3BC File Offset: 0x0001B5BC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new EquipSuitTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000332 RID: 818
		public EquipSuitTable.RowData[] Table = null;

		// Token: 0x020002E5 RID: 741
		public class RowData
		{
			// Token: 0x04000A67 RID: 2663
			public int SuitID;

			// Token: 0x04000A68 RID: 2664
			public string SuitName;

			// Token: 0x04000A69 RID: 2665
			public int SuitQuality;

			// Token: 0x04000A6A RID: 2666
			public int[] EquipID;

			// Token: 0x04000A6B RID: 2667
			public SeqRef<float> Effect1;

			// Token: 0x04000A6C RID: 2668
			public SeqRef<float> Effect2;

			// Token: 0x04000A6D RID: 2669
			public SeqRef<float> Effect3;

			// Token: 0x04000A6E RID: 2670
			public SeqRef<float> Effect4;

			// Token: 0x04000A6F RID: 2671
			public SeqRef<float> Effect5;

			// Token: 0x04000A70 RID: 2672
			public SeqRef<float> Effect6;

			// Token: 0x04000A71 RID: 2673
			public SeqRef<float> Effect7;

			// Token: 0x04000A72 RID: 2674
			public SeqRef<float> Effect8;

			// Token: 0x04000A73 RID: 2675
			public SeqRef<float> Effect9;

			// Token: 0x04000A74 RID: 2676
			public SeqRef<float> Effect10;

			// Token: 0x04000A75 RID: 2677
			public int ProfID;

			// Token: 0x04000A76 RID: 2678
			public int Level;

			// Token: 0x04000A77 RID: 2679
			public bool IsCreateShow;

			// Token: 0x04000A78 RID: 2680
			public uint SuitNum;
		}
	}
}
