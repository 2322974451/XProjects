using System;

namespace XUtliPoolLib
{
	// Token: 0x02000262 RID: 610
	public class EquipFusionExpTable : CVSReader
	{
		// Token: 0x06000D25 RID: 3365 RVA: 0x00045624 File Offset: 0x00043824
		public EquipFusionExpTable.RowData GetByCoreItemId(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			EquipFusionExpTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].CoreItemId == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000D26 RID: 3366 RVA: 0x00045690 File Offset: 0x00043890
		protected override void ReadLine(XBinaryReader reader)
		{
			EquipFusionExpTable.RowData rowData = new EquipFusionExpTable.RowData();
			base.Read<uint>(reader, ref rowData.CoreItemId, CVSReader.uintParse);
			this.columnno = 0;
			rowData.AssistItemId.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.AddExp, CVSReader.uintParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D27 RID: 3367 RVA: 0x00045708 File Offset: 0x00043908
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new EquipFusionExpTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007B0 RID: 1968
		public EquipFusionExpTable.RowData[] Table = null;

		// Token: 0x020003F1 RID: 1009
		public class RowData
		{
			// Token: 0x040011EB RID: 4587
			public uint CoreItemId;

			// Token: 0x040011EC RID: 4588
			public SeqListRef<uint> AssistItemId;

			// Token: 0x040011ED RID: 4589
			public uint AddExp;
		}
	}
}
