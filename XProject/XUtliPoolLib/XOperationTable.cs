using System;

namespace XUtliPoolLib
{
	// Token: 0x02000187 RID: 391
	public class XOperationTable : CVSReader
	{
		// Token: 0x06000875 RID: 2165 RVA: 0x0002D9D0 File Offset: 0x0002BBD0
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

		// Token: 0x06000876 RID: 2166 RVA: 0x0002DA08 File Offset: 0x0002BC08
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

		// Token: 0x06000877 RID: 2167 RVA: 0x0002DAE4 File Offset: 0x0002BCE4
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

		// Token: 0x06000878 RID: 2168 RVA: 0x0002DBE0 File Offset: 0x0002BDE0
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

		// Token: 0x040003D3 RID: 979
		public XOperationTable.RowData[] Table = null;

		// Token: 0x02000386 RID: 902
		public class RowData
		{
			// Token: 0x04000FAF RID: 4015
			public int ID;

			// Token: 0x04000FB0 RID: 4016
			public float Angle;

			// Token: 0x04000FB1 RID: 4017
			public float Distance;

			// Token: 0x04000FB2 RID: 4018
			public bool Vertical;

			// Token: 0x04000FB3 RID: 4019
			public bool Horizontal;

			// Token: 0x04000FB4 RID: 4020
			public float MaxV;

			// Token: 0x04000FB5 RID: 4021
			public float MinV;

			// Token: 0x04000FB6 RID: 4022
			public bool OffSolo;
		}
	}
}
