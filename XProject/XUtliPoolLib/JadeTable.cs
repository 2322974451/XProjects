using System;

namespace XUtliPoolLib
{

	public class JadeTable : CVSReader
	{

		public JadeTable.RowData GetByJadeID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			JadeTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchJadeID(key);
			}
			return result;
		}

		private JadeTable.RowData BinarySearchJadeID(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			JadeTable.RowData rowData;
			JadeTable.RowData rowData2;
			JadeTable.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.JadeID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.JadeID == key;
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
				bool flag4 = rowData3.JadeID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.JadeID.CompareTo(key) < 0;
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
			JadeTable.RowData rowData = new JadeTable.RowData();
			base.Read<uint>(reader, ref rowData.JadeID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.JadeEquip, CVSReader.uintParse);
			this.columnno = 1;
			rowData.JadeAttributes.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			rowData.JadeCompose.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.JadeLevel, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.MosaicPlace, CVSReader.stringParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new JadeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public JadeTable.RowData[] Table = null;

		public class RowData
		{

			public uint JadeID;

			public uint JadeEquip;

			public SeqListRef<uint> JadeAttributes;

			public SeqRef<uint> JadeCompose;

			public uint JadeLevel;

			public string MosaicPlace;
		}
	}
}
