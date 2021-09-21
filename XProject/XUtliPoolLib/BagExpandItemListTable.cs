using System;

namespace XUtliPoolLib
{
	// Token: 0x02000232 RID: 562
	public class BagExpandItemListTable : CVSReader
	{
		// Token: 0x06000C74 RID: 3188 RVA: 0x00041844 File Offset: 0x0003FA44
		public BagExpandItemListTable.RowData GetByItemId(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			BagExpandItemListTable.RowData result;
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

		// Token: 0x06000C75 RID: 3189 RVA: 0x000418B0 File Offset: 0x0003FAB0
		public BagExpandItemListTable.RowData GetByType(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			BagExpandItemListTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].Type == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000C76 RID: 3190 RVA: 0x0004191C File Offset: 0x0003FB1C
		protected override void ReadLine(XBinaryReader reader)
		{
			BagExpandItemListTable.RowData rowData = new BagExpandItemListTable.RowData();
			base.Read<uint>(reader, ref rowData.ItemId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 1;
			rowData.NeedAndOpen.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C77 RID: 3191 RVA: 0x00041994 File Offset: 0x0003FB94
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new BagExpandItemListTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000780 RID: 1920
		public BagExpandItemListTable.RowData[] Table = null;

		// Token: 0x020003C1 RID: 961
		public class RowData
		{
			// Token: 0x040010EA RID: 4330
			public uint ItemId;

			// Token: 0x040010EB RID: 4331
			public uint Type;

			// Token: 0x040010EC RID: 4332
			public SeqListRef<uint> NeedAndOpen;
		}
	}
}
