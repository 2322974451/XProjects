using System;

namespace XUtliPoolLib
{

	public class CombatParamTable : CVSReader
	{

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

		public CombatParamTable.RowData[] Table = null;

		public class RowData
		{

			public int CriticalBase;

			public int CritResistBase;

			public int ParalyzeBase;

			public int ParaResistBase;

			public int StunBase;

			public int StunResistBase;

			public int CritDamageBase;

			public int FinalDamageBase;

			public int PhysicalDef;

			public int MagicDef;

			public int ElementAtk;

			public int ElementDef;
		}
	}
}
