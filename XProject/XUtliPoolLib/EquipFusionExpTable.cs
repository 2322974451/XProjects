using System;

namespace XUtliPoolLib
{

	public class EquipFusionExpTable : CVSReader
	{

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

		public EquipFusionExpTable.RowData[] Table = null;

		public class RowData
		{

			public uint CoreItemId;

			public SeqListRef<uint> AssistItemId;

			public uint AddExp;
		}
	}
}
