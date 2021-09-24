using System;

namespace XUtliPoolLib
{

	public class ProfessionConvertTable : CVSReader
	{

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

		public ProfessionConvertTable.RowData[] Table = null;

		public class RowData
		{

			public int ProfessionID;

			public int AttributeID;

			public double PhysicalAtk;

			public double PhysicalDef;

			public double MagicAtk;

			public double MagicDef;

			public double Critical;

			public double CritResist;

			public double MaxHP;

			public double MaxMP;

			public double CritDamage;
		}
	}
}
