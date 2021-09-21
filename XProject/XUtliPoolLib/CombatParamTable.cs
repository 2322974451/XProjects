using System;

namespace XUtliPoolLib
{
	// Token: 0x020000C8 RID: 200
	public class CombatParamTable : CVSReader
	{
		// Token: 0x0600058C RID: 1420 RVA: 0x00019318 File Offset: 0x00017518
		protected override void ReadLine(XBinaryReader reader)
		{
			CombatParamTable.RowData rowData = new CombatParamTable.RowData();
			base.Read<int>(reader, ref rowData.CriticalBase, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.CritResistBase, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.ParalyzeBase, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.ParaResistBase, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.StunBase, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.StunResistBase, CVSReader.intParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.CritDamageBase, CVSReader.intParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.FinalDamageBase, CVSReader.intParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.PhysicalDef, CVSReader.intParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.MagicDef, CVSReader.intParse);
			this.columnno = 10;
			base.Read<int>(reader, ref rowData.ElementAtk, CVSReader.intParse);
			this.columnno = 11;
			base.Read<int>(reader, ref rowData.ElementDef, CVSReader.intParse);
			this.columnno = 12;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x00019480 File Offset: 0x00017680
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CombatParamTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002EE RID: 750
		public CombatParamTable.RowData[] Table = null;

		// Token: 0x020002C6 RID: 710
		public class RowData
		{
			// Token: 0x0400099D RID: 2461
			public int CriticalBase;

			// Token: 0x0400099E RID: 2462
			public int CritResistBase;

			// Token: 0x0400099F RID: 2463
			public int ParalyzeBase;

			// Token: 0x040009A0 RID: 2464
			public int ParaResistBase;

			// Token: 0x040009A1 RID: 2465
			public int StunBase;

			// Token: 0x040009A2 RID: 2466
			public int StunResistBase;

			// Token: 0x040009A3 RID: 2467
			public int CritDamageBase;

			// Token: 0x040009A4 RID: 2468
			public int FinalDamageBase;

			// Token: 0x040009A5 RID: 2469
			public int PhysicalDef;

			// Token: 0x040009A6 RID: 2470
			public int MagicDef;

			// Token: 0x040009A7 RID: 2471
			public int ElementAtk;

			// Token: 0x040009A8 RID: 2472
			public int ElementDef;
		}
	}
}
