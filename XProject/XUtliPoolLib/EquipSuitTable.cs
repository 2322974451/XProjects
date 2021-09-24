using System;

namespace XUtliPoolLib
{

	public class EquipSuitTable : CVSReader
	{

		public EquipSuitTable.RowData GetBySuitID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			EquipSuitTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchSuitID(key);
			}
			return result;
		}

		private EquipSuitTable.RowData BinarySearchSuitID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			EquipSuitTable.RowData rowData;
			EquipSuitTable.RowData rowData2;
			EquipSuitTable.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.SuitID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.SuitID == key;
				if (flag2)
				{
					goto Block_2;
				}
				bool flag3 = num2 - num <= 1;
				if (flag3)
				{
					goto Block_3;
				}
				int num3 = num + (num2 - num) / 2;
				rowData3 = this.Table[num3];
				bool flag4 = rowData3.SuitID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.SuitID.CompareTo(key) < 0;
					if (!flag5)
					{
						goto IL_B1;
					}
					num = num3;
				}
				if (num >= num2)
				{
					goto Block_6;
				}
			}
			return rowData;
			Block_2:
			return rowData2;
			Block_3:
			return null;
			IL_B1:
			return rowData3;
			Block_6:
			return null;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			EquipSuitTable.RowData rowData = new EquipSuitTable.RowData();
			base.Read<int>(reader, ref rowData.SuitID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SuitName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.SuitQuality, CVSReader.intParse);
			this.columnno = 2;
			base.ReadArray<int>(reader, ref rowData.EquipID, CVSReader.intParse);
			this.columnno = 3;
			rowData.Effect1.Read(reader, this.m_DataHandler);
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
			rowData.Effect8.Read(reader, this.m_DataHandler);
			this.columnno = 11;
			rowData.Effect9.Read(reader, this.m_DataHandler);
			this.columnno = 12;
			rowData.Effect10.Read(reader, this.m_DataHandler);
			this.columnno = 13;
			base.Read<int>(reader, ref rowData.ProfID, CVSReader.intParse);
			this.columnno = 14;
			base.Read<int>(reader, ref rowData.Level, CVSReader.intParse);
			this.columnno = 15;
			base.Read<bool>(reader, ref rowData.IsCreateShow, CVSReader.boolParse);
			this.columnno = 16;
			base.Read<uint>(reader, ref rowData.SuitNum, CVSReader.uintParse);
			this.columnno = 17;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new EquipSuitTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public EquipSuitTable.RowData[] Table = null;

		public class RowData
		{

			public int SuitID;

			public string SuitName;

			public int SuitQuality;

			public int[] EquipID;

			public SeqRef<float> Effect1;

			public SeqRef<float> Effect2;

			public SeqRef<float> Effect3;

			public SeqRef<float> Effect4;

			public SeqRef<float> Effect5;

			public SeqRef<float> Effect6;

			public SeqRef<float> Effect7;

			public SeqRef<float> Effect8;

			public SeqRef<float> Effect9;

			public SeqRef<float> Effect10;

			public int ProfID;

			public int Level;

			public bool IsCreateShow;

			public uint SuitNum;
		}
	}
}
