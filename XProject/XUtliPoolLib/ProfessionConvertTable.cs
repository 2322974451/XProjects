using System;

namespace XUtliPoolLib
{
	// Token: 0x02000150 RID: 336
	public class ProfessionConvertTable : CVSReader
	{
		// Token: 0x060007A0 RID: 1952 RVA: 0x00026898 File Offset: 0x00024A98
		protected override void ReadLine(XBinaryReader reader)
		{
			ProfessionConvertTable.RowData rowData = new ProfessionConvertTable.RowData();
			base.Read<int>(reader, ref rowData.ProfessionID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.AttributeID, CVSReader.intParse);
			this.columnno = 1;
			base.Read<double>(reader, ref rowData.PhysicalAtk, CVSReader.doubleParse);
			this.columnno = 2;
			base.Read<double>(reader, ref rowData.PhysicalDef, CVSReader.doubleParse);
			this.columnno = 3;
			base.Read<double>(reader, ref rowData.MagicAtk, CVSReader.doubleParse);
			this.columnno = 4;
			base.Read<double>(reader, ref rowData.MagicDef, CVSReader.doubleParse);
			this.columnno = 5;
			base.Read<double>(reader, ref rowData.Critical, CVSReader.doubleParse);
			this.columnno = 6;
			base.Read<double>(reader, ref rowData.CritResist, CVSReader.doubleParse);
			this.columnno = 7;
			base.Read<double>(reader, ref rowData.MaxHP, CVSReader.doubleParse);
			this.columnno = 12;
			base.Read<double>(reader, ref rowData.MaxMP, CVSReader.doubleParse);
			this.columnno = 13;
			base.Read<double>(reader, ref rowData.CritDamage, CVSReader.doubleParse);
			this.columnno = 15;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x000269E4 File Offset: 0x00024BE4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ProfessionConvertTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400039C RID: 924
		public ProfessionConvertTable.RowData[] Table = null;

		// Token: 0x0200034F RID: 847
		public class RowData
		{
			// Token: 0x04000D28 RID: 3368
			public int ProfessionID;

			// Token: 0x04000D29 RID: 3369
			public int AttributeID;

			// Token: 0x04000D2A RID: 3370
			public double PhysicalAtk;

			// Token: 0x04000D2B RID: 3371
			public double PhysicalDef;

			// Token: 0x04000D2C RID: 3372
			public double MagicAtk;

			// Token: 0x04000D2D RID: 3373
			public double MagicDef;

			// Token: 0x04000D2E RID: 3374
			public double Critical;

			// Token: 0x04000D2F RID: 3375
			public double CritResist;

			// Token: 0x04000D30 RID: 3376
			public double MaxHP;

			// Token: 0x04000D31 RID: 3377
			public double MaxMP;

			// Token: 0x04000D32 RID: 3378
			public double CritDamage;
		}
	}
}
