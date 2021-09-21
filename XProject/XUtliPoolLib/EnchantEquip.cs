using System;

namespace XUtliPoolLib
{
	// Token: 0x020000E1 RID: 225
	public class EnchantEquip : CVSReader
	{
		// Token: 0x06000605 RID: 1541 RVA: 0x0001C8D0 File Offset: 0x0001AAD0
		public EnchantEquip.RowData GetByEnchantID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			EnchantEquip.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].EnchantID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x0001C93C File Offset: 0x0001AB3C
		protected override void ReadLine(XBinaryReader reader)
		{
			EnchantEquip.RowData rowData = new EnchantEquip.RowData();
			base.Read<uint>(reader, ref rowData.EnchantID, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.Pos, CVSReader.uintParse);
			this.columnno = 1;
			rowData.Attribute.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			rowData.Cost.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.Num, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.VisiblePos, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.EnchantLevel, CVSReader.uintParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x0001CA1C File Offset: 0x0001AC1C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new EnchantEquip.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400032D RID: 813
		public EnchantEquip.RowData[] Table = null;

		// Token: 0x020002E0 RID: 736
		public class RowData
		{
			// Token: 0x04000A3E RID: 2622
			public uint EnchantID;

			// Token: 0x04000A3F RID: 2623
			public uint[] Pos;

			// Token: 0x04000A40 RID: 2624
			public SeqListRef<uint> Attribute;

			// Token: 0x04000A41 RID: 2625
			public SeqListRef<uint> Cost;

			// Token: 0x04000A42 RID: 2626
			public uint Num;

			// Token: 0x04000A43 RID: 2627
			public uint VisiblePos;

			// Token: 0x04000A44 RID: 2628
			public uint EnchantLevel;
		}
	}
}
