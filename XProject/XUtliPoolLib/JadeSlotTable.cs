using System;

namespace XUtliPoolLib
{

	public class JadeSlotTable : CVSReader
	{

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

		public JadeSlotTable.RowData[] Table = null;

		public class RowData
		{

			public byte EquipSlot;

			public SeqListRef<uint> JadeSlotAndLevel;
		}
	}
}
