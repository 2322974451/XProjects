using System;

namespace XUtliPoolLib
{

	public class SuperArmorRecoveryCoffTable : CVSReader
	{

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

		public SuperArmorRecoveryCoffTable.RowData[] Table = null;

		public class RowData
		{

			public int Value;

			public int monster_type;

			public double SupRecoveryChange;
		}
	}
}
