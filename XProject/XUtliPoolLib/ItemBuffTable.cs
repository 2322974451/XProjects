using System;

namespace XUtliPoolLib
{
	// Token: 0x0200011F RID: 287
	public class ItemBuffTable : CVSReader
	{
		// Token: 0x060006EC RID: 1772 RVA: 0x00022340 File Offset: 0x00020540
		public ItemBuffTable.RowData GetByItemId(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ItemBuffTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ItemId == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x000223AC File Offset: 0x000205AC
		protected override void ReadLine(XBinaryReader reader)
		{
			ItemBuffTable.RowData rowData = new ItemBuffTable.RowData();
			base.Read<uint>(reader, ref rowData.ItemId, CVSReader.uintParse);
			this.columnno = 0;
			rowData.Buffs.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x00022424 File Offset: 0x00020624
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ItemBuffTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400036B RID: 875
		public ItemBuffTable.RowData[] Table = null;

		// Token: 0x0200031E RID: 798
		public class RowData
		{
			// Token: 0x04000BE4 RID: 3044
			public uint ItemId;

			// Token: 0x04000BE5 RID: 3045
			public SeqListRef<uint> Buffs;

			// Token: 0x04000BE6 RID: 3046
			public string Name;
		}
	}
}
