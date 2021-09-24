using System;

namespace XUtliPoolLib
{

	public class EnchantEquip : CVSReader
	{

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

		public EnchantEquip.RowData[] Table = null;

		public class RowData
		{

			public uint EnchantID;

			public uint[] Pos;

			public SeqListRef<uint> Attribute;

			public SeqListRef<uint> Cost;

			public uint Num;

			public uint VisiblePos;

			public uint EnchantLevel;
		}
	}
}
