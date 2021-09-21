using System;

namespace XUtliPoolLib
{
	// Token: 0x02000228 RID: 552
	public class FashionCharm : CVSReader
	{
		// Token: 0x06000C50 RID: 3152 RVA: 0x00040B10 File Offset: 0x0003ED10
		public FashionCharm.RowData GetBySuitID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FashionCharm.RowData result;
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

		// Token: 0x06000C51 RID: 3153 RVA: 0x00040B7C File Offset: 0x0003ED7C
		protected override void ReadLine(XBinaryReader reader)
		{
			FashionCharm.RowData rowData = new FashionCharm.RowData();
			base.Read<uint>(reader, ref rowData.SuitID, CVSReader.uintParse);
			this.columnno = 0;
			rowData.Effect1.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.Effect2.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			rowData.Effect3.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			rowData.Effect4.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.Effect5.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			rowData.Effect6.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			rowData.Effect7.Read(reader, this.m_DataHandler);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 8;
			base.ReadArray<uint>(reader, ref rowData.SuitParam, CVSReader.uintParse);
			this.columnno = 9;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x00040CAC File Offset: 0x0003EEAC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FashionCharm.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000776 RID: 1910
		public FashionCharm.RowData[] Table = null;

		// Token: 0x020003B7 RID: 951
		public class RowData
		{
			// Token: 0x040010AA RID: 4266
			public uint SuitID;

			// Token: 0x040010AB RID: 4267
			public SeqListRef<uint> Effect1;

			// Token: 0x040010AC RID: 4268
			public SeqListRef<uint> Effect2;

			// Token: 0x040010AD RID: 4269
			public SeqListRef<uint> Effect3;

			// Token: 0x040010AE RID: 4270
			public SeqListRef<uint> Effect4;

			// Token: 0x040010AF RID: 4271
			public SeqListRef<uint> Effect5;

			// Token: 0x040010B0 RID: 4272
			public SeqListRef<uint> Effect6;

			// Token: 0x040010B1 RID: 4273
			public SeqListRef<uint> Effect7;

			// Token: 0x040010B2 RID: 4274
			public uint Level;

			// Token: 0x040010B3 RID: 4275
			public uint[] SuitParam;
		}
	}
}
