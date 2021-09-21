using System;

namespace XUtliPoolLib
{
	// Token: 0x02000178 RID: 376
	public class SuperArmorRecoveryCoffTable : CVSReader
	{
		// Token: 0x06000839 RID: 2105 RVA: 0x0002B224 File Offset: 0x00029424
		protected override void ReadLine(XBinaryReader reader)
		{
			SuperArmorRecoveryCoffTable.RowData rowData = new SuperArmorRecoveryCoffTable.RowData();
			base.Read<int>(reader, ref rowData.Value, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.monster_type, CVSReader.intParse);
			this.columnno = 1;
			base.Read<double>(reader, ref rowData.SupRecoveryChange, CVSReader.doubleParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x0002B29C File Offset: 0x0002949C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SuperArmorRecoveryCoffTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003C4 RID: 964
		public SuperArmorRecoveryCoffTable.RowData[] Table = null;

		// Token: 0x02000377 RID: 887
		public class RowData
		{
			// Token: 0x04000EB6 RID: 3766
			public int Value;

			// Token: 0x04000EB7 RID: 3767
			public int monster_type;

			// Token: 0x04000EB8 RID: 3768
			public double SupRecoveryChange;
		}
	}
}
