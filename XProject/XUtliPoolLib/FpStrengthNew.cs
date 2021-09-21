using System;

namespace XUtliPoolLib
{
	// Token: 0x020000FB RID: 251
	public class FpStrengthNew : CVSReader
	{
		// Token: 0x06000663 RID: 1635 RVA: 0x0001EF48 File Offset: 0x0001D148
		public FpStrengthNew.RowData GetByBQID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FpStrengthNew.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].BQID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x0001EFB4 File Offset: 0x0001D1B4
		protected override void ReadLine(XBinaryReader reader)
		{
			FpStrengthNew.RowData rowData = new FpStrengthNew.RowData();
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
			base.Read<int>(reader, ref rowData.ShowLevel, CVSReader.intParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.StarNum, CVSReader.intParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x0001F094 File Offset: 0x0001D294
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FpStrengthNew.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000347 RID: 839
		public FpStrengthNew.RowData[] Table = null;

		// Token: 0x020002FA RID: 762
		public class RowData
		{
			// Token: 0x04000AFE RID: 2814
			public int BQID;

			// Token: 0x04000AFF RID: 2815
			public int Bqtype;

			// Token: 0x04000B00 RID: 2816
			public int BQSystem;

			// Token: 0x04000B01 RID: 2817
			public string BQTips;

			// Token: 0x04000B02 RID: 2818
			public string BQImageID;

			// Token: 0x04000B03 RID: 2819
			public int ShowLevel;

			// Token: 0x04000B04 RID: 2820
			public int StarNum;
		}
	}
}
