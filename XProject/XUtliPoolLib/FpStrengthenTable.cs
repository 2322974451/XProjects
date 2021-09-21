using System;

namespace XUtliPoolLib
{
	// Token: 0x020000FA RID: 250
	public class FpStrengthenTable : CVSReader
	{
		// Token: 0x0600065E RID: 1630 RVA: 0x0001ED14 File Offset: 0x0001CF14
		public FpStrengthenTable.RowData GetByBQID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FpStrengthenTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchBQID(key);
			}
			return result;
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x0001ED4C File Offset: 0x0001CF4C
		private FpStrengthenTable.RowData BinarySearchBQID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			FpStrengthenTable.RowData rowData;
			FpStrengthenTable.RowData rowData2;
			FpStrengthenTable.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.BQID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.BQID == key;
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
				bool flag4 = rowData3.BQID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.BQID.CompareTo(key) < 0;
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

		// Token: 0x06000660 RID: 1632 RVA: 0x0001EE28 File Offset: 0x0001D028
		protected override void ReadLine(XBinaryReader reader)
		{
			FpStrengthenTable.RowData rowData = new FpStrengthenTable.RowData();
			base.Read<int>(reader, ref rowData.BQID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Bqtype, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.BQSystem, CVSReader.intParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.BQTips, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.BQImageID, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.BQName, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.ShowLevel, CVSReader.intParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x0001EF08 File Offset: 0x0001D108
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FpStrengthenTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000346 RID: 838
		public FpStrengthenTable.RowData[] Table = null;

		// Token: 0x020002F9 RID: 761
		public class RowData
		{
			// Token: 0x04000AF7 RID: 2807
			public int BQID;

			// Token: 0x04000AF8 RID: 2808
			public int Bqtype;

			// Token: 0x04000AF9 RID: 2809
			public int BQSystem;

			// Token: 0x04000AFA RID: 2810
			public string BQTips;

			// Token: 0x04000AFB RID: 2811
			public string BQImageID;

			// Token: 0x04000AFC RID: 2812
			public string BQName;

			// Token: 0x04000AFD RID: 2813
			public int ShowLevel;
		}
	}
}
