using System;

namespace XUtliPoolLib
{

	public class XOperationTable : CVSReader
	{

		public XOperationTable.RowData GetByID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			XOperationTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchID(key);
			}
			return result;
		}

		private XOperationTable.RowData BinarySearchID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			XOperationTable.RowData rowData;
			XOperationTable.RowData rowData2;
			XOperationTable.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.ID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.ID == key;
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
				bool flag4 = rowData3.ID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.ID.CompareTo(key) < 0;
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
			XOperationTable.RowData rowData = new XOperationTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<float>(reader, ref rowData.Angle, CVSReader.floatParse);
			this.columnno = 1;
			base.Read<float>(reader, ref rowData.Distance, CVSReader.floatParse);
			this.columnno = 2;
			base.Read<bool>(reader, ref rowData.Vertical, CVSReader.boolParse);
			this.columnno = 3;
			base.Read<bool>(reader, ref rowData.Horizontal, CVSReader.boolParse);
			this.columnno = 4;
			base.Read<float>(reader, ref rowData.MaxV, CVSReader.floatParse);
			this.columnno = 5;
			base.Read<float>(reader, ref rowData.MinV, CVSReader.floatParse);
			this.columnno = 6;
			base.Read<bool>(reader, ref rowData.OffSolo, CVSReader.boolParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new XOperationTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public XOperationTable.RowData[] Table = null;

		public class RowData
		{

			public int ID;

			public float Angle;

			public float Distance;

			public bool Vertical;

			public bool Horizontal;

			public float MaxV;

			public float MinV;

			public bool OffSolo;
		}
	}
}
