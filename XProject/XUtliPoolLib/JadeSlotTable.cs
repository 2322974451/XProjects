using System;

namespace XUtliPoolLib
{
	// Token: 0x0200025F RID: 607
	public class JadeSlotTable : CVSReader
	{
		// Token: 0x06000D18 RID: 3352 RVA: 0x000450EC File Offset: 0x000432EC
		public JadeSlotTable.RowData GetByEquipSlot(byte key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			JadeSlotTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].EquipSlot == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000D19 RID: 3353 RVA: 0x00045158 File Offset: 0x00043358
		protected override void ReadLine(XBinaryReader reader)
		{
			JadeSlotTable.RowData rowData = new JadeSlotTable.RowData();
			base.Read<byte>(reader, ref rowData.EquipSlot, CVSReader.byteParse);
			this.columnno = 0;
			rowData.JadeSlotAndLevel.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D1A RID: 3354 RVA: 0x000451B8 File Offset: 0x000433B8
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new JadeSlotTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007AD RID: 1965
		public JadeSlotTable.RowData[] Table = null;

		// Token: 0x020003EE RID: 1006
		public class RowData
		{
			// Token: 0x040011D7 RID: 4567
			public byte EquipSlot;

			// Token: 0x040011D8 RID: 4568
			public SeqListRef<uint> JadeSlotAndLevel;
		}
	}
}
