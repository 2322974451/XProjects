using System;

namespace XUtliPoolLib
{
	// Token: 0x02000239 RID: 569
	public class FashionHair : CVSReader
	{
		// Token: 0x06000C8F RID: 3215 RVA: 0x0004216C File Offset: 0x0004036C
		public FashionHair.RowData GetByHairID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FashionHair.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].HairID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000C90 RID: 3216 RVA: 0x000421D8 File Offset: 0x000403D8
		protected override void ReadLine(XBinaryReader reader)
		{
			FashionHair.RowData rowData = new FashionHair.RowData();
			base.Read<uint>(reader, ref rowData.HairID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.DefaultColorID, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadArray<uint>(reader, ref rowData.UnLookColorID, CVSReader.uintParse);
			this.columnno = 3;
			rowData.Cost.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C91 RID: 3217 RVA: 0x0004226C File Offset: 0x0004046C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FashionHair.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000787 RID: 1927
		public FashionHair.RowData[] Table = null;

		// Token: 0x020003C8 RID: 968
		public class RowData
		{
			// Token: 0x0400110C RID: 4364
			public uint HairID;

			// Token: 0x0400110D RID: 4365
			public uint DefaultColorID;

			// Token: 0x0400110E RID: 4366
			public uint[] UnLookColorID;

			// Token: 0x0400110F RID: 4367
			public SeqListRef<uint> Cost;
		}
	}
}
