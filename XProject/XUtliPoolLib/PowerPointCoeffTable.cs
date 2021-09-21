using System;

namespace XUtliPoolLib
{
	// Token: 0x0200014E RID: 334
	public class PowerPointCoeffTable : CVSReader
	{
		// Token: 0x0600079A RID: 1946 RVA: 0x00026740 File Offset: 0x00024940
		protected override void ReadLine(XBinaryReader reader)
		{
			PowerPointCoeffTable.RowData rowData = new PowerPointCoeffTable.RowData();
			base.Read<int>(reader, ref rowData.AttributeID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Profession, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<double>(reader, ref rowData.Weight, CVSReader.doubleParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x000267B8 File Offset: 0x000249B8
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PowerPointCoeffTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400039A RID: 922
		public PowerPointCoeffTable.RowData[] Table = null;

		// Token: 0x0200034D RID: 845
		public class RowData
		{
			// Token: 0x04000D23 RID: 3363
			public int AttributeID;

			// Token: 0x04000D24 RID: 3364
			public uint Profession;

			// Token: 0x04000D25 RID: 3365
			public double Weight;
		}
	}
}
