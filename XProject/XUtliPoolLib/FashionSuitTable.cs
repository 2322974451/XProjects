using System;

namespace XUtliPoolLib
{
	// Token: 0x020000EC RID: 236
	public class FashionSuitTable : CVSReader
	{
		// Token: 0x06000630 RID: 1584 RVA: 0x0001DDCC File Offset: 0x0001BFCC
		public FashionSuitTable.RowData GetBySuitID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FashionSuitTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SuitID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x0001DE38 File Offset: 0x0001C038
		protected override void ReadLine(XBinaryReader reader)
		{
			FashionSuitTable.RowData rowData = new FashionSuitTable.RowData();
			base.Read<int>(reader, ref rowData.SuitID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SuitName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.SuitQuality, CVSReader.intParse);
			this.columnno = 2;
			base.ReadArray<uint>(reader, ref rowData.FashionID, CVSReader.uintParse);
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
			rowData.All1.Read(reader, this.m_DataHandler);
			this.columnno = 11;
			rowData.All2.Read(reader, this.m_DataHandler);
			this.columnno = 12;
			rowData.All3.Read(reader, this.m_DataHandler);
			this.columnno = 13;
			rowData.All4.Read(reader, this.m_DataHandler);
			this.columnno = 14;
			base.Read<bool>(reader, ref rowData.NoSale, CVSReader.boolParse);
			this.columnno = 21;
			base.Read<int>(reader, ref rowData.ShowLevel, CVSReader.intParse);
			this.columnno = 22;
			base.Read<int>(reader, ref rowData.OverAll, CVSReader.intParse);
			this.columnno = 23;
			base.Read<int>(reader, ref rowData.CraftedItemQuality, CVSReader.intParse);
			this.columnno = 24;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x0001E040 File Offset: 0x0001C240
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FashionSuitTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000338 RID: 824
		public FashionSuitTable.RowData[] Table = null;

		// Token: 0x020002EB RID: 747
		public class RowData
		{
			// Token: 0x04000AAB RID: 2731
			public int SuitID;

			// Token: 0x04000AAC RID: 2732
			public string SuitName;

			// Token: 0x04000AAD RID: 2733
			public int SuitQuality;

			// Token: 0x04000AAE RID: 2734
			public uint[] FashionID;

			// Token: 0x04000AAF RID: 2735
			public SeqListRef<uint> Effect2;

			// Token: 0x04000AB0 RID: 2736
			public SeqListRef<uint> Effect3;

			// Token: 0x04000AB1 RID: 2737
			public SeqListRef<uint> Effect4;

			// Token: 0x04000AB2 RID: 2738
			public SeqListRef<uint> Effect5;

			// Token: 0x04000AB3 RID: 2739
			public SeqListRef<uint> Effect6;

			// Token: 0x04000AB4 RID: 2740
			public SeqListRef<uint> Effect7;

			// Token: 0x04000AB5 RID: 2741
			public SeqListRef<uint> All1;

			// Token: 0x04000AB6 RID: 2742
			public SeqListRef<uint> All2;

			// Token: 0x04000AB7 RID: 2743
			public SeqListRef<uint> All3;

			// Token: 0x04000AB8 RID: 2744
			public SeqListRef<uint> All4;

			// Token: 0x04000AB9 RID: 2745
			public bool NoSale;

			// Token: 0x04000ABA RID: 2746
			public int ShowLevel;

			// Token: 0x04000ABB RID: 2747
			public int OverAll;

			// Token: 0x04000ABC RID: 2748
			public int CraftedItemQuality;
		}
	}
}
